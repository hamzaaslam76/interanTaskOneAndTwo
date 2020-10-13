using Data.Context;
using Models.DataModels;
using Repository.DTOModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
namespace Repository.Repository
{
  public  class StudentRepositoryP: BaseRepository<Student>
    {
        
        public bool AddStudent(Student std, string courseId)
        {
            var courseList = courseId.Split(',').ToList();
            using (var DbContext = new context())
            {
                try
                {
                   var item= DbContext.AddStudentUsingStorProcedure(std.Studentname, std.StudentEmail, std.PhoneNumber, std.DateOfBirth, std.Password, std.ConfirmPawword,courseId);
                    //InsertModel(std);

                    foreach (var course in courseList)
                    {
                        DbContext.AddStudentCourcesUsingStorProcedure(Convert.ToInt32(course),(int) item );
                        // This Code Not Use Because I Am Using StoreProcedure

                        //StudentCourse stdCourse = new StudentCourse();
                        //stdCourse.StudentId = std.StudentId;
                        //stdCourse.CourseId = Convert.ToInt32(course);
                        //DbContext.studentCourses.Add(stdCourse);

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
        public List<FullStudentDto> GettAllStudents(Pager pager)
        {

            using (var DbContext = new context())
            {
                List<FullStudentDto> StudentList = new List<FullStudentDto>();
                try
                {
                    var studentes = (from s in DbContext.students
                                     select new FullStudentDto()
                                     {
                                         studentDto = s,
                                         StudentCourseCount = DbContext.studentCourses.Where(sc => sc.StudentId == s.StudentId).Count(),
                                     }).OrderBy(id => id.studentDto.StudentId).Skip(pager.start).Take(pager.length).ToList();
                    studentes[0].TotalRecord = DbContext.students.Count();
                    return studentes;
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
                        UpdateModel(UpdateStd);
                        var UpdateCourseId = DbConetxt.studentCourses.Where(sc => sc.StudentId == update.StudentId).ToList();
                        DbConetxt.studentCourses.RemoveRange(UpdateCourseId);
                        
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

        public bool DleteStudent(int id)
        {
            using(var DbContext=new context())
            {
               var Item= DbContext.DeleteStudentUsingStorProcedure(id);
                if(Item!=null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
