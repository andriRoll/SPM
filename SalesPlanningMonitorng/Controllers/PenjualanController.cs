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
    public class PenjualanController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /Penjualan/
        public ActionResult Index()
        {
            var penjualans = db.Penjualans.Include(p => p.Barang).Include(p => p.Karyawan).Include(p => p.Toko);
            return View(penjualans.ToList());
        }

        // GET: /Penjualan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penjualan penjualan = db.Penjualans.Find(id);
            if (penjualan == null)
            {
                return HttpNotFound();
            }
            return View(penjualan);
        }

        // GET: /Penjualan/Create
        public ActionResult Create()
        {
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang");
            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama");
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko");
            return View();
        }

        // POST: /Penjualan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_penjualan,id_barang,id_toko,id_karyawan,tanggal_transaksi,jumlah_total")] Penjualan penjualan)
        {
            if (ModelState.IsValid)
            {
                db.Penjualans.Add(penjualan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", penjualan.id_barang);
            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama", penjualan.id_karyawan);
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko", penjualan.id_toko);
            return View(penjualan);
        }

        // GET: /Penjualan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penjualan penjualan = db.Penjualans.Find(id);
            if (penjualan == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", penjualan.id_barang);
            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama", penjualan.id_karyawan);
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko", penjualan.id_toko);
            return View(penjualan);
        }

        // POST: /Penjualan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_penjualan,id_barang,id_toko,id_karyawan,tanggal_transaksi,jumlah_total")] Penjualan penjualan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penjualan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", penjualan.id_barang);
            ViewBag.id_karyawan = new SelectList(db.Karyawans, "id_karyawan", "nama", penjualan.id_karyawan);
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko", penjualan.id_toko);
            return View(penjualan);
        }

        // GET: /Penjualan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Penjualan penjualan = db.Penjualans.Find(id);
            if (penjualan == null)
            {
                return HttpNotFound();
            }
            return View(penjualan);
        }

        // POST: /Penjualan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Penjualan penjualan = db.Penjualans.Find(id);
            db.Penjualans.Remove(penjualan);
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
