using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Geo.Itineraries.Web.Startup))]
namespace Geo.Itineraries.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
