using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCShop.Models
{
    public class PCShopCartRemoveVM
    {
        public string Message { get; set; }
        public decimal CartSaldo {get;set;}
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int RemoveID { get; set; }
    }
}