using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SnakeAndLadders
{
    public class DataAccess
    {

        public static MySqlConnection mySqlConnection = new MySqlConnection("server=localhost;user id=root;password=A4Appqs!;persistsecurityinfo=True;database=snakeandladder");
        public static string Username = "";
        public static string GameName = "my game";
        public static int PlayerLocation = 1;
        public static DataSet TilesData = new DataSet();
        //variable to store test results


        public string Login(string pUsername, string pPassword)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramUsername = new MySqlParameter("@username", MySqlDbType.VarChar, 20);
            var paramPassword = new MySqlParameter("@password", MySqlDbType.VarChar, 20);
            paramUsername.Value = pUsername;
            paramPassword.Value = pPassword;
            paramInput.Add(paramUsername);
            paramInput.Add(paramPassword);
            
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "login(@username,@password)", paramInput.ToArray());
            
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string Register(string pUsername, string pPassword)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramUsername = new MySqlParameter("@username", MySqlDbType.VarChar, 20);
            var paramPassword = new MySqlParameter("@password", MySqlDbType.VarChar, 20);
            paramUsername.Value = pUsername;
            paramPassword.Value = pPassword;
            paramInput.Add(paramUsername);
            paramInput.Add(paramPassword);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "register_player(@username,@password)", paramInput.ToArray());
            
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString(); ;
        }

        public List<string> GetActiveGames()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "get_active_games()");
            var activeGames = (aDataSet.Tables[0]);
            var list = (from x in activeGames.AsEnumerable()
                        select x.Field<string>(0)).ToList();
            return list;
        }

        public string CreateNewGame(string pGameName)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramgameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            paramgameName.Value = pGameName;
            paramInput.Add(paramgameName);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "create_new_game(@gameName)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public List<string> GetOnlinePlayers()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "get_online_players()");
            var activeGames = (aDataSet.Tables[0]);
            var list = (from x in activeGames.AsEnumerable()
                        select x.Field<string>(0)).ToList();
            return list;
        }

        public List<string> GetAllPlayers()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "get_all_players()");
            var activeGames = (aDataSet.Tables[0]);
            var list = (from x in activeGames.AsEnumerable()
                        select x.Field<string>(0)).ToList();
            return list;
        }

        public List<string> GetPlayersInGame(string pGameName)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            paramGameName.Value = pGameName;
            paramInput.Add(paramGameName);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "get_players_in_game(@gameName)", paramInput.ToArray());
            var players = (aDataSet.Tables[0]);
            var list = (from x in players.AsEnumerable()
                        select x.Field<string>(0)).ToList();
            return list;
        }

        public string JoinGame(string pGameName)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            var paramUserName = new MySqlParameter("@userName", MySqlDbType.VarChar, 20);
            paramGameName.Value = pGameName;
            paramUserName.Value = Username;
            paramInput.Add(paramGameName);
            paramInput.Add(paramUserName);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "join_game(@userName,@gameName)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public List<string> GetAllGames()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "get_all_games()");
            var allGames = (aDataSet.Tables[0]);
            var list = (from x in allGames.AsEnumerable()
                        select x.Field<string>(0)).ToList();
            return list;
        }

        public string MovePlayer()
        {

            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            var paramUserName = new MySqlParameter("@userName", MySqlDbType.VarChar, 20);
            var paramDiceValue = new MySqlParameter("@diceValue", MySqlDbType.Int16);
            Random rnd = new Random();
            int dice = rnd.Next(1, 7);
            paramGameName.Value = GameName;
            paramUserName.Value = Username;
            paramDiceValue.Value = dice;
            paramInput.Add(paramGameName);
            paramInput.Add(paramUserName);
            paramInput.Add(paramDiceValue);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "move_player(@userName, @gameName,@diceValue)", paramInput.ToArray());
            string returned = (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
            int pFrom = returned.IndexOf("TileID-") + "TileID-".Length;
            int pTo = returned.LastIndexOf("-");
            PlayerLocation = Convert.ToInt32(returned.Substring(pFrom, pTo - pFrom));
            return returned;
        }

        public DataSet GetPlayersInAGame()
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            paramGameName.Value = GameName;
            paramInput.Add(paramGameName);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "all_players_location(@gameName)", paramInput.ToArray());
            return aDataSet;
            //return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string AdminEditPlayer(string pUsername, string pPassword, int pLoginAttempts, bool pIsAdmin)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramUsername = new MySqlParameter("@username", MySqlDbType.VarChar, 20);
            var paramPassword = new MySqlParameter("@password", MySqlDbType.VarChar, 20);
            var paramLoginAttempts = new MySqlParameter("@loginAttempts", MySqlDbType.Int16);
            var paramIsAdmin = new MySqlParameter("@isAdmin", MySqlDbType.Bit);
            paramUsername.Value = pUsername;
            paramPassword.Value = pPassword;
            paramLoginAttempts.Value = pLoginAttempts;
            paramIsAdmin.Value = pIsAdmin;
            paramInput.Add(paramUsername);
            paramInput.Add(paramPassword); 
            paramInput.Add(paramLoginAttempts);
            paramInput.Add(paramIsAdmin);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "admin_edit_player(@userName,@password,@loginAttempts,@isAdmin)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string AdminCheck()
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramUserName = new MySqlParameter("@username", MySqlDbType.VarChar, 20);
            paramUserName.Value = Username;
            paramInput.Add(paramUserName);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "admin_access(@username)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string DeletePlayer(string pPlayer)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramUsername = new MySqlParameter("@username", MySqlDbType.VarChar, 20);
            paramUsername.Value = pPlayer;
            paramInput.Add(paramUsername);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "admin_delete_player(@username)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string DeleteGame(string pGameName)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            paramGameName.Value = pGameName;
            paramInput.Add(paramGameName);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "admin_delete_game(@gameName)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string SendChatMessage(String message)
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramMessage = new MySqlParameter("@message", MySqlDbType.VarChar, 20);
            var paramUsername = new MySqlParameter("@userName", MySqlDbType.VarChar, 20);
            var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            paramMessage.Value = message;
            paramUsername.Value = Username;
            paramGameName.Value = GameName;
            paramInput.Add(paramUsername);
            paramInput.Add(paramGameName);
            paramInput.Add(paramMessage);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "send_message(@message,@username,@gameName)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string RetrieveChat(string pGameName)
        {
            if (GameName.Length > 1)
            {
                pGameName = GameName;
                return "You can only retirve the chat of game that you have joined.";
            }
            else
            {
                List<MySqlParameter> paramInput = new List<MySqlParameter>();
                var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
                paramGameName.Value = GameName;
                paramInput.Add(paramGameName);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "recent_chat(@gameName)", paramInput.ToArray());
                return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
            }
        }

        public string LeaveGame()
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramUsername = new MySqlParameter("@userName", MySqlDbType.VarChar, 20);
            var paramGameName = new MySqlParameter("@gameName", MySqlDbType.VarChar, 20);
            paramUsername.Value = Username;
            paramGameName.Value = Username;
            paramInput.Add(paramUsername);
            paramInput.Add(paramGameName);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "leave_game(@userName,@gameName)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public string Logout()
        {
            List<MySqlParameter> paramInput = new List<MySqlParameter>();
            var paramUsername = new MySqlParameter("@userName", MySqlDbType.VarChar, 20);
            paramUsername.Value = Username;
            paramInput.Add(paramUsername);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "logout(@userName)", paramInput.ToArray());
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

    }
}
