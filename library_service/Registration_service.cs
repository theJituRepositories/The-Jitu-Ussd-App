using System;
using System.Collections.Generic;
using System.IO;

namespace library_service
{
    public class Registration_service
    {
        private const string UsersFilePath = @"D:\c#\Jitu_Ssd\Users.txt";

        public void RegisterUsers()
        {
            Console.WriteLine("Welcome to the Jitu Services 🎉 :");
            Console.WriteLine("Register as:");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");

            UserRole role = UserRole.User;
            var roleOption = Console.ReadLine();
            if (roleOption != null && roleOption == "1")
            {
                role = UserRole.Admin;
            }
            else if (roleOption != null && roleOption == "2")
            {
                role = UserRole.User;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }

            string userName = null;
            string userPassword = null;
            string adminName = null;
            string adminPassword = null;

            if (role == UserRole.User)
            {
                Console.WriteLine("Be careful to enter correct user details:");
                Console.Write("Enter the User name: ");
                userName = Console.ReadLine();
                Console.Write("Enter the User password: ");
                userPassword = Console.ReadLine();
                Console.WriteLine("Successfully registered as a user.");
                Console.WriteLine("Login to access the user panel.");
            }
            else if (role == UserRole.Admin)
            {
                Console.WriteLine("Be careful to enter correct admin details:");
                Console.Write("Enter the Admin name: ");
                adminName = Console.ReadLine();
                Console.Write("Enter the Admin password: ");
                adminPassword = Console.ReadLine();
                Console.WriteLine("Successfully registered as an admin.");
                Console.WriteLine("Login to access the admin panel.");
            }

            var user = new User_enums
            {
                UserName = userName,
                UserPassword = userPassword,
                Role = role
            };

            var admin = new User_enums
            {
                UserName = adminName,
                UserPassword = adminPassword,
                Role = role
            };

            var userLine = $"{user.UserName},{user.UserPassword},{user.Role}";
            var adminLine = $"{admin.UserName},{admin.UserPassword},{admin.Role}";

            if (File.Exists(UsersFilePath))
            {
                File.AppendAllLines(UsersFilePath, new List<string> { userLine, adminLine });
            }
            else
            {
                File.WriteAllLines(UsersFilePath, new List<string> { userLine, adminLine });
            }

            Console.WriteLine("User successfully registered.");
            Console.WriteLine("Please Login To Access Our Services ");

            var loginService = new Login_service();
            loginService.Login();
        }
    }
}
