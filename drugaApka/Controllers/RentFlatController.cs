using drugaApka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.Mvc;

namespace drugaApka.Controllers
{
    public class RentFlatController : Controller
    {
        // GET: RentFlat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PayMoney()
        {
            return View();
        }

        public ActionResult Expenses()
        {
            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            var extra = db.EXTRA_EXPENSESSet;
            return View(expenses);
        }
    }
}