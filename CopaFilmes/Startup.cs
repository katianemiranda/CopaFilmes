using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CopaFilmes.Startup))]
namespace CopaFilmes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
