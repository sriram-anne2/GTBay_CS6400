using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTBay
{
    public partial class Menu : Form
    {
        int userId;
        string position;
        public Menu(int userId, string position)
        {
            InitializeComponent();
            this.userId = userId;
            this.position = position;
            this.Text = "Menu";
            if (this.position != "")
            {
                this.Text = "Menu for admin with position: " + this.position;
                this.categoryReportButton.Show();
                this.userReportButton.Show();
            }
            else
            {
                this.categoryReportButton.Hide();
                this.userReportButton.Hide();
            }
        }

        private void itemSearchButton_Click(object sender, EventArgs e)
        {
            ItemSearch itemSearch = new ItemSearch(userId, position, this);
            itemSearch.Show();
            this.Hide();

        }

        private void listItemButton_Click(object sender, EventArgs e)
        {
            ListItem listItem = new ListItem(userId, position, this);
            listItem.Show();
            this.Hide();
        }

        private void auctionResultsButton_Click(object sender, EventArgs e)
        {
            AuctionResults auctionResult = new AuctionResults(userId, position, this);
            auctionResult.Show();
            this.Hide();
        }

        private void categoryReportButton_Click(object sender, EventArgs e)
        {
            CategoryReport categoryReport = new CategoryReport(userId, position, this);
            categoryReport.Show();
            this.Hide();
        }

        private void userReportButton_Click(object sender, EventArgs e)
        {
            UserReport userReport = new UserReport(userId, position, this);
            userReport.Show();
            this.Hide();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
