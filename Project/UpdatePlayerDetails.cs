using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeAndLadders
{
    public partial class UpdatePlayerDetails : Form
    {
        private string username;
        public UpdatePlayerDetails(string pusername)
        {
            InitializeComponent();
            username = pusername;
            userNameTextBox.Text = username;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AdminTools admintools = new AdminTools();
            admintools.Show();
            this.Hide();
        }

        private void saveNewDetails_Click(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var message = aDataAccess.AdminEditPlayer(username, passwordTextBox.Text, Convert.ToInt32(loginAttempts.Text), isAdminCheckbox.Checked);
            if (message.Contains("Updated"))
            {
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Not updated");
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var message = aDataAccess.Logout();
            if (message.Contains("Logged out"))
            {
                MessageBox.Show(message);
                Login login = new Login();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error while logging out");
            }
        }
    }
}
