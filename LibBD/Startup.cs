using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibBD.Startup))]
namespace LibBD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
