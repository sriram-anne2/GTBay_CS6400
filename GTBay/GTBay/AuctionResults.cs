using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GTBay
{
    public partial class AuctionResults : Form
    {
        int userId;
        string position;
        Menu menu;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand updateCmd = new SqlCommand(GTBay.Utility.UpdateAuctionsSql());
        SqlCommand resultsCmd = new SqlCommand(GTBay.Utility.AuctionResultsSql());
        SqlDataReader reader;

        public AuctionResults()
        {

        }

        public AuctionResults(int userId, string position, Menu menu)
        {
            InitializeComponent();
            this.userId = userId;
            this.position = position;
            this.menu = menu;
            this.Text = "Auction Results " + position;
            this.dataGridView1.Columns["SalePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns["Winner"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            updateCmd.Connection = conn;
            resultsCmd.Connection = conn;
            conn.Open();
            updateCmd.ExecuteNonQuery();
            reader = resultsCmd.ExecuteReader();
            

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

                row.Cells[4].Value = reader.GetValue(4);;

                this.dataGridView1.Rows.Add(row);
            }
            conn.Close();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string itemId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            SearchResults sr = new SearchResults();
            string prevPage = "auction";
            Item item = new Item(userId, position, itemId,sr,this,prevPage);
            item.Show();
            this.Hide();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
