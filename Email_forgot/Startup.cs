using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Email_forgot.Startup))]
namespace Email_forgot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
