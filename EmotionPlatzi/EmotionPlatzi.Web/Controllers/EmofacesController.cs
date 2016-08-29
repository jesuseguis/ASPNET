using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmotionPlatzi.Web.Models;

namespace EmotionPlatzi.Web.Controllers
{
    public class EmofacesController : Controller
    {
        private EmotionPlatziWebContext db = new EmotionPlatziWebContext();

        // GET: Emofaces
        public ActionResult Index()
        {
            var emofaces = db.Emofaces.Include(e => e.Picture);
            return View(emofaces.ToList());
        }

        // GET: Emofaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoface emoface = db.Emofaces.Find(id);
            if (emoface == null)
            {
                return HttpNotFound();
            }
            return View(emoface);
        }

        // GET: Emofaces/Create
        public ActionResult Create()
        {
            ViewBag.EmoPictureId = new SelectList(db.EmoPictures, "Id", "Name");
            return View();
        }

        // POST: Emofaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmoPictureId,X,Y,Width,Height")] Emoface emoface)
        {
            if (ModelState.IsValid)
            {
                db.Emofaces.Add(emoface);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmoPictureId = new SelectList(db.EmoPictures, "Id", "Name", emoface.EmoPictureId);
            return View(emoface);
        }

        // GET: Emofaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoface emoface = db.Emofaces.Find(id);
            if (emoface == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmoPictureId = new SelectList(db.EmoPictures, "Id", "Name", emoface.EmoPictureId);
            return View(emoface);
        }

        // POST: Emofaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmoPictureId,X,Y,Width,Height")] Emoface emoface)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emoface).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmoPictureId = new SelectList(db.EmoPictures, "Id", "Name", emoface.EmoPictureId);
            return View(emoface);
        }

        // GET: Emofaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emoface emoface = db.Emofaces.Find(id);
            if (emoface == null)
            {
                return HttpNotFound();
            }
            return View(emoface);
        }

        // POST: Emofaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emoface emoface = db.Emofaces.Find(id);
            db.Emofaces.Remove(emoface);
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
