using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CARMEN_PORTAFOLIO.Startup))]
namespace CARMEN_PORTAFOLIO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
