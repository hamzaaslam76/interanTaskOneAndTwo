using DtoLayer.DTOModel;
using IData;
using IRepository.IRepository;
using System.Linq;
namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Icontext _icontext;
        public UserRepository(Icontext icontext)
        {
            _icontext = icontext;
        }
        public FullUserDto ValidateUser(string userEmail, string Password)
        {
                var user = _icontext.users.FirstOrDefault(u => u.Email == userEmail && u.Password == Password);
                if (user != null)
                {
                    return new FullUserDto
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        Email = userEmail,
                        roleDto = (from ur in _icontext.userRoles
                                   join r in _icontext.roles on ur.RoleId equals r.RoleId
                                   where ur.UserId == user.UserId
                                   select new RoleDto { Title = r.Title }).ToList(),
                    };
                }
                return null;   
        }
    }
}
