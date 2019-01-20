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
using System.Configuration;

namespace GTBay
{
    public partial class Register : Form
    {

        string connStr = GTBay.Utility.GetConnectionString();
        Login login;

        public Register(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void Register_Closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            string fName = firstNameTextBox.Text;
            string lName = lastNameTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string confPassword = confirmPasswordTextBox.Text;

            if ((fName != "" && lName != "" && username != "" && password != "" && confPassword != "") && password == confPassword)
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand checkUsername = new SqlCommand();
                SqlCommand loginCmd = new SqlCommand();

                checkUsername.CommandText = GTBay.Utility.UserExistsSql();
                checkUsername.Parameters.AddWithValue("@username", username);
                checkUsername.Connection = conn;

                conn.Open();

                int userCount = (int)checkUsername.ExecuteScalar();
                if (userCount == 0)
                {
                    loginCmd.CommandText = GTBay.Utility.RegisterSql();
                    loginCmd.Parameters.AddWithValue("@fName", fName);
                    loginCmd.Parameters.AddWithValue("@lName", lName);
                    loginCmd.Parameters.AddWithValue("@username", username);
                    loginCmd.Parameters.AddWithValue("@password", password);
                    loginCmd.Connection = conn;
                    loginCmd.ExecuteNonQuery();
                    conn.Close();
                    login.Show();
                    this.Hide();

                }
                else
                {
                    messageLabel.Text = "Username already exists! Please try a different one!";
                }
                conn.Close();
            }
            else
            {
                if (fName != "" && lName != "" && username != "" && password != "" && confPassword != "")
                {
                    messageLabel.Text = "Passwords do no match. Please try again.";
                }
                else
                {
                    messageLabel.Text = "All Fields are Required!";
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Hide();
        }
    }
}
