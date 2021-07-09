using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SnakeAndLadders
{
    public partial class SelectGame : Form
    {
         
        public SelectGame()
        {
            InitializeComponent();
        }

        private void CurrentlyActiveGamesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SelectGame_Load(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var activegames=aDataAccess.GetActiveGames();
            var onlinePlayers = aDataAccess.GetOnlinePlayers();
            CurrentlyActiveGamesList.DataSource = activegames;
            PlayersInTheSelectedGame.DataSource = onlinePlayers;
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            CreateNewGame newGame = new CreateNewGame();
            newGame.Show();
            this.Hide();
        }
    }
}
