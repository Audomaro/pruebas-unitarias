using Microsoft.Owin;

using Owin;

using Sistema.WebApiNinject.App_Start;

using System.Web.Http;

[assembly: OwinStartup(typeof(Sistema.WebApiNinject.Startup))]

namespace Sistema.WebApiNinject
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseNinject(() => NinjectConfig.CreateKernel());

            app.UseNinjectWebApi(config);

        }
    }
}
