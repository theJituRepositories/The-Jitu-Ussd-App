using System;
using System.Collections.Generic;

namespace library_service
{
    public class Analytics
    {
        private CourseService _courseService;

        public Analytics(CourseService courseService)
        {
            _courseService = courseService;
        }

        public void ViewAnalytics()
        {
            Console.WriteLine("Viewing Analytics");
            Console.WriteLine("Total Number of Courses: " + _courseService.GetTotalCourses());
            Console.WriteLine("Total Revenue: $" + _courseService.GetTotalRevenue());

            var courseTeacherCounts = _courseService.GetTeacherCourseCount();
            Console.WriteLine("Teacher-wise Course Count:");
            foreach (var teacherCount in courseTeacherCounts)
            {
                Console.WriteLine($"{teacherCount.Teacher}: {teacherCount.CourseCount}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            var admin = new AdminPanel();
            admin.Admin_menu();
        }
    }
}