using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Administrador.Startup))]
namespace Administrador
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
