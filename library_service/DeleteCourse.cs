using System;

namespace library_service
{
    public class DeleteCourse
    {
        private CourseService _courseService;

        public DeleteCourse(CourseService courseService)
        {
            _courseService = courseService;

            Console.WriteLine("Please enter the course id to delete");
            var courseId = Console.ReadLine();

            if (_courseService.DeleteCourse(courseId))
            {
                Console.WriteLine("Course deleted successfully");
            }
            else
            {
                Console.WriteLine("Course not found or unable to delete");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            var admin = new AdminPanel();
            admin.Admin_menu();
        }
    }
}