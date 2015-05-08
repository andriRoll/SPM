using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesPlanningMonitorng;

namespace SalesPlanningMonitorng.Controllers
{
    public class KelompokController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /Kelompok/
        public ActionResult Index()
        {
            return View(db.Kelompoks.ToList());
        }

        // GET: /Kelompok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kelompok kelompok = db.Kelompoks.Find(id);
            if (kelompok == null)
            {
                return HttpNotFound();
            }
            return View(kelompok);
        }

        // GET: /Kelompok/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Kelompok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_kelompok,nama_kelompok")] Kelompok kelompok)
        {
            if (ModelState.IsValid)
            {
                db.Kelompoks.Add(kelompok);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kelompok);
        }

        // GET: /Kelompok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kelompok kelompok = db.Kelompoks.Find(id);
            if (kelompok == null)
            {
                return HttpNotFound();
            }
            return View(kelompok);
        }

        // POST: /Kelompok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_kelompok,nama_kelompok")] Kelompok kelompok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kelompok).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kelompok);
        }

        // GET: /Kelompok/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kelompok kelompok = db.Kelompoks.Find(id);
            if (kelompok == null)
            {
                return HttpNotFound();
            }
            return View(kelompok);
        }

        // POST: /Kelompok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kelompok kelompok = db.Kelompoks.Find(id);
            db.Kelompoks.Remove(kelompok);
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
