﻿using System;
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
            DataAccess aDataAccess = new DataAccess();
            var playersInGame = aDataAccess.GetPlayersInGame(Convert.ToString(gameList.SelectedItem));
            PlayersInTheSelectedGame.DataSource = playersInGame;
        }

        private void SelectGame_Load(object sender, EventArgs e)
        {
            DataAccess aDataAccess = new DataAccess();

            var allGames=aDataAccess.GetAllGames();
            gameList.DataSource = allGames;

            var onlinePlayers = aDataAccess.GetOnlinePlayers();
            PlayersInTheSelectedGame.DataSource = onlinePlayers;
            var playersInGame = aDataAccess.GetPlayersInGame(Convert.ToString(gameList.SelectedItem));
            PlayersInTheSelectedGame.DataSource = playersInGame;
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            CreateNewGame newGame = new CreateNewGame();
            newGame.Show();
            this.Close();
        }

        private void adminToolsButton_Click(object sender, EventArgs e)
        {
            AdminTools admintools = new AdminTools();
            admintools.Show();
            this.Hide();
        }

        private void joinGameButton_Click(object sender, EventArgs e)
        {
            
            DataAccess aDataAccess = new DataAccess();
            var message = aDataAccess.JoinGame(Convert.ToString(gameList.SelectedItem));
            if(message.Contains("has joined")){
                MessageBox.Show(message);
                var playersInGame = aDataAccess.GetPlayersInGame(Convert.ToString(gameList.SelectedItem));
                PlayersInTheSelectedGame.DataSource = playersInGame;
            }
            else
            {
                MessageBox.Show("Failed to join the game");
            }
        }
    }
}
