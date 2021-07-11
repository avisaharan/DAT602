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
        public List<TileCordinate> tilesCordinates{get;set;}

        public GameGrid()
        {
            InitializeComponent();
            tilesCordinates = CordinatesStore();
        }

        private void GameGrid_Load(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();
            var cordinates = this.tilesCordinates;
            TilesGrid.DataSource = aDataAccess.GetPlayersInAGame().Tables[0];
            myLocation.Text = Convert.ToString(DataAccess.PlayerLocation);
        }

        private List<TileCordinate> CordinatesStore()
        {
            var cordinates = new List<TileCordinate>();
            cordinates.Add(new TileCordinate()
            {
                Id=1,
                X = 1,
                Y=1
            });

            return cordinates;

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
