using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Controllers
{
    public class BuyController : Controller
    {
        Context db = new Context();
        // GET: Buy
        public ActionResult Buy()
        {
            {
                if (Session["LogedID"] != null)
                {

                    int id;
                    id = Convert.ToInt32(Session["id"]);
                    Customer user = db.Customers.Find(id);
                    var cart = PCShopCart.GetCart(HttpContext);

                    cart.CreateOrder(user);
                    return View("Buy");
                }
                else return View("NoBuy");
            }
        }
    }
}