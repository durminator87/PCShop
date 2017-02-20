using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCShop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<Product> CProducts { get; set; }
                
    }
}