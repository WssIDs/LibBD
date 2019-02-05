using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibDB.Startup))]
namespace LibDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
