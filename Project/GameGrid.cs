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
    
    public partial class GameGrid : Form
    {

        public GameGrid()
        {
            InitializeComponent();
        }

        private void GameGrid_Load(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            TilesGrid.DataSource = aDataAccess.Rough();
            // Set your desired AutoSize Mode:
            //TilesGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //TilesGrid.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //TilesGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            //for (int i = 0; i <= TilesGrid.Columns.Count - 1; i++)
            //{
            //    // Store Auto Sized Widths:
            //    int colw = TilesGrid.Columns[i].Width;

            //    // Remove AutoSizing:
            //    TilesGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //    // Set Width to calculated AutoSize value:
            //    TilesGrid.Columns[i].Width = colw;
            //}

            myLocation.Text = Convert.ToString(DataAccess.PlayerLocation);
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

        private void leaveGameButton_Click(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var message = aDataAccess.LeaveGame();
            if (message.Contains("left"))
            {
                MessageBox.Show(message);
                SelectGame selectGame = new SelectGame();
                selectGame.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error while leaving the game.");
            }

        }

        private void rollDiceButton_Click(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var message = aDataAccess.MovePlayer();
        }
    }
}
