using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalesPlanningMonitorng.Startup))]
namespace SalesPlanningMonitorng
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
