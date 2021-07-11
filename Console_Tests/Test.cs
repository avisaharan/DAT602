using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Tests
{
    class Test
    {
        public static bool Tests()
        {
            DataAccess dataAccess = new DataAccess();
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("     Snake and Ladder- Procedures Testing");
            Console.WriteLine("=================================================");
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\t1  - Login");
            Console.WriteLine("\t2  - Register");
            Console.WriteLine("\t3  - GetActiveGames");
            Console.WriteLine("\t4  - CreateNewGame");
            Console.WriteLine("\t5  - GetOnlinePlayers");
            Console.WriteLine("\t6  - GetAllPlayers");
            Console.WriteLine("\t7  - GetPlayersInGame");
            Console.WriteLine("\t8  - JoinGame");
            Console.WriteLine("\t9  - GetAllGames");
            Console.WriteLine("\t10 - MovePlayer");
            Console.WriteLine("\t11 - AdminEditPlayer");
            Console.WriteLine("\t12 - AdminCheck");
            Console.WriteLine("\t13 - DeletePlayer");
            Console.WriteLine("\t14 - DeleteGame");
            Console.WriteLine("\t15 - SendChatMessage");
            Console.WriteLine("\t16 - RetrieveChat");
            Console.WriteLine("\t17 - Logout");
            Console.WriteLine("-------------------------------------------------");
            Console.Write("\r\nSelect an option: ");


            switch (Console.ReadLine())
            {
                default:
                    return true;
                case "1":
                    Console.WriteLine("Result = \n\n" + dataAccess.Login("ABhi", "A4APp"));
                    Pause();
                    return true;
                case "2":
                    Console.WriteLine("Result = \n\n" + dataAccess.Register("ABhi", "A4APp"));
                    Pause();
                    return true;
                case "3":
                    Console.WriteLine("--Result--\n\n" + string.Join(",", (dataAccess.GetActiveGames())));
                    Pause();
                    return true;
                case "4":
                    Console.WriteLine("Result = \n\n" + dataAccess.CreateNewGame("My new game"));
                    Pause();
                    return true;
                case "5":
                    Console.WriteLine("Result = \n\n" + dataAccess.GetOnlinePlayers());
                    Pause();
                    return true;
                case "6":
                    Console.WriteLine("Result = \n\n" + dataAccess.GetAllPlayers());
                    Pause();
                    return true;
                case "7":
                    Console.WriteLine("Result = \n\n" + dataAccess.GetPlayersInGame("My new game"));
                    Pause();
                    return true;
                case "8":
                    Console.WriteLine("Result = \n\n" + dataAccess.JoinGame("My new game"));
                    Pause();
                    return true;
                case "9":
                    Console.WriteLine("Result = \n\n" + dataAccess.GetAllGames());
                    Pause();
                    return true;
                case "10":
                    Console.WriteLine("Result = \n\n" + dataAccess.MovePlayer("ABhi", 5));
                    Pause();
                    return true;
                case "11":
                    Console.WriteLine("Result = \n\n" + dataAccess.AdminEditPlayer("ABhi", "A4APp", 0, true));
                    Pause();
                    return true;
                case "12":
                    Console.WriteLine("Result = \n\n" + dataAccess.AdminCheck());
                    Pause();
                    return true;
                case "13":
                    Console.WriteLine("Result = \n\n" + dataAccess.DeletePlayer("ABhi"));
                    Pause();
                    return true;
                case "14":
                    Console.WriteLine("Result = \n\n" + dataAccess.DeleteGame("My new game"));
                    Pause();
                    return true;
                case "15":
                    Console.WriteLine("Result = \n\n" + dataAccess.SendChatMessage("Hello World"));
                    Pause();
                    return true;
                case "16":
                    Console.WriteLine("Result = \n\n" + dataAccess.RetrieveChat("My new game"));
                    Pause();
                    return true;
                case "17":
                    Console.WriteLine("Result = \n\n" + dataAccess.Logout());
                    Pause();
                    return true;
            }
        }

        private static void Pause()
        {
            Console.WriteLine("\npress any key to exit the process...");
            Console.ReadKey();
        }
    }
}
