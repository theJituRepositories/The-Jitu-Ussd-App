using System;

namespace library_service
{
    public class AdminPanel
    {
        public void Admin_menu()
        {
            Console.WriteLine("Welcome to the admin panel. How would you like to proceed?");
            Console.WriteLine("1. View Courses");
            Console.WriteLine("2. Add a Course");
            Console.WriteLine("3. Delete a Course");
            Console.WriteLine("4. Update a Course");
            Console.WriteLine("5. View Analytics");
            Console.WriteLine("6. Exit");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    var view = new ViewCourses();
                    break;
                case "2":
                    var add = new AddCourses(new CourseService());
                    break;
                case "3":
                    var delete = new DeleteCourse(new CourseService());
                    break;
                case "4":
                    var update = new UpdateCourse(new CourseService());
                    break;
                case "5":
                    var analytics = new Analytics(new CourseService());
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}