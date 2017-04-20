using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using drugaApka.Models;

namespace drugaApka.Controllers
{
    public class PaysController : Controller
    {
        private RentFlatModelContainer db = new RentFlatModelContainer();

        // GET: Pays
        public ActionResult Index()
        {
            var pays = db.PAYSSet;
            return View(pays.Where(p=>p.USERS.USER_ID != 1).OrderBy(p=>p.date));
        }
    }
}
