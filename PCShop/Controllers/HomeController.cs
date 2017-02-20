using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        
        public ActionResult Index()
        {
           /* ProductVM pro = new ProductVM();
            if (CategoryID.HasValue)
                pro.Products = db.Products.Where(x => x.CategoryID == CategoryID).ToList();
            else
                pro.Products = db.Products.ToList();

            pro.Categories = db.Categories.ToList();

            return View("Index1",pro);*/
            return RedirectToAction("Index", "PCShop");
        }

        public ActionResult Admin()
        {
            if (Session["LogedUserID"] != null)
            {
                var u = db.Admins.ToList();
                return View("Admin", u);
            }
            else return View("NoAccess");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin u)
        {
            if (ModelState.IsValid)
            {
                var v = db.Admins.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["LogedUserID"] = v.AdminID.ToString();
                    Session["LoggedUsername"] = v.Username.ToString();
                    return RedirectToAction("Admin");
                }
            }
            return View(u);
        }

        public ActionResult Logout()
        {
            Session.Remove("LogedUserID");
            return RedirectToAction("Login");
        }

        //GET: Create admin
        public ActionResult Create(Admin u)
        {
            return View("Create");
        }

        //POST: Create a new admin
        public ActionResult postCreate(string Username, string Password)
        {
            var u = new Admin();
            u.Username = Username;
            u.Password = Password;
            db.Admins.Add(u);
            db.SaveChanges();

            return RedirectToAction("Admin");
        }

                
    }
}