using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeShareProject.Frontend.Startup))]
namespace CodeShareProject.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
