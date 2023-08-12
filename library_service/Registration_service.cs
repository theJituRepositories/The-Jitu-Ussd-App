using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace library_service
{
    public class Registration_service
    {
        private const string UsersFilePath = @"D:\c#\Jitu_Ssd\Users.txt";

        public void RegisterUsers()
        {
            Console.Write("Enter user name: ");
            var user_name = Console.ReadLine();

            Console.Write("Enter user password: ");
            var user_password = Console.ReadLine();
            Console.WriteLine("Register as:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");

            var roleOption = Console.ReadLine();
            UserRole role = UserRole.User; // Default role is User

            if (roleOption == "1")
            {
                role = UserRole.Admin;
            }

            var user = new User_enums
            {
                UserName = user_name,
                UserPassword = user_password,
                Role = role
            };

            var userLine = $"{user.UserName},{user.UserPassword},{user.Role}";
            if (File.Exists(UsersFilePath))
            {
                File.AppendAllLines(UsersFilePath, new List<string> { userLine });
            }
            else
            {
                File.WriteAllText(UsersFilePath, userLine);
            }

            Console.WriteLine("User successfully registered.");
            Console.WriteLine("Please Login To Access Our Services ");

            // Call the Login_service to start the login action
            var loginService = new Login_service();
            loginService.Login();
        }
    }
}