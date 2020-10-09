
using Models.DataModels;
using System.Collections.Generic;

namespace Repository.DTOModel
{
   public class StudentDto
    {
        public int StudentId { get; set; }
        public string Studentname { get; set; }
        public string StudentEmail { get; set; }

        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public string ConfirmPawword { get; set; }
     

    }
    public class FullStudentDto
    { 
        public Student studentDto { get; set; }
       public int StudentCourseCount { get; set; }
    }

    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
    public class FullStudentDtoo
    {
        public Student studentDto { get; set; }
        public List<CourseDto> Listcourses { get; set; }
        public List<CourseDto> StudentCourses { get; set; }
    }

}
