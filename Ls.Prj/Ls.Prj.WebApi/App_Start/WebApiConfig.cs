using Ls.Prj.WebApi.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Ls.Prj.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            PrjOdataModelBuilder builder = new PrjOdataModelBuilder();
            //builder.EntitySet<Categorie>("Categories");
            //builder.EntitySet<Prodotti>("Prodottis");

            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


            //// Web API configuration and services

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
