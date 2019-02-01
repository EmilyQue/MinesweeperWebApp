using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinesweeperWeb.Startup))]
namespace MinesweeperWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
