
using Data.Context;
using Models.DataModels;
using Repository.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Repository.Repository
{
  public  class StudentRepositoryP: BaseRepository<Student>
    {
         public StudentRepositoryP()
        {
          
        }
        public bool AddStudent(Student std, string courseId)
        {
            var courseList = courseId.Split(',').ToList();
            using (var DbContext = new context())
            {
                try
                {

                    InsertModel(std);
                   
                    foreach (var course in courseList)
                    {
                        StudentCourse stdCourse = new StudentCourse();
                        stdCourse.StudentId = std.StudentId;
                        stdCourse.CourseId = Convert.ToInt32(course);
                        DbContext.studentCourses.Add(stdCourse);
                       
                    }
                    DbContext.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            
        }

        public List<FullStudentDto> GettAllStudents()
        {

            using (var DbContext = new context())
            {
                List<FullStudentDto> StudentList = new List<FullStudentDto>();
                try
                {
                    var studentss = (from s in DbContext.students
                                     select new FullStudentDto()
                                     {
                                         studentDto = s,
                                         StudentCourseCount = DbContext.studentCourses.Where(sc => sc.StudentId == s.StudentId).Count(),
                                     }
                                   ).ToList();
                    return studentss;
                }
                 
                catch (Exception e)
                {
                    return null;
                }   
            }
        }
        public FullStudentDtoo SearchStudent(int stdid)
        {
            using (var DbConetxt = new context())
            {
                try
                {
                  //  List<CourseDto> AllCources = new List<CourseDto>();
                  // Course  AllCources = (from c in DbConetxt.courses select c);
                    var EditStd = (from s in DbConetxt.students.Where(x => x.StudentId == stdid)
                                   select new FullStudentDtoo
                                   {

                                       studentDto = s,
                                       Listcourses = (from c in DbConetxt.courses select new CourseDto {CourseId =c.CourseId,CourseName=c.CourseName }).ToList(),
                                       StudentCourses = (from sc in DbConetxt.studentCourses
                                                         join c in DbConetxt.courses on sc.CourseId equals c.CourseId
                                                         where sc.StudentId == stdid
                                                         select new CourseDto {
                                                             CourseId = sc.CourseId,
                                                             CourseName = c.CourseName

                                                         }).ToList()
                                   }).FirstOrDefault();                      
                                  
                    return EditStd;
                }
                catch (Exception e)
                {
                    return null;
                }
            }  
        }
        public bool UpdateStudent(Student UpdateStd, string CourseArray)
        {
            var courseList = CourseArray.Split(',').ToList();
            using (var DbConetxt = new context())
            {
                try
                {
                    var update = DbConetxt.students.FirstOrDefault(u => u.StudentId == UpdateStd.StudentId);
                    if (update != null)
                    {
                        UpdateModel(update);
                        var UpdateCourseId = DbConetxt.studentCourses.Where(sc => sc.StudentId == update.StudentId).ToList();
                        foreach (var Item in UpdateCourseId)
                        {
                            DbConetxt.studentCourses.Remove(Item);

                        }   
                        foreach (var CoursesId in courseList)
                        {
                           
                            StudentCourse stdCourse = new StudentCourse();
                            stdCourse.StudentId = update.StudentId;
                            stdCourse.CourseId = Convert.ToInt32(CoursesId);
                            DbConetxt.studentCourses.Add(stdCourse);
                        }
                        DbConetxt.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
