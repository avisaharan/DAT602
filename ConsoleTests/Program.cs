using System;
using SnakeAndLadders;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        private static void UserRegistration()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Registration");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserRegistration("Fred", "1234", "fred@emailaddress.com"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserLogin()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Login");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserLogin("Xavier", "1234"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserLogout()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Logout");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserLogout("7"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserDelete()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Delete");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserDelete("Tom", "1234"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void NewQuest()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting New Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.NewQuest(7, "Xavs Super Quest"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void JoinQuest()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Join Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.JoinQuest(10, 2));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserMove()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Move");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.UserMove(2, 3, 1, 2));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void UserChat()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting User Chat");
            Console.WriteLine("=================================================");
            Console.WriteLine("Chat = " + dataAccess.UserChat(1, 1, "I love WizardQuest!"));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void LeaveQuest()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Leave Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.LeaveQuest(1, 1));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorAdd()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Adds User");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorAdd("Jen", "1234", "jen@emailaddress.com", false));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorModify()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Modifies User");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorModify(3, "Sally", "1234", "sally@emailaddress.com", 0, false, true, 1000));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorDelete()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Deletes User");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorDelete(10));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void AdministratorKill()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Administrator Kills Quest");
            Console.WriteLine("=================================================");
            Console.WriteLine("Result = " + dataAccess.AdministratorKill(1));
            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void GetAllUsers()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Get All Users");
            Console.WriteLine("=================================================");
            Console.WriteLine("\tUsername");
            Console.WriteLine("-------------------------------------------------");

            foreach (var parameter in dataAccess.GetAllUsers())
            {
                Console.WriteLine("\t" + parameter.UserName);
            }

            Console.WriteLine("-------------------------------------------------");
            Pause();
        }
        private static void GetHighScores()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Get High Scores");
            Console.WriteLine("=================================================");
            Console.WriteLine("\tUsername \t\t Total Score");
            Console.WriteLine("-------------------------------------------------");

            foreach (var parameter in dataAccess.GetHighScores())
            {
                Console.WriteLine("\t" + parameter.UserName + " \t\t\t " + parameter.TotalScore);
            }

            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void GetUserInventory()
        {
            DataAccess dataAccess = new DataAccess();

            Console.WriteLine("\nTesting Get User Inventory");
            Console.WriteLine("=================================================");
            Console.WriteLine("\tItem \t\t\tQuantity");
            Console.WriteLine("-------------------------------------------------");

            foreach (var parameter in dataAccess.GetUserInventory(2))
            {
                Console.WriteLine("\t" + parameter.Item + " \t\t    " + parameter.Quantity);
            }

            Console.WriteLine("-------------------------------------------------");
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine("\npress any key to exit the process...");
            Console.ReadKey();
        }
    }
}