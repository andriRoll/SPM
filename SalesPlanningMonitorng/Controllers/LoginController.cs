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
    public class LoginController : Controller
    {
        private psbkEntities2 db = new psbkEntities2();

        // GET: /Login/
        public ActionResult Index()
        {
            return View(db.Logins.ToList());
        }

        // GET: /Login/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: /Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_login,username,pass,grup")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }

        // GET: /Login/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: /Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_login,username,pass,grup")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: /Login/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: /Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
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

        public ActionResult Login() {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login) { 
            if (ModelState.IsValid){
                using (psbkEntities2 db = new psbkEntities2()) {
                    var v = db.Logins.Where(a => a.username.Equals(login.username) && a.pass.Equals(login.pass)).FirstOrDefault();
                    if (v != null && v.grup.Equals("Supervisor"))
                    {
                        Session["LogedUserID"] = v.id_login.ToString();
                        Session["LogedUserGrup"] = v.grup.ToString();
                        return RedirectToAction("Index","Home");
                    }
                    else if (v != null && v.grup.Equals("sales"))
                    {
                        Session["LogedUserID"] = v.id_login.ToString();
                        Session["LogedUserGrup"] = v.grup.ToString();
                        return RedirectToAction("IndexSales", "Home");
                    }
                }

            }

            return View(login);
        }
    }
}
