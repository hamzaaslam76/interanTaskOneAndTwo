
using DtoLayer.DTOModel;
using IData;
using IRepository.IRepository;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Repository.Repository
{
    public class StudentRepositoryP : BaseRepository<Student>, IStudentRepository
    {
        private readonly  Icontext _icontext;
        public StudentRepositoryP(Icontext icontext):base(icontext)
        {
            _icontext = icontext;
        }
        
        public bool AddStudent(Student std, string courseId)
        {
            var courseList = courseId.Split(',').ToList();
           
                try
                {
                    // var item= DbContext.AddStudentUsingStorProcedure(std.Studentname, std.StudentEmail, std.PhoneNumber, std.DateOfBirth, std.Password, std.ConfirmPawword,courseId);
                    InsertModel(std);

                    foreach (var course in courseList)
                    {
                    //   DbContext.AddStudentCourcesUsingStorProcedure(Convert.ToInt32(course),(int) item );
                    // This Code Not Use Because I Am Using StoreProcedure

                    _icontext.studentCourses.Add(new StudentCourse
                        {
                            StudentId = std.StudentId,
                            CourseId = Convert.ToInt32(course)
                        });
                    }
                _icontext.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
        }
        public List<FullStudentDto> GettAllStudents(Pager pager)
        {

            
                List<FullStudentDto> StudentList = new List<FullStudentDto>();
                try
                {
                    var studentes = (from s in _icontext.students.Where(x => x.UserId == pager.UserId)
                                     select new FullStudentDto()
                                     {
                                         StudentId = s.StudentId,
                                         Studentname = s.Studentname,
                                         StudentEmail = s.StudentEmail,
                                         DateOfBirth = s.DateOfBirth,
                                         Password = s.Password,
                                         ConfirmPawword = s.ConfirmPawword,
                                         PhoneNumber = s.PhoneNumber,
                                         StudentCourseCount = _icontext.studentCourses.Where(sc => sc.StudentId == s.StudentId).Count(),
                                     }).OrderBy(x => x.StudentId).Skip(pager.start).Take(pager.length).ToList();
                    studentes[0].TotalRecord = _icontext.students.Count();
                    return studentes;
                }

                catch (Exception e)
                {
                    return null;
                }
            
        }
        public FullStudentDtoo SearchStudent(int stdid)
        {
             try
                {
                    var EditStd = (from s in _icontext.students.Where(x => x.StudentId == stdid)
                                   select new FullStudentDtoo
                                   {
                                       StudentId = s.StudentId,
                                       Studentname = s.Studentname,
                                       StudentEmail = s.StudentEmail,
                                       DateOfBirth = s.DateOfBirth,
                                       Password = s.Password,
                                       ConfirmPawword = s.ConfirmPawword,
                                       PhoneNumber = s.PhoneNumber,
                                       Listcourses = (from c in _icontext.courses select new CourseDto { CourseId = c.CourseId, CourseName = c.CourseName }).ToList(),
                                       StudentCourses = (from sc in _icontext.studentCourses
                                                         join c in _icontext.courses on sc.CourseId equals c.CourseId
                                                         where sc.StudentId == stdid
                                                         select new CourseDto
                                                         {
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
        public bool UpdateStudent(Student UpdateStd, string CourseArray)
        {
            var courseList = CourseArray.Split(',').ToList();
           
                try
                {
                    var update = _icontext.students.FirstOrDefault(u => u.StudentId == UpdateStd.StudentId);
                    if (update != null)
                    {
                        UpdateModel(UpdateStd);
                        var UpdateCourseId = _icontext.studentCourses.Where(sc => sc.StudentId == update.StudentId).ToList();
                    _icontext.studentCourses.RemoveRange(UpdateCourseId);

                        foreach (var CoursesId in courseList)
                        {

                        _icontext.studentCourses.Add(new StudentCourse
                            {
                                StudentId = update.StudentId,
                                CourseId = Convert.ToInt32(CoursesId)
                            });
                        }
                    _icontext.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            
            return false;
        }

        public bool DleteStudent(int id)
        {
            var Item = _icontext.DeleteStudentUsingStorProcedure(id);
            if (Item != null)
            {
                return true;
            }
            return false;
        }
    }
}
