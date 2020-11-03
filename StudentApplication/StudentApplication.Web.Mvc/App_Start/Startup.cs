using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using StudentApplication.Web.Mvc.Provider;

using System;

[assembly: OwinStartup(typeof(StudentApplication.Web.Mvc.Startup))]
namespace StudentApplication.Web.Mvc

{
   

    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Login"),
                Provider = new OAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
       
    }
}