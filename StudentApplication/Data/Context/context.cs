using IData;
using Models.DataModels;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
namespace Data.Context
{
    public class context : DbContext, Icontext
    {
        public context() : base("StudentConnactionString")
        {

        }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentCourse> studentCourses { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public virtual decimal AddStudentUsingStorProcedure(string StudentName, string StudentEmail, string PhoneNumber, string DateOfBirth, string Password, string ConfirmPawword, String list)
        {
            var name = new SqlParameter("@StudentName", StudentName);
            var email = new SqlParameter("@StudentEmail", StudentEmail);
            var phone = new SqlParameter("@PhoneNumber", PhoneNumber);
            var dateofbirth = new SqlParameter("@DateOfBirth", DateOfBirth);
            var password = new SqlParameter("@Password", Password);
            var conpassword = new SqlParameter("@ConfirmPawword", ConfirmPawword);
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<decimal>("AddStudent @StudentName,@StudentEmail,@PhoneNumber,@DateOfBirth,@Password,@ConfirmPawword,@UserId ", name, email, phone, dateofbirth, password, conpassword).First();
        }
        public virtual void AddStudentCourcesUsingStorProcedure(int CourseId, int StudentId)
        {
            var cid = new SqlParameter("@CourseId", CourseId);
            var sid = new SqlParameter("@StudentId", StudentId);
            ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<decimal>("AddStudentCources @CourseId,@StudentId", cid, sid).First();
        }
        public virtual ObjectResult<int> DeleteStudentUsingStorProcedure(int StudentId)
        {
            var id = new SqlParameter("@StudentId", StudentId);
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<int>("DeleteStudent @StudentId ", id);
        }
        public virtual ObjectResult<Student> GetStudentUsingStorProcedure()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<Student>("SelectAllStudent");
        }
        public void saveChanging()
        {
            context c = new context();
            c.SaveChanges();
        }
    }
}
