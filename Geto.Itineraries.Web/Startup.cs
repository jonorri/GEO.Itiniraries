using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Geto.Itineraries.Web.Startup))]
namespace Geto.Itineraries.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
