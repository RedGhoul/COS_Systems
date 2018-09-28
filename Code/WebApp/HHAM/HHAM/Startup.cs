using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HHAM.Startup))]
namespace HHAM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
