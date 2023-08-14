using System;
using System.Collections.Generic;
using System.Linq;

namespace library_service
{
    public class DisplayCourses
    {
        private List<CoursePlanDto> _coursePlan = new List<CoursePlanDto>();
        private CourseService _courseService = new CourseService();
        private int CurrentBalance = 150000;

        public DisplayCourses()
        {
            _coursePlan = _courseService.GetCoursePlan();
        }

        public void Display()
        {
            Console.WriteLine("The great courses we provide here are all inclusive:");
            Console.WriteLine("This are in Levels depending on the way up! Welcome");
            Console.WriteLine("1. Beginner");
            Console.WriteLine("2. Intermediate");
            Console.WriteLine("3. Advanced");

            // Display courses from user input
            Console.WriteLine("Please pick your Level");
            var levels = Console.ReadLine().Split(',');

            foreach (Levels level in Enum.GetValues(typeof(Levels)))
            {
                if (!levels.Contains(((int)level).ToString()))
                {
                    continue;
                }

                var coursesInLevel = _coursePlan.FindAll(x => x.Level == level);
                var teacherName = coursesInLevel.FirstOrDefault()?.Teacher.ToString();

                Console.WriteLine($"{(int)level}. {level} courses with {teacherName} teacher:");

                foreach (var course in coursesInLevel)
                {
                    Console.WriteLine($"  - {course.CourseId}: {course.CourseName} - {course.CourseDescription} \n -  {course.CourseFee} - {course.CourseDuration}");
                }
            }

            // Select a course for purchase
            Console.WriteLine("Enter the Course Id you want to purchase:");
            var courseId = Console.ReadLine();

            var selectedCourse = _coursePlan.FirstOrDefault(course => course.CourseId == courseId);

            if (selectedCourse == null)
            {
                Console.WriteLine("Invalid Course Id.");
                return;
            }

            Console.WriteLine($"Selected Course: {selectedCourse.CourseName}");

            // Initialize the PurchaseCourse class and call its Purchase method
            var purchaseCourse = new PurchaseCourse(_courseService, CurrentBalance);
            purchaseCourse.Purchase(selectedCourse);
        }
    }
}
