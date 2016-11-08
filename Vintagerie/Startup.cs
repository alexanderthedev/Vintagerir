using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vintagerie.Startup))]
namespace Vintagerie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
