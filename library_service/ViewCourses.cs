using System;

namespace library_service
{
    public class ViewCourses
    {
        public ViewCourses()
        {
            Console.WriteLine("Would you like to view the courses we provide:");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    var display = new DisplayCourses();
                    display.Display();
                    break;
                case "2":
                    var admin = new AdminPanel();
                    admin.Admin_menu();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}