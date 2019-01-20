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
    public partial class CategoryReport : Form
    {
        int userId;
        string position;
        Menu menu;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand updateCmd = new SqlCommand(GTBay.Utility.UpdateAuctionsSql());
        SqlCommand categoryReportCmd = new SqlCommand(GTBay.Utility.categoryReportSql());
        SqlDataReader reader;

        public CategoryReport(int userId, string position, Menu menu)
        {
            InitializeComponent();
            this.userId = userId;
            this.position = position;
            this.menu = menu;
            this.dataGridView1.Columns["MinPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns["MaxPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Columns["AveragePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Text = "Category Report " + position;
            updateCmd.Connection = conn;
            categoryReportCmd.Connection = conn;

            conn.Open();
            updateCmd.ExecuteNonQuery();
            reader = categoryReportCmd.ExecuteReader();

            while (reader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = reader.GetString(0);
                row.Cells[1].Value = reader.GetValue(1);
                if (reader.GetValue(2).ToString() != "")
                {
                    row.Cells[2].Value = "$" + reader.GetValue(2).ToString();
                }
                else
                {
                    row.Cells[2].Value = "-";
                }

                if (reader.GetValue(3).ToString() != "")
                {
                    row.Cells[3].Value = "$" + reader.GetValue(3).ToString();
                }
                else
                {
                    row.Cells[3].Value = "-";
                }

                if (reader.GetValue(4).ToString() != "")
                {
                    row.Cells[4].Value = "$" + reader.GetValue(4).ToString();
                }
                else
                {
                    row.Cells[4].Value = "-";
                }

                this.dataGridView1.Rows.Add(row);
            }

            conn.Close();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Hide();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
