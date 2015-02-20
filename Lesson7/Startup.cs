using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lesson7.Startup))]
namespace Lesson7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
