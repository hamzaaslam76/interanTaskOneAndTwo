using Data.Context;
using IData;
using IRepository.IRepository;
using Ninject.Modules;
using Repository.Repository;
namespace DependanceInjection
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IStudentRepository>().To<StudentRepositoryP>();
            Bind<Icontext>().To<context>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ICourseRepository>().To<CourseRepository>();
        }
    }
}
