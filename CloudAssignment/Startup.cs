using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloudAssignment.Startup))]
namespace CloudAssignment
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
