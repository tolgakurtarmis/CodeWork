using AutoMapper;
using CodeWork.Business.DependencyResolvers.Ninject;
using CodeWork.Business.Mapping;
using CodeWork.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CodeWork
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
    }
}
