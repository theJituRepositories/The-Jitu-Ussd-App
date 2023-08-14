using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace library_service
{
    public class CourseService
    {
        private List<CoursePlanDto> _coursePlan = new List<CoursePlanDto>();

        private const string AnalyticsFilePath = @"D:\c#\Jitu_Ssd\Analytics.txt";

        public CourseService()
        {
            _coursePlan = GetCoursePlan();
        }

        public List<CoursePlanDto> GetCoursePlan()
        {
            var coursePlan = new List<CoursePlanDto>();
            coursePlan.Add(new CoursePlanDto
            {
                CourseId = "1",
                CourseName = "C# Full Stack Development @ 50,000 ",
                CourseDuration = "5 months",
                CourseFee = 50000,
                CourseDescription = "C# is a programming language, Up to bottom, application and Placement",
                Level = Levels.Intermediate,
                Teacher = CourseTeacher.Jonathan
            });
            coursePlan.Add(new CoursePlanDto
            {
                CourseId = "2",
                CourseName = "JavaScript Full-Stack Development @40,000 ",
                CourseDuration = "3 months",
                CourseFee = 40000,
                CourseDescription = "The in an outs of javascript  as a programming language",
                Level = Levels.Intermediate,
                Teacher = CourseTeacher.Daniel
            });
            coursePlan.Add(new CoursePlanDto
            {
                CourseId = "3",
                CourseName = "QA/QE @20,000 ",
                CourseDuration = "3 months",
                CourseFee = 10000,
                CourseDescription = "Quality Assurance Engineering, Testing Systems Resilience",
                Level = Levels.Advanced,
                Teacher = CourseTeacher.Bellian
            });
            coursePlan.Add(new CoursePlanDto
            {
                CourseId = "4",
                CourseName = "WordPress Full Stack Development @30,000 ",
                CourseDuration = "3 months",
                CourseFee = 10000,
                CourseDescription = "Full stack WordPress development ",
                Level = Levels.Beginner,
                Teacher = CourseTeacher.Jason
            });
            coursePlan.Add(new CoursePlanDto
            {
                CourseId = "5",
                CourseName = "Application Security In and Out ",
                CourseDuration = "3 months",
                CourseFee = 90000,
                CourseDescription = "Cyber Security and defensive Programming",
                Level = Levels.Intermediate,
                Teacher = CourseTeacher.Aaron
            });
            // Add more course data here

            return coursePlan;
        }

        public void AddCourses(CoursePlanDto coursePlan)
        {
            _coursePlan.Add(coursePlan);
        }

        public bool DeleteCourse(string courseId)
        {
            var courseToDelete = _coursePlan.FirstOrDefault(c => c.CourseId == courseId);
            if (courseToDelete != null)
            {
                _coursePlan.Remove(courseToDelete);
                return true;
            }
            return false;
        }

        public void UpdateCourse(string courseId, CoursePlanDto updatedCourse)
        {
            var existingCourse = _coursePlan.Find(x => x.CourseId == courseId);
            if (existingCourse != null)
            {
                _coursePlan.Remove(existingCourse);
                _coursePlan.Add(updatedCourse);
            }
        }

        public void PurchaseCourse(string courseId)
        {
            var existingCourse = _coursePlan.Find(x => x.CourseId == courseId);
            if (existingCourse != null)
            {
                _coursePlan.Remove(existingCourse);
            }
        }


        public CoursePlanDto GetCourseById(string courseId)
        {
            return _coursePlan.Find(x => x.CourseId == courseId);
        }


        public int GetTotalCourses()
        {
            int totalCourses = _coursePlan.Count;
            SaveAnalytics($"Total Number of Courses: {totalCourses}");
            return totalCourses;
        }

        public decimal GetTotalRevenue()
        {
            decimal totalRevenue = _coursePlan.Sum(course => course.CourseFee);
            SaveAnalytics($"Total Revenue: ${totalRevenue}");
            return totalRevenue;
        }

        public List<TeacherCourseCountDto> GetTeacherCourseCount()
        {
            var teacherCourseCounts = new List<TeacherCourseCountDto>();

            foreach (var teacher in Enum.GetValues(typeof(CourseTeacher)))
            {
                int count = _coursePlan.Count(c => c.Teacher == (CourseTeacher)teacher);
                teacherCourseCounts.Add(new TeacherCourseCountDto
                {
                    Teacher = (CourseTeacher)teacher,
                    CourseCount = count
                });
            }

            foreach (var teacherCount in teacherCourseCounts)
            {
                SaveAnalytics($"{teacherCount.Teacher}: {teacherCount.CourseCount} courses");
            }

            return teacherCourseCounts;
        }

        private void SaveAnalytics(string data)
        {
            File.AppendAllText(AnalyticsFilePath, $"{DateTime.Now}: {data}\n");
        }
    }
}
