using System;

namespace library_service
{
    public class AddCourses
    {
        private CourseService _courseService;

        public AddCourses(CourseService courseService)
        {
            _courseService = courseService;

            Console.WriteLine("Please enter the course id");
            var courseId = Console.ReadLine();
            Console.WriteLine("Please enter the course name");
            var courseName = Console.ReadLine();
            Console.WriteLine("Please enter the course description");
            var courseDescription = Console.ReadLine();
            Console.WriteLine("Please enter the course duration");
            var courseDuration = Console.ReadLine();
            Console.WriteLine("Please enter the course price");
            var courseFeeString = Console.ReadLine();
            Console.WriteLine("Please enter the course level (Beginner, Intermediate, Advanced)");
            var courseLevelString = Console.ReadLine();
            Console.WriteLine("Please enter the course teacher (Jonathan, Daniel, Bellian, Jason, Aaron)");
            var courseTeacherString = Console.ReadLine();

            if (!int.TryParse(courseFeeString, out int courseFee))
            {
                Console.WriteLine("Invalid course fee");
                return;
            }

            if (!Enum.TryParse(courseLevelString, out Levels courseLevel))
            {
                Console.WriteLine("Invalid course level");
                return;
            }

            if (!Enum.TryParse(courseTeacherString, out CourseTeacher courseTeacher))
            {
                Console.WriteLine("Invalid course teacher");
                return;
            }

            var course = new CoursePlanDto
            {
                CourseName = courseName,
                CourseDescription = courseDescription,
                CourseDuration = courseDuration,
                CourseFee = courseFee,
                Level = courseLevel,
                Teacher = courseTeacher,
                CourseId = courseId
            };

            _courseService.AddCourses(course);
            Add();
        }

        private void Add()
        {
            Console.WriteLine("Course added successfully");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            var admin = new AdminPanel();
            admin.Admin_menu();
        }
    }
}
