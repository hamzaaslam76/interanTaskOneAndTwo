using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApi.App_Start;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // ControllerBuilder.Current.SetControllerFactory(new NinjectConlrollerFactory());
          //  GlobalConfiguration.Configure(WebApiConfig.Register);
          //  AreaRegistration.RegisterAllAreas();
           var kernal= WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
