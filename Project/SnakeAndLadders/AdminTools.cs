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
            var allPlayers = aDataAccess.GetAllPlayers();
            activeGamesList.DataSource = activegames;
            allPlayersList.DataSource = allPlayers;
        }

        private void activeGamesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updatePlayerButton_Click(object sender, EventArgs e)
        {
            UpdatePlayerDetails updateplayer = new UpdatePlayerDetails();
            updateplayer.Show();
            this.Hide();
        }
    }
}
