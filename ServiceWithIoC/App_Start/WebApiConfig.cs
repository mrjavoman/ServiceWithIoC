﻿using Microsoft.Practices.Unity;
using ServiceWithIoC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Tracing;

namespace ServiceWithIoC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ITestRepository, TestRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.EnableSystemDiagnosticsTracing();

            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            config.Services.Replace(typeof(ITraceWriter), new TraceWriter());

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
