using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeShare.Frontend.Startup))]
namespace CodeShare.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
