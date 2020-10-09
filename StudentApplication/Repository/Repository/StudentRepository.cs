using Data.Context;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
   public class StudentRepository:BaseRepository<Student> 
    {
       ////public Student getbyString(string s)
       //// {
       ////     using (var db=new context())
       ////     {
       ////         var student = db.students.Where(x => x.StudentEmail == s); 
       ////     }
       // //}
       // //public bool AddStudent(Student std)
       // //{
            
       // //        using (var DbContext = new context())
       // //        {
       // //            try
       // //            {
       // //                Student newstudent = new Student()
       // //                {
       // //                    Studentname=std.Studentname,
       // //                    StudentEmail=std.StudentEmail,
       // //                    PhoneNumber=std.PhoneNumber,
       // //                    DateOfBirth=std.DateOfBirth,
       // //                    Password=std.Password,
       // //                    ConfirmPawword=std.ConfirmPawword,
       // //                };
       // //                DbContext.students.Add(newstudent);
       // //                DbContext.SaveChanges();


       // //            }
       // //            catch (Exception e)
       // //            {
       // //                return false;
       // //            }
       // //        }

           
       // //    return true;
       // //}

       // public List<Student> getStudentList()
       // {
       //     using(var DbContext= new context())
       //     {
       //         try
       //         {

       //             var std = DbContext.students.ToList();
       //             if (std != null)
       //             {
       //                 return std;
       //             }
       //         }
       //         catch(Exception e)
       //         {
       //             return null;
       //         }
       //         return null;
       //     }
            
       // }

       // public bool deletestd(int stdid)
       // {
       //     using(var DbContext=new context())
       //     {
       //         try
       //         {
       //             var delstudent = DbContext.students.FirstOrDefault(s => s.StudentId == stdid);
       //             if (delstudent != null)
       //             {
       //                 DbContext.students.Remove(delstudent);
       //                 DbContext.SaveChanges();
       //                 return true;
       //             }
       //         }
       //         catch(Exception e)
       //         {
       //             return false;
       //         }
       //     }
       //     return false;
       // }

       // public bool updateStudent(Student upstudent, int stdId)
       // {
       //     using(var DbConetxt= new context())
       //     {
       //         try
       //         {
       //             var update = DbConetxt.students.FirstOrDefault(u => u.StudentId == stdId);
       //             if(update!=null)
       //             {
       //                 update.Studentname = upstudent.Studentname;
       //                 update.StudentEmail = upstudent.StudentEmail;
       //                 update.PhoneNumber = upstudent.PhoneNumber;
       //                 update.DateOfBirth = upstudent.DateOfBirth;
       //                 update.Password = upstudent.Password;
       //                 update.ConfirmPawword = upstudent.ConfirmPawword;
       //                 DbConetxt.SaveChanges();
       //                 return true;

       //             }
                   


       //         }
       //         catch(Exception e)
       //         {
       //             return false;
       //         }
       //     }
       //     return false;
       // }

       // public Student SearchStudent(int stdid)
       // {
       //     using(var DbConetxt=new context())
       //     {
       //         try { 
       //         var getStd = DbConetxt.students.FirstOrDefault(s => s.StudentId == stdid);
       //         if(getStd !=null)
       //         {
       //                 return getStd;
       //         }
       //     }
       //         catch(Exception e)
       //         {
       //             return null;
       //         }
       // }
       //     return null;
       // }



    }
}
