using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_GUNLUK.Startup))]
namespace E_GUNLUK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
