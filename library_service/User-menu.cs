using System;
using System.IO;

namespace library_service
{
    public class User_menu
    {
        public void UserMenu()
        {
            Console.WriteLine("Welcome to Jitu - A New Haven for Techies");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    var login = new Login_service();
                    login.Login();
                    break;
                case "2":
                    var register = new Registration_service();
                    register.RegisterUsers();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
           
        }
    }
}