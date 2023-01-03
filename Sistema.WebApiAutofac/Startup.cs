using Autofac;

using Microsoft.Owin;

using Owin;

using Sistema.WebApiAutofac.App_Start;

using System.Web.Http;


[assembly: OwinStartup(typeof(Sistema.WebApiAutofac.Startup))]

namespace Sistema.WebApiAutofac
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            IContainer container = AutofacConfig.CreateContainer();

            WebApiConfig.Register(config, container);

            app.UseAutofacMiddleware(container);

            app.UseAutofacWebApi(config);

            app.UseWebApi(config);
        }
    }
}
