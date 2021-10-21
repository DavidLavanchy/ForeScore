using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForeScore.WebMVC.Startup))]
namespace ForeScore.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
