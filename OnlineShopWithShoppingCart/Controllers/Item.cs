using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopWithShoppingCart.Models;

namespace OnlineShopWithShoppingCart.Controllers
{
    public class Item
    {
        private Debartment pr = new Debartment();

        private int quantity;
        public Item()
        {

        }
        public Item(Debartment pr, int quantity)
        {
            this.Pr = pr;
            this.Quantity = quantity;
        }

        public Debartment Pr
        {
            get
            {
                return pr;
            }

            set
            {
                pr = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
    }
}