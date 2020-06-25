using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prolab.Models;

namespace Prolab.Controllers
{
    public class kullanıcı1Controller : Controller
    {
        private LoginDataEntities1 db = new LoginDataEntities1();

        // GET: kullanıcı1
        public ActionResult Index()
        {
            var kullanıcı = db.kullanıcı.Include(k => k.Book).Include(k => k.User);
            return View(kullanıcı.ToList());
        }

        // GET: kullanıcı1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı kullanıcı = db.kullanıcı.Find(id);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        // GET: kullanıcı1/Create
        public ActionResult Create()
        {
            ViewBag.bookid = new SelectList(db.Book, "Bookid", "Bookname");
            ViewBag.kitapid = new SelectList(db.User, "UserID", "Username");
            return View();
        }

        // POST: kullanıcı1/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kullanıcıid,bookid,kitapid,retundate")] kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                db.kullanıcı.Add(kullanıcı);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookid = new SelectList(db.Book, "Bookid", "Bookname", kullanıcı.bookid);
            ViewBag.kitapid = new SelectList(db.User, "UserID", "Username", kullanıcı.kitapid);
            return View(kullanıcı);
        }

        // GET: kullanıcı1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı kullanıcı = db.kullanıcı.Find(id);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookid = new SelectList(db.Book, "Bookid", "Bookname", kullanıcı.bookid);
            ViewBag.kitapid = new SelectList(db.User, "UserID", "Username", kullanıcı.kitapid);
            return View(kullanıcı);
        }

        // POST: kullanıcı1/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kullanıcıid,bookid,kitapid,retundate")] kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanıcı).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookid = new SelectList(db.Book, "Bookid", "Bookname", kullanıcı.bookid);
            ViewBag.kitapid = new SelectList(db.User, "UserID", "Username", kullanıcı.kitapid);
            return View(kullanıcı);
        }

        // GET: kullanıcı1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı kullanıcı = db.kullanıcı.Find(id);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        // POST: kullanıcı1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kullanıcı kullanıcı = db.kullanıcı.Find(id);
            db.kullanıcı.Remove(kullanıcı);
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
