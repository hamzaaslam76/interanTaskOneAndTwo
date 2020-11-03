using DependanceInjection;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApi.App_Start
{
    public class NinjectConlrollerFactory:DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectConlrollerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            var modules = new List<INinjectModule>
        {
        new NinjectBindings()
     
        };
            _ninjectKernel.Load(modules);

        }
        }
}
