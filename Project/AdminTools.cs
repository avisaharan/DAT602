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
    public partial class AdminTools : Form
    {
        public AdminTools()
        {
            InitializeComponent();
        }

        private void AdminTools_Load(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var activegames = aDataAccess.GetActiveGames();
            activeGamesList.DataSource = activegames;
            allPlayersList.DataSource = aDataAccess.GetAllPlayers();
            var allGames = aDataAccess.GetAllGames();
            allGamesList.DataSource = allGames;
        }

        private void activeGamesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updatePlayerButton_Click(object sender, EventArgs e)
        {

            UpdatePlayerDetails updateplayer = new UpdatePlayerDetails(Convert.ToString(allPlayersList.SelectedItem));
            updateplayer.Show();
            this.Hide();
        }

        private void deletePlayerButton_Click(object sender, EventArgs e)
        {
            var selectedPlayer = Convert.ToString(allPlayersList.SelectedItem);
            DataAccess aDataAccess = new DataAccess();
            var message=aDataAccess.DeletePlayer(selectedPlayer);
            if (message.Contains("Deleted")){
                MessageBox.Show(message);
                allPlayersList.DataSource = aDataAccess.GetAllPlayers();
            }
            else
            {
                MessageBox.Show($"Not Deleted {selectedPlayer}");
            }
        }


        private void DeleteGameButton_Click(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var message = aDataAccess.DeleteGame(Convert.ToString(allGamesList.SelectedItem));
            if (message.Contains("Deleted"))
            {
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
            var allGames = aDataAccess.GetAllGames();
            allGamesList.DataSource = allGames;

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            SelectGame selectGame = new SelectGame();
            selectGame.Show();
            this.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
