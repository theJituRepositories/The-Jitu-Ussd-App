using System;
using System.IO;
using System.Linq;

namespace library_service
{
    public class Login_service
    {
        private const string UsersFilePath = @"D:\c#\Jitu_Ssd\Users.txt";

        public void Login()
        {
            Console.Write("Enter user name: ");
            var user_name = Console.ReadLine();

            Console.Write("Enter user password: ");
            var user_password = Console.ReadLine();

            var validationService = new Validation_service();
            if (validationService.IsValidInput(user_name, user_password) &&
                validationService.IsUserInFile(user_name, user_password))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        }
    }
}