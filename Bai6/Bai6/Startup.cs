using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bai6.Startup))]
namespace Bai6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
