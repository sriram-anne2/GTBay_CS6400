using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GTBay
{
    public partial class ListItem : Form
    {
        int userId;
        string position;
        Menu menu;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand conditionCmd = new SqlCommand(GTBay.Utility.GetConditionsSql());
        SqlCommand categoryCmd = new SqlCommand(GTBay.Utility.GetCategoriesSql());
        SqlCommand listCmd = new SqlCommand(GTBay.Utility.ListItemSql());
        SqlDataReader reader;

        string itemName;
        string description;
        int category;
        int condition;
        decimal startBid;
        decimal minSale;
        string auctionLengthString;
        int auctionLength;
        decimal? getItNow;
        bool returnable;

        public ListItem(int userId, string position, Menu menu)
        {
            InitializeComponent();
            messageLabel.Text = "";
            this.userId = userId;
            this.position = position;
            this.Text = "New Item " + position;
            this.menu = menu;
            conditionCmd.Connection = conn;
            categoryCmd.Connection = conn;
            conn.Open();

            reader = conditionCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string condition = reader.GetString(1);
                    conditionDropDown.Items.Add(condition);
                }
            }
            reader.Close();

            reader = categoryCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string category = reader.GetString(1);
                    categoryDropDown.Items.Add(category);
                }
            }
            reader.Close();
            conn.Close();

            auctionLengthDropdown.Items.Add("1 day");
            auctionLengthDropdown.Items.Add("3 days");
            auctionLengthDropdown.Items.Add("5 days");
            auctionLengthDropdown.Items.Add("7 days");
            categoryDropDown.SelectedIndex = 0;
            conditionDropDown.SelectedIndex = 0;
            auctionLengthDropdown.SelectedIndex = 0;

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Hide();
        }

        private void listItemButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            this.itemName = itemNameTextBox.Text;
            this.description = descriptionTextBox.Text;
            this.category = categoryDropDown.SelectedIndex + 1;
            this.condition = conditionDropDown.SelectedIndex + 1;
            if (string.IsNullOrEmpty(startBidTextBox.Text))
            {
                messageLabel.Text = "Please enter valid data and make sure all required fields are not empty";
                return;
            }
            else
            {
                this.startBid = decimal.Parse(startBidTextBox.Text);
            }

            if (string.IsNullOrEmpty(minPriceTextBox.Text))
            {
                messageLabel.Text = "Please enter valid data and make sure all required fields are not empty";
                return;
            }
            else
            {
                this.minSale = decimal.Parse(minPriceTextBox.Text);
            }

            if (string.IsNullOrEmpty(minPriceTextBox.Text))
            {
                messageLabel.Text = "Please enter valid data and make sure all required fields are not empty";
                return;
            }
            else
            {
                this.minSale = decimal.Parse(minPriceTextBox.Text);
            }
            this.auctionLengthString = auctionLengthDropdown.SelectedItem.ToString();
            if (auctionLengthString == "1 day")
            {
                auctionLength = 1;
            }
            else if (auctionLengthString == "3 days")
            {
                auctionLength = 3;
            }
            else if (auctionLengthString == "5 days")
            {
                auctionLength = 5;
            }
            else
            {
                auctionLength = 7;
            }

            if (string.IsNullOrEmpty(getItNowTextBox.Text))
            {
                this.getItNow = null;
            }
            else
            {
                this.getItNow = decimal.Parse(getItNowTextBox.Text);
            }
            
            this.returnable = returnCheckBox.Checked;

            if (this.itemName != "" && this.description != "")
            {
                if (minSale >= startBid)
                {
                    listCmd.Connection = conn;
                    conn.Open();
                    listCmd.Parameters.AddWithValue("@userId", userId);
                    listCmd.Parameters.AddWithValue("@itemName", itemName);
                    listCmd.Parameters.AddWithValue("@description", description);
                    listCmd.Parameters.AddWithValue("@category", category);
                    listCmd.Parameters.AddWithValue("@condition", condition);
                    listCmd.Parameters.AddWithValue("@returnable", returnable);
                    listCmd.Parameters.AddWithValue("@startBid", startBid);
                    listCmd.Parameters.AddWithValue("@minSale", minSale);
                    listCmd.Parameters.AddWithValue("@auctionLength", auctionLength);
                    if (getItNow.HasValue)
                    {
                        listCmd.Parameters.AddWithValue("@getItNow", getItNow);
                    }
                    else
                    {
                        listCmd.Parameters.AddWithValue("@getItNow", DBNull.Value);
                    }
                    
                    listCmd.ExecuteNonQuery();
                    conn.Close();
                    Menu menu = new Menu(userId, position);
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    messageLabel.Text = "Minimum Sale Price needs to be greater than Starting Bid";
                }
            }
            else
            {
                messageLabel.Text = "Please enter valid data and make sure all required fields are not empty";
            }


        }

        private void startBidTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(startBidTextBox.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }

        private void minPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(minPriceTextBox.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }

        private void getItNowTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(getItNowTextBox.Text, @"\.\d\d"))
            {
                e.Handled = true;
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
