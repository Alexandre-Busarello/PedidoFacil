using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PedidoFacil.MVC.Startup))]
namespace PedidoFacil.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
