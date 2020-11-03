//using Microsoft.Owin;
//using Microsoft.Owin.Security.OAuth;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace StudentApplication.WebMvc.App_Start
//{
//    public partial class Startup
//    {
//        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

//        static Startup()
//        {
//            OAuthOptions = new OAuthAuthorizationServerOptions
//            {
//                TokenEndpointPath = new PathString("/Login"),
//                Provider = new OAuthProvider(),
//                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
//                AllowInsecureHttp = true
//            };
//        }
//        public void ConfigureAuth(IAppBuilder app)
//        {
//            app.UseOAuthBearerTokens(OAuthOptions);
//        }
//    }
//}