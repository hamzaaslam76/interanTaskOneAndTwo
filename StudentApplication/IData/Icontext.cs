using Models.DataModels;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
namespace IData
{
    public interface Icontext
    {
        DbSet<Course> courses { get; set; }
        DbSet<Role> roles { get; set; }
        DbSet<StudentCourse> studentCourses { get; set; }
        DbSet<Student> students { get; set; }
        DbSet<UserRole> userRoles { get; set; }
        DbSet<User> users { get; set; }
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T>Entry<T>(T entity)where T : class;
        int SaveChanges();
        void AddStudentCourcesUsingStorProcedure(int CourseId, int StudentId);
        decimal AddStudentUsingStorProcedure(string StudentName, string StudentEmail, string PhoneNumber, string DateOfBirth, string Password, string ConfirmPawword, string list);
        ObjectResult<int> DeleteStudentUsingStorProcedure(int StudentId);
        ObjectResult<Student> GetStudentUsingStorProcedure();
    }
}
