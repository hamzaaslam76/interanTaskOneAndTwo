using System.Collections.Generic;
namespace DtoLayer.DTOModel
{
   public class StudentDto
    {
        public int StudentId { get; set; }
        public string Studentname { get; set; }
        public string StudentEmail { get; set; }

        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ConfirmPawword { get; set; }
        public int UserId { get; set; }
    }
    public class FullStudentDto:StudentDto
    { 
       // public StudentDto studentDto { get; set; }
       public int StudentCourseCount { get; set; }
        public int TotalRecord { get; set; }
        public List<CourseDto> ListStudentCourses { get; set; }
    }

    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
    public class FullStudentDtoo:StudentDto
    {
       // public Student studentDto { get; set; }
        public List<CourseDto> Listcourses { get; set; }
        public List<CourseDto> StudentCourses { get; set; }
    }

}
