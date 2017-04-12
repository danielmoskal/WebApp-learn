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
            return View(db.PAYSSet.ToList());
        }

        // GET: Pays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYS pAYS = db.PAYSSet.Find(id);
            if (pAYS == null)
            {
                return HttpNotFound();
            }
            return View(pAYS);
        }

        // GET: Pays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PAY_ID,date,Value")] PAYS pAYS)
        {
            if (ModelState.IsValid)
            {
                db.PAYSSet.Add(pAYS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAYS);
        }

        // GET: Pays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYS pAYS = db.PAYSSet.Find(id);
            if (pAYS == null)
            {
                return HttpNotFound();
            }
            return View(pAYS);
        }

        // POST: Pays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PAY_ID,date,Value")] PAYS pAYS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAYS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAYS);
        }

        // GET: Pays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAYS pAYS = db.PAYSSet.Find(id);
            if (pAYS == null)
            {
                return HttpNotFound();
            }
            return View(pAYS);
        }

        // POST: Pays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAYS pAYS = db.PAYSSet.Find(id);
            db.PAYSSet.Remove(pAYS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
