using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PCShop.Models;

namespace PCShop.Controllers
{
    public class PCShopController : Controller
    {
        Context db = new Context();
        // GET: PCShop
        public ActionResult Index(int ? CategoryID)
        {
            ProductVM pro = new ProductVM();
            if (CategoryID.HasValue)
                pro.Products = db.Products.Where(x => x.CategoryID == CategoryID).ToList();
            else
                pro.Products = db.Products.ToList();

            pro.Categories = db.Categories.ToList();


            if(Session["LogedID"] !=null)
            {
                return View("Index1",pro);
            }

            return View("Index",pro);

        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer c)
        {
            if (ModelState.IsValid)
            {
                int id;
                var v = db.Customers.Where(a => a.Email.Equals(c.Email) && a.Password.Equals(c.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["LogedID"] = v.CustomerID.ToString();
                    Session["LoggedEmail"] = v.Email.ToString();
                    Session["id"] = v.CustomerID;

                    id = v.CustomerID;

                    return RedirectToAction("Index");
                }
            }
            return View(c);
        }

        public ActionResult Logout()
        {
            Session.Remove("LogedID");

            //var cart = BookstoreCart.GetCart(HttpContext);
            //cart.EmptyCart();

            return RedirectToAction("Index");
        }

        public ActionResult Register(Customer c)
        {
            return View("Register");
        }

        //POST: Create a new user
        public ActionResult postCreate(string Password, string FirstName, string LastName, string Address, string Email, string City)
        {
            var c = new Customer();
            c.Password = Password;
            c.Name = FirstName;
            c.Surname = LastName;
            c.Email = Email;
            c.Address = Address;
            c.City = City;
            db.Customers.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}