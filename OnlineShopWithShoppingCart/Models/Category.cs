using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopWithShoppingCart.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "القسم")]
        public string Name { get; set; }
        public virtual  ICollection <Debartment> Debartments { get; set; }

    }
}