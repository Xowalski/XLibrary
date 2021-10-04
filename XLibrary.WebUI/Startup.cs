using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XLibrary.WebUI.Startup))]
namespace XLibrary.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
