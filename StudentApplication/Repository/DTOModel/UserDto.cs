using System;
using System.Collections.Generic;
namespace Repository.DTOModel
{
   public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string Title { get; set; }
    }
    public class FullUserDto : UserDto
    {
       public List<RoleDto> roleDto { get; set; }
    }
}
