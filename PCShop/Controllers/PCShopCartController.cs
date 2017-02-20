using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Controllers
{
    public class PCShopCartController : Controller
    {
        Context db = new Context();
        // GET: PCShopCart
        public ActionResult Index()
        {
            var cart = PCShopCart.GetCart(HttpContext);

            var vm = new PCShopCartVM
            {
                CartItems = cart.GetCartItems(),
                CartSaldo = cart.GetTotal()
            };

            return View(vm);
        }

        public ActionResult AddToCart(int id)
        {
            var pr = db.Products.Single(p => p.ProductID == id);

            //ViewData["student"] = db.Products.Find(id);

            var cart = PCShopCart.GetCart(HttpContext);
            cart.AddToCart(pr);

            return RedirectToAction("Index", pr);
        }

        public ActionResult RemoveFromCart(int id)
        {
            var cart = PCShopCart.GetCart(HttpContext);

            int count = cart.RemoveFromCart(id);

            var result = new PCShopCartRemoveVM
            {
                CartSaldo = cart.GetTotal(),
                CartCount = cart.GetCount(),
                RemoveID = id
            };

            return RedirectToAction("Index");
        }
    }
}