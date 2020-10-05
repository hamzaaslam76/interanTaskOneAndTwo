using ControlzEx.Standard;
using Data.Context;
using Models.DataModels;
using Repository.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Repository
{
  public  class StudentRepositoryP: BaseRepository<Student>
    {
        // private StudentRepositoryP StudentRepositoryp;
        public bool AddStudent(Student std, string courseId)
        {
            var courseList = courseId.Split(',').ToList();
            using (var DbContext = new context())
            {
                try
                {
                   
                    InsertModel(std);
                    StudentCourse stdCourse = new StudentCourse();
                    stdCourse.StudentId = std.StudentId;
                    foreach (var course in courseList)
                    {
                        stdCourse.CourseId =Convert.ToInt32(course);
                        DbContext.studentCourses.Add(stdCourse);
                        DbContext.SaveChanges();
                    }
                    DbContext.SaveChanges();


                }
                catch (Exception e)
                {
                    return false;
                }
            }


            return true;
        }

        public List<StudentDto> GettAllStudents()
        {
          
            using (var DbContext = new context())
            {
                try
                {
                    var students = (from s in DbContext.students
                                    join sc in DbContext.studentCourses on s.StudentId equals sc.StudentId
                                    group s by s.Studentname into grouped
                                    select (new StudentDto())
                                   
                                    ).ToList();
                    
                    
                   

                }
                catch (Exception e)
                {
                    
                }
            }


            return true;
        }

    }
}
