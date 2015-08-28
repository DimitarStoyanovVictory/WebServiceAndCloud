using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Problem01.BlogSystemApplicationWeb.Startup))]

namespace Problem01.BlogSystemApplicationWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
