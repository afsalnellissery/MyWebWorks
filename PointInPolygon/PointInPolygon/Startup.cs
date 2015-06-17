using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PointInPolygon.Startup))]
namespace PointInPolygon
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
