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
    public partial class Item : Form
    {
        int userId;
        string itemId;
        string position;
        string description;
        int listingUser;
        decimal minBid = 0;
        string startBid;
        SearchResults sr;
        AuctionResults ar;
        string prevPage;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand itemCmd = new SqlCommand(GTBay.Utility.ItemSql());
        SqlCommand descriptionCmd = new SqlCommand(GTBay.Utility.UpdateDescriptionSql());
        SqlCommand getNowCmd = new SqlCommand(GTBay.Utility.GetNowSql());
        SqlCommand getNow2Cmd = new SqlCommand(GTBay.Utility.GetNow2Sql());
        SqlCommand topBidsCmd = new SqlCommand(GTBay.Utility.TopBidsSql());
        SqlCommand bidCmd = new SqlCommand(GTBay.Utility.BidSql());
        SqlCommand updateCmd = new SqlCommand(GTBay.Utility.UpdateAuctionsSql());
        SqlDataReader reader;

        public Item(int userId, string position, string itemId, SearchResults sr, AuctionResults ar, string prevPage)
        {
            InitializeComponent();
            this.userId = userId;
            this.position = position;
            this.itemId = itemId;
            this.prevPage = prevPage;
            this.sr = sr;
            this.ar = ar;

            this.Text = "Item for Sale" + position;
            itemIdLabel.Text = itemId;

            itemCmd.Connection = conn;
            updateCmd.Connection = conn;
            itemCmd.Parameters.AddWithValue("@itemId", itemId);
            messageLabel.Text = "";

            conn.Open();

            updateCmd.ExecuteNonQuery();
            reader = itemCmd.ExecuteReader();

            while (reader.Read())
            {
                itemNameLabel.Text = reader.GetString(0);
                descriptionTextBox.Text= reader.GetString(1);
                description = reader.GetString(1);
                categoryLabel.Text = reader.GetString(2);
                conditionLabel.Text = reader.GetString(3);
                returnCheckBox.Checked = (bool) reader.GetValue(4);
                                               
                if (!reader.IsDBNull(5))
                {
                    getItNowLabel.Text = reader.GetValue(5).ToString();

                }
                else
                {
                    label7.Hide();
                    getItNowLabel.Hide();
                    getItNowButton.Hide();
                }
                listingUser = (int) reader.GetValue(6);
                auctionEndLabel.Text = reader.GetValue(7).ToString();
                if (!reader.IsDBNull(8))
                {
                    bidTextBox.ReadOnly = true;
                    bidButton.Hide();
                    label7.Hide();
                    getItNowLabel.Hide();
                    getItNowButton.Hide();
                }
                startBid = reader.GetValue(9).ToString();

            }
            reader.Close();
            if (listingUser != userId)
            {
                editDescriptionLabel.Hide();
            }

            topBidsCmd.Connection = conn;
            topBidsCmd.Parameters.AddWithValue("@itemId", itemId);
            reader = topBidsCmd.ExecuteReader();
            
            while (reader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = reader.GetValue(0);
                if (minBid < ((decimal)reader.GetValue(0) + 1))
                {
                    minBid = (decimal)reader.GetValue(0) + 1;
                    minBidLabel.Text = minBidLabel.Text + minBid.ToString()+")";
                }
                row.Cells[1].Value = reader.GetValue(1);
                row.Cells[2].Value = reader.GetValue(2);
                this.dataGridView1.Rows.Add(row);
            }

            if (minBidLabel.Text == "(minimum bid $")
            {
                minBidLabel.Text = minBidLabel.Text + startBid + ")";
                minBid = decimal.Parse(startBid);
            }

            conn.Close();

            descriptionCmd.Connection = conn;
            descriptionCmd.Parameters.AddWithValue("@itemId", itemId);
            descriptionCmd.Parameters.AddWithValue("@userId", userId);
            getNowCmd.Connection = conn;
            getNow2Cmd.Connection = conn;
            getNowCmd.Parameters.AddWithValue("@userId", userId);
            getNowCmd.Parameters.AddWithValue("@getItNow", getItNowLabel.Text);
            getNowCmd.Parameters.AddWithValue("@itemId", itemId);
            getNow2Cmd.Parameters.AddWithValue("@itemId", itemId);
            bidCmd.Connection = conn;
            bidCmd.Parameters.AddWithValue("@itemId", itemId);
            bidCmd.Parameters.AddWithValue("@userId", userId);
        }

        private void bidButton_Click(object sender, EventArgs e)
        {
            //decimal.Parse(getItNowLabel.Text
            messageLabel.Text = "";
            if (bidTextBox.Text != "" && decimal.Parse(bidTextBox.Text) >= minBid)
            {
                //string str = getItNowLabel.Text;
                ////decimal c;
                ////if (Convert.ToDecimal(getItNowLabel.Text) == 0)
                //decimal bida = Convert.ToDecimal(bidTextBox.Text);
                //decimal getn = Convert.ToDecimal(getItNowLabel.Text);
                //if (str == null)
                //{
                //    conn.Open();
                //    bidCmd.Parameters.AddWithValue("@bidAmount", bidTextBox.Text);
                //    bidCmd.ExecuteNonQuery();
                //    bidTextBox.Text = "";
                //    conn.Close();
                //    Item item = new Item(userId, position, itemId, sr, ar, prevPage);
                //    item.Show();
                //    this.Close();
                //}
                //else if (Convert.ToDecimal(bidTextBox.Text) < Convert.ToDecimal(getItNowLabel.Text))
                //if (decimal.Parse(bidTextBox.Text) < Convert.ToDecimal(getItNowLabel.Text))
                //decimal b = decimal.Parse(bidTextBox.Text);
                //decimal g = Convert.ToDecimal(getItNowLabel.Text);
                //if (b < g)
                if (getItNowLabel.Text == "" || decimal.Parse(bidTextBox.Text) < decimal.Parse(getItNowLabel.Text))

                {
                    conn.Open();
                     bidCmd.Parameters.AddWithValue("@bidAmount", bidTextBox.Text);
                     bidCmd.ExecuteNonQuery();
                     bidTextBox.Text = "";
                     conn.Close();
                     Item item = new Item(userId, position, itemId,sr,ar,prevPage);
                     item.Show();
                     this.Hide();
                }
                else
                {
                        messageLabel.Text = "Bid too high. Use Get It Now!";
                }
            }
            else
            {
                messageLabel.Text = "Bid too low";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (prevPage == "search")
            {
                sr.Show();
                this.Hide();
            }
            else
            {
                ar.Show();
                this.Hide();
            }

        }

        private void getItNowButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            getNowCmd.ExecuteNonQuery();
            getNow2Cmd.ExecuteNonQuery();
            conn.Close();
            Item item = new Item(userId,position, itemId,sr,ar,prevPage);
            item.Show();
            this.Hide();
        }

        private void editDescriptionLabel_Click(object sender, EventArgs e)
        {
            if (editDescriptionLabel.Text == "Edit Description")
            {
                editDescriptionLabel.Text = "Update Description";
                descriptionTextBox.ReadOnly = false;
            }
            else
            {
                editDescriptionLabel.Text = "Edit Description";
                descriptionTextBox.ReadOnly = true;
                conn.Open();
                descriptionCmd.Parameters.AddWithValue("@description", descriptionTextBox.Text);
                descriptionCmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void viewRatingsLabel_Click(object sender, EventArgs e)
        {
            ItemRating rating = new ItemRating(userId, itemId, position, itemNameLabel.Text, this);
            rating.Show();
            this.Hide();
        }

        private void bidTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            if (Regex.IsMatch(bidTextBox.Text, @"\.\d\d"))
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
