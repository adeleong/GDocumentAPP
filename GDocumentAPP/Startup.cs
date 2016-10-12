using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GDocumentAPP.Startup))]
namespace GDocumentAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
