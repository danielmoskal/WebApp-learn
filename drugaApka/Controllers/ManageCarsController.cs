using drugaApka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace drugaApka.Controllers
{
    public class ManageCarsController : Controller
    {
        //static List<Car> cars = new List<Car>();
        // GET: ManageCars
        public ActionResult Add(string marka, string model, string rok)
        {
            firstEntities1 db = new firstEntities1();
            string a = marka + model + rok;
            if (a != "")
            {
                db.Samochod.Add(new Samochod { Marka = marka, Model = model, Rok = rok });
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult View()
        {
            firstEntities1 db = new firstEntities1();
            var cars = db.Samochod;
            return View(cars);
        }

        public ActionResult Search(string marka, string model, string rok)
        {
            firstEntities1 db = new firstEntities1();
            var cars = db.Samochod;
            if (cars.Any(p => p.Marka == marka || p.Model == model || p.Rok == rok))
            {
                var searchCars = cars.Where(p => p.Marka == marka || p.Model == model || p.Rok == rok);
                return View("View", searchCars);
                //return RedirectToAction("View", "ManageCars", searchCars);
            }
            return View();
        }

        public ActionResult RemoveAll()
        {
            firstEntities1 db = new firstEntities1();
            var cars = db.Samochod;
            db.Samochod.RemoveRange(cars);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}