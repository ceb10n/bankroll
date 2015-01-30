using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bankroll.Startup))]
namespace bankroll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
