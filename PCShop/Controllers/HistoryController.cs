using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Controllers
{
    public class HistoryController : Controller
    {
        Context db = new Context();
        // GET: History
        public ActionResult Index()
        {
            if (Session["LogedUserID"] != null)
            {
                var p = db.IssueProducts.Include("Customer").Include("Product").ToList();
                ViewData["issueBooks"] = p;

                return View("Index");
            }
            else return View("NoAccess");
        }
    }
}