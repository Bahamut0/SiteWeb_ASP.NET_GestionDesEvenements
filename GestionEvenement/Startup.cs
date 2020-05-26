using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionEvenement.Startup))]
namespace GestionEvenement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
