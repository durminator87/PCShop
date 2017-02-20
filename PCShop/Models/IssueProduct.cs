using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCShop.Models
{
    public class IssueProduct
    {
        public int IssueProductID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public decimal Saldo { get; set; }
        public DateTime IssueDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}