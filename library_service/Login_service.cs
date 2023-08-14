using System;
using System.IO;

namespace library_service
{
    public class Login_service
    {
        private const string UsersFilePath = @"D:\c#\Jitu_Ssd\Users.txt";

        public void Login()
        {
            Console.WriteLine("Login as?");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. User");

            var loginAs = Console.ReadLine();
            if (loginAs == "1")
            {
                LoginAsAdmin();
            }

            else if (loginAs == "2")
            {
                LoginAsUser();
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        private void LoginAsAdmin()
        {
            Console.Write("Enter the Admin name: ");
            var admin_name = Console.ReadLine();
            Console.Write("Enter the Admin password: ");
            var admin_password = Console.ReadLine();

            var validationService = new Validation_service();
            if (validationService.IsValidInput(admin_name, admin_password) &&
                validationService.isAdminExist(admin_name, admin_password))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login successful.");
                // Display the admin panel
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Admin_menu();

            }
            else
            {
                Console.WriteLine("Login failed.");
            }


        }

        private void LoginAsUser()
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
                Console.WriteLine("Login successful.");
                // Display the courses
                DisplayCourses display = new DisplayCourses();
                display.Display();
            }
            else
            {
                Console.WriteLine("Login failed.");
            }
        }
    }
}
