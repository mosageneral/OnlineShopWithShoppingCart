using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShopWithShoppingCart.Models
{
    public class Debartment
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم المنتج")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "السعر")]
        public decimal  Price { get; set; }
        [Display(Name = "الصورة")]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}