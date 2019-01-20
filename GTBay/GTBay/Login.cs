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
    public partial class Login : Form
    {

        string connStr = GTBay.Utility.GetConnectionString();

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Exit();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register reg = new Register(this);
            reg.Show();
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string position = "";

            if (username != "" && password != "")
            {
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand loginCmd = new SqlCommand();
                SqlDataReader reader;

                loginCmd.CommandText = GTBay.Utility.LoginSql();
                loginCmd.CommandType = CommandType.Text;
                loginCmd.Connection = conn;

                conn.Open();
                loginCmd.Parameters.AddWithValue("@username", username);
                reader = loginCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string retPass = reader.GetString(0);
                        int userId = (int)reader.GetValue(1);
                        if (!reader.IsDBNull(2))
                        {
                            position = reader.GetString(2);
                        }

                        if (password == retPass)
                        {
                            Menu menu = new Menu(userId,position);
                            menu.Show();
                            this.Hide();
                        }
                        else
                        {
                            messageLabel.Text = "Incorrect Password";
                        }
                    }

                }
                else
                {
                    messageLabel.Text = "Username does not exist. Please register!";
                }
                reader.Close();
                conn.Close();
                
            }
            else
            {
                messageLabel.Text = "Please enter a username and password or register an account.";
            }
        }

    }
}
