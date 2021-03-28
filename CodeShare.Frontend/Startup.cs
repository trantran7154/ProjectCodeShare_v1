using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartupAttribute(typeof(CodeShare.Frontend.Startup))]
namespace CodeShare.Frontend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }
    }
}
