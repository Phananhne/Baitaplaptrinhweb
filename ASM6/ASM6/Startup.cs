using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASM6.Startup))]
namespace ASM6
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
