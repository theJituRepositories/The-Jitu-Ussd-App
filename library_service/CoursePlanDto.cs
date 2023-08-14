using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_service
{
    public class CoursePlanDto
    {
        public string CourseName { get; set; }
        public string CourseId { get; set; }
        public string CourseDuration { get; set; }
        public int CourseFee { get; set; }
        public string CourseDescription { get; set; } 
        public CourseTeacher Teacher { get; set; }
        public Levels Level { get; set; }
    }
}
