using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Courses { get; set; }
        public int StudentId { get; set; }
        public virtual Student Students { get; set; }
    }
}
