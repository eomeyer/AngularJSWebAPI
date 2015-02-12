using AngularJSWebAPI.Entities;
using AngularJSWebAPI.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
            
namespace AngularJSWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Country>("Countries");
            builder.EntitySet<Continent>("Continents"); 
            //config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
            config.MapODataServiceRoute("ODataRoute","odata",builder.GetEdmModel());

        }
    }
}
