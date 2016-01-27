using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormWeb.Startup))]
namespace FormWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
