using drugaApka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace drugaApka.Controllers
{
    public class AddDataController : Controller
    {
        // GET: AddData
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddExpense(string inputRentalFee, string inputRent, string inputCurrent, string inputGas, string inputInternet, string inputDate, string month, string extra)
        {
            float rentalFee, rent, current, gas, internet;
            int extraToInt;
            System.DateTime date;
            RentFlatModelContainer db2 = new RentFlatModelContainer();
            EXPENSES entity = new EXPENSES();
            EXTRA_EXPENSES ex = new EXTRA_EXPENSES();
            var extraEntity = db2.EXTRA_EXPENSESSet;
            if (inputRentalFee == null || inputRent == null || inputCurrent == null || inputGas == null || inputInternet == null)
            {
                ViewBag.error = "";
                return View(extraEntity);
            }
            if (inputRentalFee == "" && inputRent == "" && inputCurrent == "" && inputGas == "" && inputInternet == "" && extra == "-1")
            {
                ViewBag.error = "Dodaj chociaż 1 wydatek!";
                return View(extraEntity);
            }
                if (float.TryParse(inputRentalFee, out rentalFee))
                entity.RentalFee = rentalFee;
            if (float.TryParse(inputRent, out rent))
                entity.Rent = rent;
            if (float.TryParse(inputCurrent, out current))
                entity.CurrentBill = current;
            if (float.TryParse(inputGas, out gas))
                entity.GasBill = gas;
            if (float.TryParse(inputInternet, out internet))
                entity.InternetBill = internet;
            if (System.DateTime.TryParse(inputDate, out date))
                entity.ExpenseDate = date;
            else
            {
                ViewBag.error = "Ustaw datę zapłaty!";
                return View(extraEntity);
            }
            if (month != null)
                entity.ExpensePerMonth = month;
            else
            {
                ViewBag.error = "Nieprawidłowa nazwa miesiąca!";
                return View(extraEntity);
            }
            if (!int.TryParse(extra, out extraToInt))
            {
                ViewBag.error = "Nieprawidłowy dodatkowy wydatek!";
                return View(extraEntity);
            }
            entity.EXTRA_EXPENSES = extraEntity.Where(p => p.EXTRA_EXPENSES_ID == extraToInt).FirstOrDefault();
            db2.EXPENSESSet.Add(entity);
            db2.SaveChanges();
            ViewBag.error = "Pomyślnie dodano do bazy!";
            return View(extraEntity);
        }

        public ActionResult AddExtraExpense(string inputName, string inputValue)
        {
            float value;
            RentFlatModelContainer db = new RentFlatModelContainer();
            var extra = db.EXTRA_EXPENSESSet;
            if (inputName == null || inputValue == null)
            {
                ViewBag.error = "";
                return View(extra.OrderBy(p => p.Name));
            }
            if (inputName == "" || inputValue == "" || !float.TryParse(inputValue, out value))
            {
                ViewBag.error = "Nieprawidłowa nazwa lub wartość";
                return View(extra.OrderBy(p => p.Name));
            }

            EXTRA_EXPENSES extraEntity = new EXTRA_EXPENSES();
            extraEntity.Name = inputName;
            extraEntity.Value = value;
            db.EXTRA_EXPENSESSet.Add(extraEntity);
            db.SaveChanges();
            ViewBag.error = "Pomyślnie dodano do bazy!";
            return View(extra.OrderBy(p => p.Name));

        }

        public ActionResult AddPay(string inputDate, string inputValue, string user)
        {
            float value;
            int userID;
            DateTime date;
            RentFlatModelContainer db = new RentFlatModelContainer();
            var users = db.USERSSet;
            var balances = db.BALANCESSet;
            if (inputDate == null || inputValue == null || user == null)
            {
                ViewBag.error = "";
                return View(users.OrderBy(p => p.lastName));
            }
            if (!DateTime.TryParse(inputDate, out date) || inputValue == "" || !float.TryParse(inputValue, out value) || !int.TryParse(user, out userID))
            {
                ViewBag.error = "Nieprawidłowa data, wartość lub użytkownik";
                return View(users.OrderBy(p => p.lastName));
            }

            PAYS paysEntity = new PAYS();
            paysEntity.date = date;
            paysEntity.Value = value;
            paysEntity.USERS = users.Where(p => p.USER_ID == userID).FirstOrDefault();
            db.PAYSSet.Add(paysEntity);

            BALANCES balancesEntity = new BALANCES();
            balancesEntity.PAYS = paysEntity;
            balancesEntity.USERS = paysEntity.USERS;
            balancesEntity.validFrom = date;
            if (balances.Any(p => p.USERS.USER_ID == userID))
            {
                balancesEntity.value = balances.Where(p => p.USERS.USER_ID == userID).LastOrDefault().value + value;
            }
            else
                balancesEntity.value = value;
            db.BALANCESSet.Add(balancesEntity);
            db.SaveChanges();
            ViewBag.error = "Pomyślnie dodano do bazy!";
            return View(users.OrderBy(p => p.lastName));
        }

    }
}