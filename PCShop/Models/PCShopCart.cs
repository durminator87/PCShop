using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCShop.Models
{
    public class PCShopCart
    {
        Context db = new Context();

        string PCShopCartID { get; set; }
        public const string CartSessionKey = "CartID";


        public string GetCartID(HttpContextBase ctx)
        {
            if (ctx.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(ctx.User.Identity.Name))
                {
                    ctx.Session[CartSessionKey] = ctx.User.Identity.Name;
                }
                else 
                {
                    Guid tempCartID = Guid.NewGuid();
                    ctx.Session[CartSessionKey] = ctx.User.Identity.Name;
                }
 
            }
            return ctx.Session[CartSessionKey].ToString();

        }

        public static PCShopCart GetCart(HttpContextBase ctx)
        {
            var cart = new PCShopCart();
            cart.PCShopCartID = cart.GetCartID(ctx);
            return cart;
        }

        public void AddToCart(Product product)
        {
            var item = db.Carts.SingleOrDefault(c => c.CartID == PCShopCartID && c.ProductID == product.ProductID);

            if (item == null)
            {
                item = new Cart()
                {
                    ProductID = product.ProductID,
                    CartID = PCShopCartID,
                    Count = 1,
                    Date = DateTime.Now
                };

                db.Carts.Add(item);
            }
            else { item.Count++; }


            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var item = db.Carts.Single(c => c.CartID == PCShopCartID && c.ProductID == id);
            int itemCount = 0;


            if (item != null)
            {
                if (item.Count > 1)
                {
                    item.Count--;
                    itemCount = item.Count;
                }

                else db.Carts.Remove(item);

                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var item = db.Carts.Where(c => c.CartID == PCShopCartID);

            foreach (var i in item)
            {
                db.Carts.Remove(i);
            }
            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(c => c.CartID == PCShopCartID).ToList();
        }

        public int GetCount()
        {
            int? count = (from item in db.Carts
                          where item.CartID == PCShopCartID
                          select (int?)item.Count).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from item in db.Carts
                              where item.CartID == PCShopCartID
                              select (int?)item.Count * item.Product.Price).Sum();

            return total ?? decimal.Zero;
        }


        public void CreateOrder(Customer user)
        {
            decimal total = 0;

            var items = GetCartItems();

            foreach (var i in items)
            {
                var issueBook = new IssueProduct
                {
                    ProductID = i.ProductID,
                    CustomerID = user.CustomerID,
                    Customer = user,
                    Product = i.Product,
                    Saldo = GetTotal(),
                    Price = i.Product.Price,
                    Quantity = i.Count,
                    IssueDate = DateTime.Now
                };

                total += (i.Count * i.Product.Price);
                db.IssueProducts.Add(issueBook);
            }

            db.SaveChanges();
            EmptyCart();
        }


    }
}