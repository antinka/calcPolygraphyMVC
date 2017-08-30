using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(calculator.Startup))]
namespace calculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
