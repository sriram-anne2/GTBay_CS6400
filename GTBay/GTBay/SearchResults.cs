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

namespace GTBay
{
    public partial class SearchResults : Form
    {
        int userId;
        string position;
        string keyword;
        string category;
        //int category;
        int minPrice;
        int maxPrice;
        int condition;
        ItemSearch itemSearch;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand searchCmd = new SqlCommand(GTBay.Utility.SearchSql());
        SqlDataReader reader;

        public SearchResults()
        {

        }

        public SearchResults(int userId, string position, string keyword, string category, int minPrice, int maxPrice, int condition, ItemSearch itemSearch)
        {
            InitializeComponent();
            this.userId = userId;
            this.position = position;
            this.Text = "Search Results " + position;
            this.keyword = keyword;
            this.category = category;
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
            this.condition = condition;
            this.itemSearch = itemSearch;
            this.dataGridView1.Columns["CurrentBid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns["HighBidder"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 

            searchCmd.Parameters.AddWithValue("@keyword", "%" +this.keyword + "%");
            searchCmd.Parameters.AddWithValue("@category", "%" +this.category+ "%");
            //searchCmd.Parameters.AddWithValue("@category", this.category);
            searchCmd.Parameters.AddWithValue("@minPrice", this.minPrice);
            searchCmd.Parameters.AddWithValue("@maxPrice", this.maxPrice);
            searchCmd.Parameters.AddWithValue("@condition", this.condition);
            searchCmd.Connection = conn;

            conn.Open();
            reader = searchCmd.ExecuteReader();

            while (reader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = reader.GetValue(0);
                row.Cells[1].Value = reader.GetValue(1);

                if (!reader.IsDBNull(2))
                {
                    row.Cells[2].Value = reader.GetValue(2);
                }
                else
                {
                    row.Cells[2].Value = "-";
                }

                if (!reader.IsDBNull(3))
                {
                    row.Cells[3].Value = reader.GetValue(3);
                }
                else
                {
                    row.Cells[3].Value = "-";
                }

                row.Cells[4].Value = reader.GetValue(4);
                row.Cells[5].Value = reader.GetValue(5);

                this.dataGridView1.Rows.Add(row);
            }

            reader.Close();
            conn.Close();
        }

        private void backToSearchButton_Click(object sender, EventArgs e)
        {
            itemSearch.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string itemId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            AuctionResults ar = new AuctionResults();
            string prevPage = "search";
            Item item = new Item(userId,  position, itemId, this, ar, prevPage);
            item.Show();
            this.Hide();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
