﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WeudreYZukowski
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "API/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
