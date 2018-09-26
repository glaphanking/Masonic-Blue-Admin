using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Masonic.Blue.Admin.Startup))]
namespace Masonic.Blue.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
