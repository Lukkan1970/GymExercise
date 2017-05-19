using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gymbokningv0._1.Startup))]
namespace Gymbokningv0._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
