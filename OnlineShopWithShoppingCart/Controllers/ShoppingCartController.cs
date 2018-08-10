using OnlineShopWithShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopWithShoppingCart.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        private int IsExist(int id)
        {
            List<Item> cart = (List<Item>)Session["Cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Pr.Id == id)
                    return i;
            return -1;
        }
        public ActionResult Delete(int id)
        {
            int Index = IsExist(id);
            List<Item> cart = (List<Item>)Session["Cart"];
            cart.RemoveAt(Index);
            Session["Cart"] = cart;
            ViewBag.Name = Session["Cart"];
            return View("Cart");
        }
        public ActionResult OrderNow(int id)
        {
            if (Session["Cart"]==null )
            {
                List<Item> cart = new List<Controllers.Item>();
                cart.Add(new Controllers.Item(db.Debartments.Find(id), 1));
                Session["Cart"] = cart;
            }
            else
            {
                List<Item> cart = (List <Item>) Session["Cart"];
                int Index = IsExist(id);
                if(Index==-1)
                { 
                     cart.Add(new Controllers.Item(db.Debartments.Find(id), 1));
                }
                else
                {
                    cart[Index].Quantity++;
                }
                Session["Cart"] = cart;
            }
            return View("Cart");
        }
        public ActionResult CheckOut()
        {
            List<Item> cart = new List<Controllers.Item>();

            Session["Cart"] = cart;

            return View(cart.Count());
        }
    }
}