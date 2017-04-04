using drugaApka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace drugaApka.Controllers
{
    public class ExpensesController : Controller
    {
        // GET: Expenses
        public ActionResult Index()
        {
            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            //RentFlatModelContainer db = new RentFlatModelContainer();
            //var expenses = db.EXPENSESSet;
            //System.Data.Entity.DbSet<EXPENSES> currentExpense = null;
            //if (expenses.Any(p => p.ExpensePerMonth == "April"))
            //{
            //    currentExpense.AddRange(expenses.Where(p => p.ExpensePerMonth == "April"));
            //}

            return View();
        }

        public ActionResult Details()
        {
            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            return View(expenses);
        }

        public ActionResult SearchDetails(string miesiac, string data)
        {
            System.DateTime date;
            if (!System.DateTime.TryParse(data, out date) && data != "")
                return View("SearchDetails");
            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            if (expenses.Any(p => p.ExpensePerMonth == miesiac || p.ExpenseDate.Equals(date)))
            {
                var searchExpenses = expenses.Where(p => p.ExpensePerMonth == miesiac || p.ExpenseDate.Equals(date));
                return View("Details", searchExpenses);
            }
            return View();
        }
    }
}