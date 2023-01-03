using Autofac;
using Autofac.Integration.WebApi;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Sistema.WebApiAutofac
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IContainer container)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            JsonFormatterConfig(config);
        }

        private static void JsonFormatterConfig(HttpConfiguration config)
        {
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
            };
        }
    }
}
