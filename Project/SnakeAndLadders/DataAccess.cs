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

        public static MySqlConnection mySqlConnection= new MySqlConnection("server=localhost;user id=root;password=A4Appqs!;persistsecurityinfo=True;database=snakeandladder");

        //variable to store test results

        public static bool login; 
        public static bool create_new_game;
        public static bool admin_edit_player;
        public static bool get_active_games;
        public static bool get_online_players;
        public static bool join_game;
        public static bool leave_game;
        
        public static bool register;
        public static bool logout;
        public static bool move_player;
        public static bool recent_chat;
        public static bool send_message;



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
            var login = (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
            return login;
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
            var register = (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
            return register;
        }

        public List<string> GetActiveGames()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "get_active_games()");
            var activeGames = (aDataSet.Tables[0]);
            var list = (from x in activeGames.AsEnumerable()
                        select x.Field<string>(0)).ToList();
            return list;
        }

        public List<string> GetOnlinePlayers()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "get_online_players()");
            var activeGames = (aDataSet.Tables[0]);
            var list = (from x in activeGames.AsEnumerable()
                        select x.Field<string>(0)).ToList();
            return list;
        }




    }
}
