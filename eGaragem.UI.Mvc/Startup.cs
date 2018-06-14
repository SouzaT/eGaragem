using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eGaragem.UI.Mvc.Startup))]
namespace eGaragem.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
