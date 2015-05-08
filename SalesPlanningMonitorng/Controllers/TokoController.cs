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
    public class TokoController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /Toko/
        public ActionResult Index()
        {
            return View(db.Tokoes.ToList());
        }

        // GET: /Toko/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toko toko = db.Tokoes.Find(id);
            if (toko == null)
            {
                return HttpNotFound();
            }
            return View(toko);
        }

        // GET: /Toko/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Toko/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_toko,nama_toko,alamat,wilayah")] Toko toko)
        {
            if (ModelState.IsValid)
            {
                db.Tokoes.Add(toko);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toko);
        }

        // GET: /Toko/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toko toko = db.Tokoes.Find(id);
            if (toko == null)
            {
                return HttpNotFound();
            }
            return View(toko);
        }

        // POST: /Toko/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_toko,nama_toko,alamat,wilayah")] Toko toko)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toko).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toko);
        }

        // GET: /Toko/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Toko toko = db.Tokoes.Find(id);
            if (toko == null)
            {
                return HttpNotFound();
            }
            return View(toko);
        }

        // POST: /Toko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Toko toko = db.Tokoes.Find(id);
            db.Tokoes.Remove(toko);
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
