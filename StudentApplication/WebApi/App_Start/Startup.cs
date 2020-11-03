using System;
using System.Threading.Tasks;
using DependanceInjection;
using IRepository.IRepository;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Owin;
using WebApi.Providers;

[assembly: OwinStartup(typeof(WebApi.App_Start.Startup))]

namespace WebApi.App_Start
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
       
        static Startup()
        {

            IKernel kernel = new StandardKernel(new NinjectBindings());
            var processor = kernel.Get<IUserRepository>();
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                
                TokenEndpointPath = new PathString("/Login"),
                Provider = new Provider(processor),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
                AllowInsecureHttp = true
            };
        }

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
