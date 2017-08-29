using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Webshop.Web.Startup))]
namespace Webshop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ;
        }
    }
}