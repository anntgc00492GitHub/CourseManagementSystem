using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseManagementSystem.Web.Startup))]
namespace CourseManagementSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
