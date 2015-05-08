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
    public class StokController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /Stok/
        public ActionResult Index()
        {
            var stoks = db.Stoks.Include(s => s.Barang).Include(s => s.Toko);
            return View(stoks.ToList());
        }

        // GET: /Stok/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        // GET: /Stok/Create
        public ActionResult Create()
        {
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang");
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko");
            return View();
        }

        // POST: /Stok/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_barang,id_toko,jumlah")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Stoks.Add(stok);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", stok.id_barang);
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko", stok.id_toko);
            return View(stok);
        }

        // GET: /Stok/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", stok.id_barang);
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko", stok.id_toko);
            return View(stok);
        }

        // POST: /Stok/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_barang,id_toko,jumlah")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stok).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", stok.id_barang);
            ViewBag.id_toko = new SelectList(db.Tokoes, "id_toko", "nama_toko", stok.id_toko);
            return View(stok);
        }

        // GET: /Stok/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stoks.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        // POST: /Stok/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stok stok = db.Stoks.Find(id);
            db.Stoks.Remove(stok);
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
