using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LemonWayChallenge
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Log4Net
            log4net.Config.XmlConfigurator.Configure();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
