using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using drugaApka.Models;
using System.Globalization;

namespace drugaApka.Controllers
{
    public class HomeController : Controller
    {
        RentFlatModelContainer db = new RentFlatModelContainer();
        public ActionResult Index()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL");
            var balances = db.BALANCESSet;
            ViewBag.balances = balances.OrderBy(p => p.validFrom);
            var users = db.USERSSet;
            return View(users.Where(p=>p.USER_ID != 1));
        }
    }
}