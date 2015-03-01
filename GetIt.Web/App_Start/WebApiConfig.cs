using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace GetIt.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Default to returning json to browser unless text/xml is specifically requested.
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "ShoppingListsApi",
                routeTemplate: "api/shoppinglists/{id}",
                defaults: new {controller = "ShoppingLists", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ShoppingItemsApi",
                routeTemplate: "api/shoppingitems/{id}",
                defaults: new { controller = "ShoppingItems", id = RouteParameter.Optional }
            );

        }
    }
}
