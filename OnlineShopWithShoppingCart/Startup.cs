using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OnlineShopWithShoppingCart.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShopWithShoppingCart.Startup))]
namespace OnlineShopWithShoppingCart
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdmin();
        }
        public void CreateAdmin()
        {
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "admin@gmail.com";
            user.UserName = "admin@gmail.com";
           
            var check = usermanger.Create(user, "123456789Admin@");
           
        }
    }
}
