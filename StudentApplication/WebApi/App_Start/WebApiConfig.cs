using DependanceInjection;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Modules;
using System.Collections.Generic;
using System.Web.Http;
using WebApiContrib.IoC.Ninject;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static StandardKernel Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
            var kernal = new StandardKernel();
            Register(config,kernal);
            return kernal;
        }
        public static void Register(HttpConfiguration config,IKernel kernel)
        {
           
            var modules = new List<INinjectModule>
            {
              new NinjectBindings()
            };
            kernel.Load(modules);
            config.DependencyResolver = new NinjectResolver(kernel);
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));
            //EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);

            
        }
    }
}
