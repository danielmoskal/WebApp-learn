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
            List<Month> months = new List<Month>();
            months.Add(new Month { MonthID = 1, MonthName = "Styczen" });
            months.Add(new Month { MonthID = 2, MonthName = "Luty" });
            months.Add(new Month { MonthID = 3, MonthName = "Marzec" });
            months.Add(new Month { MonthID = 4, MonthName = "Kwiecien" });

            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            List<EXPENSES> exp = new List<EXPENSES>();
            foreach (var x in months)
            {
                if (expenses.Any(p => p.ExpensePerMonth == x.MonthName))
                {
                    var currentExpense = expenses.RemoveRange(expenses.Where(p => p.ExpensePerMonth == x.MonthName));
                    EXPENSES entity = new EXPENSES();
                    foreach (var item in currentExpense)
                    {
                        if (entity.ExpensePerMonth == null && item.ExpensePerMonth != null)
                            entity.ExpensePerMonth = item.ExpensePerMonth;
                        if (entity.CurrentBill == null && item.CurrentBill != null)
                            entity.CurrentBill = item.CurrentBill;
                        if (entity.GasBill == null && item.GasBill != null)
                            entity.GasBill = item.GasBill;
                        if (entity.InternetBill == null && item.InternetBill != null)
                            entity.InternetBill = item.InternetBill;
                        if (entity.Rent == null && item.Rent != null)
                            entity.Rent = item.Rent;
                        if (entity.RentalFee == null && item.RentalFee != null)
                            entity.RentalFee = item.RentalFee;
                    }
                    exp.Add(entity);
                    //IEnumerable<EXPENSES> expp;
                    //expp = exp;
                }
            }
            return View(exp);
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
            if (!System.DateTime.TryParse(data, out date) && data != "" && data != null)
                return View("SearchDetails");
            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            if (expenses.Any(p => p.ExpensePerMonth == miesiac || p.ExpenseDate.Equals(date)))
            {
                var searchExpenses = expenses.Where(p => p.ExpensePerMonth == miesiac || p.ExpenseDate.Equals(date));
                return View("Details", searchExpenses.OrderBy(P => P.ExpenseDate));
            }
            if (miesiac == "" && data == "")
                return View("Details", expenses.OrderBy(P=>P.ExpenseDate));
            else
                return View();
        }
    }
}