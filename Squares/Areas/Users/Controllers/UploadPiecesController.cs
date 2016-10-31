using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Squares.Models;

namespace Squares.Areas.Users.Controllers
{
    public class UploadPiecesController : Controller
    {
        private SquaresEntities db = new SquaresEntities();

        // GET: Users/UploadPieces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piece piece = db.Pieces.Find(id);
            if (piece == null)
            {
                return HttpNotFound();
            }
            return View(piece);
        }

        // GET: Users/UploadPieces/Create
        public ActionResult Create()
        {
            ViewBag.setId = new SelectList(db.Sets, "id", "name");
            return View();
        }

        // POST: Users/UploadPieces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,setId,imgURL_thumb,imgURL_full")] Piece piece)
        {
            if (ModelState.IsValid)
            {
                db.Pieces.Add(piece);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.setId = new SelectList(db.Sets, "id", "name", piece.setId);
            return View(piece);
        }

        // GET: Users/UploadPieces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piece piece = db.Pieces.Find(id);
            if (piece == null)
            {
                return HttpNotFound();
            }
            ViewBag.setId = new SelectList(db.Sets, "id", "name", piece.setId);
            return View(piece);
        }

        // POST: Users/UploadPieces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,setId,imgURL_thumb,imgURL_full")] Piece piece)
        {
            if (ModelState.IsValid)
            {
                db.Entry(piece).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.setId = new SelectList(db.Sets, "id", "name", piece.setId);
            return View(piece);
        }

        // GET: Users/UploadPieces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piece piece = db.Pieces.Find(id);
            if (piece == null)
            {
                return HttpNotFound();
            }
            return View(piece);
        }

        // POST: Users/UploadPieces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Piece piece = db.Pieces.Find(id);
            db.Pieces.Remove(piece);
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
