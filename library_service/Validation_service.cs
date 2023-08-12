using System;
using System.IO;
using System.Linq;

namespace library_service
{
    public class Validation_service
    {
        private const string UsersFilePath = @"D:\c#\Jitu_Ssd\Users.txt";

        public bool IsValidInput(string user_name, string user_password)
        {
            if (string.IsNullOrWhiteSpace(user_name) || string.IsNullOrWhiteSpace(user_password))
            {
                Console.WriteLine("Username or password cannot be empty");
                return false;
            }
            return true;
        }

        public bool IsUserInFile(string user_name, string user_password)
        {
            var users = File.ReadAllLines(UsersFilePath)
                .Select(x => x.Split(','))
                .Select(x => new User_enums
                {
                    UserName = x[0],
                    UserPassword = x[1],
                    Role = (UserRole)Enum.Parse(typeof(UserRole), x[2])
                })
                .ToList();

            var user = users.FirstOrDefault(x => x.UserName == user_name && x.UserPassword == user_password);
            if (user == null)
            {
                Console.WriteLine("Username or password is incorrect");
                return false;
            }
            return true;
        }
    }
}