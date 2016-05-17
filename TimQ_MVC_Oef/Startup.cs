using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimQ_MVC_Oef.Startup))]
namespace TimQ_MVC_Oef
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
