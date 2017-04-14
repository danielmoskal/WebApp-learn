using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(drugaApka.Startup))]
namespace drugaApka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}