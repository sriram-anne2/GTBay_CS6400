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
using System.Collections;

namespace GTBay
{
    public partial class ItemRating : Form
    {
        int userId;
        string itemId;
        string position;
        string itemName;
        Item item;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand getRatingsCmd = new SqlCommand(GTBay.Utility.getRatingsSql());
        SqlCommand avgRatingsCmd = new SqlCommand(GTBay.Utility.avgRatingSql());
        SqlCommand insertRatingCmd = new SqlCommand(GTBay.Utility.insertRatingSql());
        SqlCommand deleteRatingCmd = new SqlCommand(GTBay.Utility.deleteRatingSql());
        SqlDataReader reader;
        ArrayList userRatings = new ArrayList();
        bool isUserReview;

        public ItemRating(int userId, string itemId, string position, string itemName, Item item)
        {
            InitializeComponent();
            this.userId = userId;
            this.itemId = itemId;
            this.position = position;
            this.itemName = itemName;
            this.item = item;
            this.Text = "Item Rating " + position;
            this.itemIdLabel.Text = itemId;
            this.itemNameLabel.Text = itemName;

            avgRatingsCmd.Connection = conn;
            avgRatingsCmd.Parameters.AddWithValue("@itemName", itemName);
            conn.Open();
            var result = avgRatingsCmd.ExecuteScalar();

            avgRatingLabel.Text = result.ToString();

            getRatingsCmd.Connection = conn;
            getRatingsCmd.Parameters.AddWithValue("@itemName", itemName);
            reader = getRatingsCmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {
                int rating = (int)reader.GetValue(0);
                string comment = reader.GetString(1);
                userRatings.Add(reader.GetValue(2));
                string userName = reader.GetString(3);
                string date = reader.GetValue(4).ToString();
                if ((int)reader.GetValue(2) == userId)
                {
                    isUserReview = true;
                }
                else
                {
                    isUserReview = false;
                }
                if (isUserReview)
                {
                    Label l = new Label();
                    l.Click += new EventHandler(deleteMyRatingLabel_Click);
                    l.Text = "Delete My Rating";
                    l.ForeColor = System.Drawing.Color.Blue;
                    tableLayoutPanel1.Controls.Add(l , 0, x);
                    x++;
                }

                Label l1 = new Label();
                l1.Text = "Rated By:";
                tableLayoutPanel1.Controls.Add(l1, 0, x);
                Label l2 = new Label();
                l2.Text = userName;
                tableLayoutPanel1.Controls.Add(l2, 1, x);
                RatingControls.StarRatingControl star = new RatingControls.StarRatingControl();
                star.Enabled = false;
                star.SelectedStar = rating;
                star.HoverStar = rating;
                tableLayoutPanel1.Controls.Add(star, 2, x);
                x++;
                Label l3 = new Label();
                l3.Text = "Date:";
                tableLayoutPanel1.Controls.Add(l3, 0, x);
                Label l4 = new Label();
                l4.Text = date;
                tableLayoutPanel1.Controls.Add(l4, 1, x);
                x++;
                Label l5 = new Label();
                l5.Text = comment;
                tableLayoutPanel1.Controls.Add(l5, 0, x);
                tableLayoutPanel1.SetColumnSpan(l5, 3);
                x++;
            }
            reader.Close();
            conn.Close();

            if (userRatings.Contains(userId))
            {
                myStarRating.Hide();
                rateButton.Hide();
                commentBox.Enabled = false;
            }
            else
            {
                myStarRating.Show();
                rateButton.Show();
                commentBox.Enabled = true;
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            item.Show();
            this.Hide();
        }

        private void rateButton_Click(object sender, EventArgs e)
        {
            insertRatingCmd.Connection = conn;
            insertRatingCmd.Parameters.AddWithValue("@userId", userId);
            insertRatingCmd.Parameters.AddWithValue("@itemId", itemId);
            insertRatingCmd.Parameters.AddWithValue("@rating", myStarRating.SelectedStar);
            insertRatingCmd.Parameters.AddWithValue("@comment", commentBox.Text);
            conn.Open();
            insertRatingCmd.ExecuteNonQuery();
            conn.Close();
            ItemRating ir = new ItemRating(userId, itemId, position, itemName,item);
            ir.Show();
            this.Hide();
        }

        private void deleteMyRatingLabel_Click(object sender, EventArgs e)
        {
            deleteRatingCmd.Connection = conn;
            deleteRatingCmd.Parameters.AddWithValue("@itemId", itemId);
            deleteRatingCmd.Parameters.AddWithValue("@userId", userId);
            conn.Open();
            deleteRatingCmd.ExecuteNonQuery();
            conn.Close();
            //reload page
            ItemRating ir = new ItemRating(userId, itemId, position, itemName, item);
            ir.Show();
            this.Hide();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
