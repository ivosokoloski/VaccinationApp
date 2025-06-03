using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VaccinationApp.Startup))]
namespace VaccinationApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
