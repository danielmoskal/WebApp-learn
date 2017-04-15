using drugaApka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace drugaApka.Controllers
{
    public class ExpensesController : Controller
    {
        // GET: Expenses
        public ActionResult Index()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pl-PL");
            List<Month> months = new List<Month>();
            months.Add(new Month { MonthID = 1, MonthName = "Styczeń" });
            months.Add(new Month { MonthID = 2, MonthName = "Luty" });
            months.Add(new Month { MonthID = 3, MonthName = "Marzec" });
            months.Add(new Month { MonthID = 4, MonthName = "Kwiecień" });
            months.Add(new Month { MonthID = 4, MonthName = "Maj" });
            months.Add(new Month { MonthID = 4, MonthName = "Czerwiec" });
            months.Add(new Month { MonthID = 4, MonthName = "Lipiec" });
            months.Add(new Month { MonthID = 4, MonthName = "Sierpień" });
            months.Add(new Month { MonthID = 4, MonthName = "Wrzesień" });

            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            List<EXPENSES> exp = new List<EXPENSES>();
            foreach (var x in months)
            {
                if (expenses.Any(p => p.ExpensePerMonth.ToLower() == x.MonthName.ToLower()))
                {
                    var currentExpense = expenses.RemoveRange(expenses.Where(p => p.ExpensePerMonth.ToLower() == x.MonthName.ToLower()));
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
                }
            }
            RentFlatModelContainer db2 = new RentFlatModelContainer();
            
            var ex = db2.EXPENSESSet;
            ViewBag.extraExpenses = ex.Where(p => p.EXTRA_EXPENSES != null);
            return View(exp);
        }

        public ActionResult Details()
        {
            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            return View(expenses);
        }


        /// <summary>
        /// This function downloads data from html-form and shows right result, which are compatible with primary data
        /// </summary>
        /// <param name="month"></param>
        /// month downloaded from html-form
        /// <param name="date"></param>
        /// date downloaded from html form
        /// <returns></returns>
        public ActionResult SearchDetails(string month, string date)
        {
            System.DateTime date2;
            if (!System.DateTime.TryParse(date, out date2) && date != "" && date2 != null)
                return View("SearchDetails");
            RentFlatModelContainer db = new RentFlatModelContainer();
            var expenses = db.EXPENSESSet;
            if (expenses.Any(p => p.ExpensePerMonth == month || p.ExpenseDate.Equals(date2)))
            {
                var searchExpenses = expenses.Where(p => p.ExpensePerMonth == month || p.ExpenseDate.Equals(date2));
                return View("Details", searchExpenses.OrderBy(P => P.ExpenseDate));
            }
            if (month == "" && date == "")
                return View("Details", expenses.OrderBy(P=>P.ExpenseDate));
            else
                return View();
        }

        public ActionResult ExtraExpenses(string month)
        {
            RentFlatModelContainer db = new RentFlatModelContainer();
            List<EXTRA_EXPENSES> extraList = new List<EXTRA_EXPENSES>();
            var expenses = db.EXPENSESSet;
            var extraExpenses = expenses.Where(p => p.EXTRA_EXPENSES != null);
            if (month != null && month != "")
            {
                var extra = expenses.Where(p=>p.EXTRA_EXPENSES != null && p.ExpensePerMonth == month);
                return View(extra.OrderBy(p => p.ExpenseDate));
            }
            return View(extraExpenses.OrderBy(p=>p.ExpenseDate));
        }
    }
}