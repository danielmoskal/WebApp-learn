using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using drugaApka.Models;

namespace drugaApka.Controllers
{
    public class HomeController : Controller
    {
        RentFlatModelContainer db = new RentFlatModelContainer();
        public ActionResult Index()
        {
            var balances = db.BALANCESSet;
            ViewBag.balances = balances.OrderBy(p => p.validFrom);
            var users = db.USERSSet;
            return View(users.Where(p=>p.USER_ID != 1));
        }
    }
}