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
    public class KelompokSalesController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /KelompokSales/
        public ActionResult Index()
        {
            var kelompoksales = db.KelompokSales.Include(k => k.Karyawan).Include(k => k.Kelompok);
            return View(kelompoksales.ToList());
        }

        // GET: /KelompokSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelompokSale kelompoksale = db.KelompokSales.Find(id);
            if (kelompoksale == null)
            {
                return HttpNotFound();
            }
            return View(kelompoksale);
        }

        // GET: /KelompokSales/Create
        public ActionResult Create()
        {
            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama");
            ViewBag.id_kelompok = new SelectList(db.Kelompoks, "id_kelompok", "nama_kelompok");
            return View();
        }

        // POST: /KelompokSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_kelompokSales,id_kelompok,id_karyawan")] KelompokSale kelompoksale)
        {
            if (ModelState.IsValid)
            {
                db.KelompokSales.Add(kelompoksale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama", kelompoksale.id_karyawan);
            ViewBag.id_kelompok = new SelectList(db.Kelompoks, "id_kelompok", "nama_kelompok", kelompoksale.id_kelompok);
            return View(kelompoksale);
        }

        // GET: /KelompokSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelompokSale kelompoksale = db.KelompokSales.Find(id);
            if (kelompoksale == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama", kelompoksale.id_karyawan);
            ViewBag.id_kelompok = new SelectList(db.Kelompoks, "id_kelompok", "nama_kelompok", kelompoksale.id_kelompok);
            return View(kelompoksale);
        }

        // POST: /KelompokSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_kelompokSales,id_kelompok,id_karyawan")] KelompokSale kelompoksale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kelompoksale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama", kelompoksale.id_karyawan);
            ViewBag.id_kelompok = new SelectList(db.Kelompoks, "id_kelompok", "nama_kelompok", kelompoksale.id_kelompok);
            return View(kelompoksale);
        }

        // GET: /KelompokSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KelompokSale kelompoksale = db.KelompokSales.Find(id);
            if (kelompoksale == null)
            {
                return HttpNotFound();
            }
            return View(kelompoksale);
        }

        // POST: /KelompokSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KelompokSale kelompoksale = db.KelompokSales.Find(id);
            db.KelompokSales.Remove(kelompoksale);
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
