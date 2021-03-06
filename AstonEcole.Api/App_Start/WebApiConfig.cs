﻿using AstonEcole.Api.Infrastructure;
using AstonEcole.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AstonEcole.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            config.Formatters.Add(new CsvMediaTypeFormatter<Student>());
            config.EnableCors();

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling 
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}