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
            USERS_EXPENSES usExpD = new USERS_EXPENSES();
            USERS_EXPENSES usExpM = new USERS_EXPENSES();
            USERS_EXPENSES usExpK = new USERS_EXPENSES();
            USERS_EXPENSES usExpJ = new USERS_EXPENSES();
            BALANCES balD = new BALANCES();
            BALANCES balM = new BALANCES();
            BALANCES balK = new BALANCES();
            BALANCES balJ = new BALANCES();
            var users = db2.USERSSet;
            var extraEntity = db2.EXTRA_EXPENSESSet;
            var balances = db2.BALANCESSet;

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
            float sumOfExpenses = 0;
            float? extraExp = 0;
            if(extraEntity.Any(p=>p.EXTRA_EXPENSES_ID == extraToInt && p.Value != null))
            {
                extraExp = extraEntity.Where(p => p.EXTRA_EXPENSES_ID == extraToInt).ToList().LastOrDefault().Value;
            }
            sumOfExpenses = (rent + rentalFee + current + gas + internet + extraExp.Value) / 4;
            entity.EXTRA_EXPENSES = extraEntity.Where(p => p.EXTRA_EXPENSES_ID == extraToInt).FirstOrDefault();
            db2.EXPENSESSet.Add(entity);

            usExpD.USERS = users.Where(p=>p.USER_ID == 1).FirstOrDefault();
            usExpD.EXPENSES = entity;
            db2.USERS_EXPENSESSet.Add(usExpD);

            usExpM.USERS = users.Where(p => p.USER_ID == 2).FirstOrDefault();
            usExpM.EXPENSES = entity;
            db2.USERS_EXPENSESSet.Add(usExpM);

            usExpK.USERS = users.Where(p => p.USER_ID == 3).FirstOrDefault();
            usExpK.EXPENSES = entity;
            db2.USERS_EXPENSESSet.Add(usExpK);

            usExpJ.USERS = users.Where(p => p.USER_ID == 4).FirstOrDefault();
            usExpJ.EXPENSES = entity;
            db2.USERS_EXPENSESSet.Add(usExpJ);

            balD.USERS = usExpD.USERS;
            balD.validFrom = entity.ExpenseDate;
            if (balances.Any(p => p.USERS.USER_ID == usExpD.USERS.USER_ID))
            {
                balD.value = balances.Where(p => p.USERS.USER_ID == usExpD.USERS.USER_ID).ToList().LastOrDefault().value - sumOfExpenses;
            }
            else
                balD.value = -sumOfExpenses;

            balM.USERS = usExpM.USERS;
            balM.validFrom = entity.ExpenseDate;
            if (balances.Any(p => p.USERS.USER_ID == usExpM.USERS.USER_ID))
            {
                balM.value = balances.Where(p => p.USERS.USER_ID == usExpM.USERS.USER_ID).ToList().LastOrDefault().value - sumOfExpenses;
            }
            else
                balM.value = -sumOfExpenses;

            balK.USERS = usExpK.USERS;
            balK.validFrom = entity.ExpenseDate;
            if (balances.Any(p => p.USERS.USER_ID == usExpK.USERS.USER_ID))
            {
                balK.value = balances.Where(p => p.USERS.USER_ID == usExpK.USERS.USER_ID).ToList().LastOrDefault().value - sumOfExpenses;
            }
            else
                balK.value = -sumOfExpenses;

            balJ.USERS = usExpJ.USERS;
            balJ.validFrom = entity.ExpenseDate;
            if (balances.Any(p => p.USERS.USER_ID == usExpJ.USERS.USER_ID))
            {
                balJ.value = balances.Where(p => p.USERS.USER_ID == usExpJ.USERS.USER_ID).ToList().LastOrDefault().value - sumOfExpenses;
            }
            else
                balJ.value = -sumOfExpenses;

            db2.BALANCESSet.Add(balD);
            db2.BALANCESSet.Add(balM);
            db2.BALANCESSet.Add(balK);
            db2.BALANCESSet.Add(balJ);

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
                balancesEntity.value = balances.Where(p => p.USERS.USER_ID == userID).ToList().LastOrDefault().value + value;
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