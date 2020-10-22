using DtoLayer.DTOModel;
namespace IRepository.IRepository
{
    public interface IUserRepository
    {
        FullUserDto ValidateUser(string userEmail, string Password);
    }
}
