using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormosBar.Startup))]
namespace FormosBar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
