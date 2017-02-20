using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCShop
{
    public class Context : DbContext
    {
        public Context() : base("ConnectionString") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<IssueProduct> IssueProducts { get; set; }

    }
}