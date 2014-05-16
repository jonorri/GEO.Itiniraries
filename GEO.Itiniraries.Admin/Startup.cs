using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GEO.Itiniraries.Admin.Startup))]
namespace GEO.Itiniraries.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
