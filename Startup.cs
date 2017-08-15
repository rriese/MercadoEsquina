using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MercadoEsquina.Startup))]
namespace MercadoEsquina
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
