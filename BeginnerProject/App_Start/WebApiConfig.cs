using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BeginnerProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //linea para enviar todos los controllers en json serializado
            var formmater = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formmater.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();



        }

    }
}
