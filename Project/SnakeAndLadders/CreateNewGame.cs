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
    public partial class CreateNewGame : Form
    {
        public CreateNewGame()
        {
            InitializeComponent();
        }

        private void createGameButton_Click(object sender, EventArgs e)
        { 
            DataAccess aDataAccess = new DataAccess();
            var gameCreated = aDataAccess.CreateNewGame(gameNameBox.Text);
            if (gameCreated.Length > 2){
                MessageBox.Show(gameCreated);
                SelectGame newSelect = new SelectGame();
                newSelect.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Game creating failed.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectGame newSelect = new SelectGame();
            newSelect.Show();
            this.Close();
        }
    }
}
