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
    public partial class UserReport : Form
    {
        int userId;
        string position;
        Menu menu;
        SqlConnection conn = new SqlConnection(GTBay.Utility.GetConnectionString());
        SqlCommand updateCmd = new SqlCommand(GTBay.Utility.UpdateAuctionsSql());
        SqlCommand userReportCmd = new SqlCommand(GTBay.Utility.userReportSql());
        SqlDataReader reader;

        public UserReport(int userId, string position, Menu menu)
        {
            InitializeComponent();
            this.userId = userId;
            this.position = position;
            this.menu = menu;
            this.Text = "User Report " + position;
            updateCmd.Connection = conn;
            userReportCmd.Connection = conn;

            conn.Open();
            updateCmd.ExecuteNonQuery();
            reader = userReportCmd.ExecuteReader();

            while (reader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = reader.GetString(0);
                row.Cells[1].Value = reader.GetValue(1);
                row.Cells[2].Value = reader.GetValue(2);
                row.Cells[3].Value = reader.GetValue(3);
                row.Cells[4].Value = reader.GetValue(4);


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
