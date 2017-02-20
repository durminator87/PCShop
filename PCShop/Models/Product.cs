using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PCShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        public int Price { get; set; }
        public string Details { get; set; }

        public virtual Category Category { get; set; }
    }
}