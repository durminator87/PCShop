using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCShop.Models
{
    public class PCShopCartVM
    {
        public decimal CartSaldo { get; set; }
        public virtual List<Cart> CartItems { get; set; }
    }
}