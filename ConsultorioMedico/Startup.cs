using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConsultorioMedico.Startup))]
namespace ConsultorioMedico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
