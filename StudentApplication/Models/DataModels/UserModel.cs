
namespace Models.DataModels
{
   public  class User
    { 
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string Title { get; set; }
    }
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
