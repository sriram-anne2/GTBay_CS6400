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
    public partial class ItemSearch : Form
    {
        int userId;
        string position;
        Menu menu;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand conditionCmd = new SqlCommand(GTBay.Utility.GetConditionsSql());
        SqlCommand categoryCmd = new SqlCommand(GTBay.Utility.GetCategoriesSql());
        SqlDataReader reader;

        string keyword = "";
        string categoryPicked = "";
        //int categoryPicked = 0;
        int minPrice = 0;
        int maxPrice = 9999999;
        int conditionPicked = 0;


        public ItemSearch(int userId, string position, Menu menu)
        {
            InitializeComponent();
            this.userId = userId;
            this.position = position;
            this.menu = menu;
            this.Text = "Item Search " + position;
            conditionCmd.Connection = conn;
            categoryCmd.Connection = conn;
            conn.Open();

            reader = conditionCmd.ExecuteReader();
            conditionDropDown.Items.Add("");
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
            categoryDropDown.Items.Add("");
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

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Hide();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.keyword = keywordTextBox.Text;
            Object categorySelected = categoryDropDown.SelectedItem;
            if (categorySelected == null)
            { 
                this.categoryPicked = categoryDropDown.SelectedText;
            }
            else
            {
                this.categoryPicked = categorySelected.ToString();

            }
            if (string.IsNullOrEmpty(minPriceTextBox.Text))
            {
                this.minPrice = 0;   
            }
            else
            {
                this.minPrice = int.Parse(minPriceTextBox.Text);
            }
            if (string.IsNullOrEmpty(maxPriceTextBox.Text))
            {
                this.maxPrice = 9999999;
            }
            else
            {
                this.maxPrice = int.Parse(maxPriceTextBox.Text);
            }
            
            this.conditionPicked = conditionDropDown.SelectedIndex;
            if (this.conditionPicked < 1)
            {
                this.conditionPicked = 0;
            }

            SearchResults search = new SearchResults(userId, position, this.keyword, this.categoryPicked, this.minPrice, this.maxPrice, this.conditionPicked, this);
            search.Show();
            this.Hide();
        }

        private void maxPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(maxPriceTextBox.Text, @"\.\d\d"))
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

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
