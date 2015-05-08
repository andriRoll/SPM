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
    public class KaryawanController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /Karyawan/
        public ActionResult Index()
        {
            return View(db.Karyawans.ToList());
        }

        // GET: /Karyawan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // GET: /Karyawan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Karyawan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_karyawan,nama,alamat,no_telp,tanggal_lahir,photo")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.Karyawans.Add(karyawan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(karyawan);
        }

        // GET: /Karyawan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // POST: /Karyawan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_karyawan,nama,alamat,no_telp,tanggal_lahir,photo")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karyawan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(karyawan);
        }

        // GET: /Karyawan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // POST: /Karyawan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Karyawan karyawan = db.Karyawans.Find(id);
            db.Karyawans.Remove(karyawan);
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
