using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Models
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Details { get; set; }
        public int CategoryID { get; set; }
        public List<SelectListItem> CategoriesAsSelectListItem
        {
            get
            {
                List<SelectListItem> item = new List<SelectListItem>();
                foreach (Category cat in Categories)
                {
                    item.Add(new SelectListItem() { Value = cat.CategoryID.ToString(), Text = cat.Name });
                }

                return item;
            }


        }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}