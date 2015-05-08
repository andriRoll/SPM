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
    public class RencanaController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /Rencana/
        public ActionResult Index()
        {
            var rencanas = db.Rencanas.Include(r => r.Barang);
            return View(rencanas.ToList());
        }

        public ActionResult ForSales()
        {
            var rencanas = db.Rencanas.Include(r => r.Barang);
            return View(rencanas.ToList());
        }

        // GET: /Rencana/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rencana rencana = db.Rencanas.Find(id);
            if (rencana == null)
            {
                return HttpNotFound();
            }
            return View(rencana);
        }

        // GET: /Rencana/Create
        public ActionResult Create()
        {
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang");
            return View();
        }

        // POST: /Rencana/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_target,id_barang,target_jual")] Rencana rencana)
        {
            if (ModelState.IsValid)
            {
                db.Rencanas.Add(rencana);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", rencana.id_barang);
            return View(rencana);
        }

        // GET: /Rencana/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rencana rencana = db.Rencanas.Find(id);
            if (rencana == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", rencana.id_barang);
            return View(rencana);
        }

        // POST: /Rencana/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_target,id_barang,target_jual")] Rencana rencana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rencana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_barang = new SelectList(db.Barangs, "id_barang", "nama_barang", rencana.id_barang);
            return View(rencana);
        }

        // GET: /Rencana/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rencana rencana = db.Rencanas.Find(id);
            if (rencana == null)
            {
                return HttpNotFound();
            }
            return View(rencana);
        }

        // POST: /Rencana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rencana rencana = db.Rencanas.Find(id);
            db.Rencanas.Remove(rencana);
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
