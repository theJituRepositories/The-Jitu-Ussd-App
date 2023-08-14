using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_service
{
    public class UpdateCourse
    {
        private CourseService _courseService;

        public UpdateCourse(CourseService courseService)
        {
            _courseService = courseService;

            Console.WriteLine("Please enter the course id to update");
            var courseId = Console.ReadLine();

            // Retrieve the course to update
            var courseToUpdate = _courseService.GetCourseById(courseId);

            if (courseToUpdate == null)
            {
                Console.WriteLine("Course not found");
                return;
            }

            Console.WriteLine("Please enter the new course name");
            var courseName = Console.ReadLine();
            Console.WriteLine("Please enter the new course description");
            var courseDescription = Console.ReadLine();
            Console.WriteLine("Please enter the new course duration");
            var courseDuration = Console.ReadLine();
            Console.WriteLine("Please enter the new course price");
            var courseFeeString = Console.ReadLine();
            Console.WriteLine("Please enter the new course level (Beginner, Intermediate, Advanced)");
            var courseLevelString = Console.ReadLine();
            Console.WriteLine("Please enter the new course teacher (Jonathan, Daniel, Bellian, Jason, Aaron)");
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

            // Update the course
            courseToUpdate.CourseName = courseName;
            courseToUpdate.CourseDescription = courseDescription;
            courseToUpdate.CourseDuration = courseDuration;
            courseToUpdate.CourseFee = courseFee;
            courseToUpdate.Level = courseLevel;
            courseToUpdate.Teacher = courseTeacher;

            _courseService.UpdateCourse(courseId, courseToUpdate);


            Console.WriteLine("Course updated successfully");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            var admin = new AdminPanel();
            admin.Admin_menu();
        }
    }
}
