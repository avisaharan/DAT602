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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var message=aDataAccess.Login(usernameText.Text, passwordText.Text);
            
            if (message.Contains("Logged In"))
            {
                SelectGame selectGame = new SelectGame();
                selectGame.Show();
                this.Hide();
            }
            else if(message.Contains("Doesn't exist"))
            {
                var result = MessageBox.Show("This username does not exist. Would you like to register?", "Username No Match", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    message= aDataAccess.Register(usernameText.Text, passwordText.Text);
                    if(message.Contains("UserName is taken"))
                    {
                        result = MessageBox.Show(message, "Unsuccessful", MessageBoxButtons.OK);
                        if (result == DialogResult.OK) { }
                    }
                    else if (message.Contains("registered"))
                    {
                        result = MessageBox.Show(message, "Registered", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            SelectGame selectGame = new SelectGame();
                            selectGame.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        result = MessageBox.Show(message, "Error", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                }

            }
            else
            {
                var result = MessageBox.Show(message, "Unsuccessful", MessageBoxButtons.OK);
                if (result == DialogResult.OK){}
            }
        }
    }
}
