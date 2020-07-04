using IEMEDEBE.BusinessLogic;
using IEMEDEBE.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace IEMEDEBE.AdminWebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            var container = new UnityContainer();
            container.RegisterType<IUserLogic, UserLogic>();
            config.DependencyResolver = new UnityResolver(container);


            // Rutas de API web
            config.MapHttpAttributeRoutes();

        }
    }
}
