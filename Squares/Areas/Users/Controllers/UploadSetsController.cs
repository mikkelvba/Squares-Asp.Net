using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Squares.Models;
using Squares.Areas.Users.ViewModels;

using System.IO;
using System.Drawing;

namespace Squares.Areas.Users.Controllers
{
    public class UploadSetsController : Controller
    {
        private SquaresEntities db = new SquaresEntities();

        // GET: Users/UploadSets
        public ActionResult Index()
        {
            //Find logged in user
            User user = db.Users.Single(s => s.email.Trim().ToLower() == System.Web.HttpContext.Current.User.Identity.Name.Trim().ToLower());
            int userID = user.id;

            var sets = db.Sets.Where( s => s.userId == userID);

            ViewBag.name = user.fullName;

            return View(sets.ToList());
        }

        // GET: Users/UploadSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Set set = db.Sets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            return View(set);
        }

        // GET: Users/UploadSets/Create
        public ActionResult Create()
        {
            ViewBag.userId = new SelectList(db.Users, "id", "username");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SetViewModel set, HttpPostedFileBase[] files)
        {
            //Find logged in user
            User user = db.Users.Single(s => s.email.Trim().ToLower() == System.Web.HttpContext.Current.User.Identity.Name.Trim().ToLower());
            int userID = user.id;
           
            if (ModelState.IsValid)
            {
                SquaresEntities db = new SquaresEntities();
                List<string> pieces = new List<string>();

                var squareSet = new Set
                {
                    name = set.name,
                    userId = userID,
                    description = set.description,
                    creationDate = DateTime.Now,
                    //likes = ,
                    //sizeData = ,
                    combinationData = "666",
                };
                
                //Create folders for set
                string relativePath = "/Images/" + userID + "/" + set.name;
                string path = Server.MapPath(relativePath);
                Directory.CreateDirectory(path);

                //Lopp through pieces, save, and save path
                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null)
                    {
                        string p = string.Empty;
                        p = Server.MapPath(relativePath + "/"); // make a new path to save images
                        pieces.Add(relativePath + "/" + file.FileName); // the path in database
                        file.SaveAs(p + file.FileName);
                    }
                }

                db.Sets.Add(squareSet);
                db.SaveChanges();
                int setID = squareSet.id;

                CreateSet(setID, pieces);

                return RedirectToAction("Details", new { id = squareSet.id });

            }
            //redirect
            return View(set);
        }
        
        public void CreateSet(int setID, List<string> pieces)
        {
            foreach (string piece in pieces)
            {
                Piece p = new Piece
                {
                    setId = setID,
                    imgURL_full = piece
                };
                db.Pieces.Add(p);
            }
            db.SaveChanges();
        }

        // GET: Users/UploadSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Set set = db.Sets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            ViewBag.userId = new SelectList(db.Users, "id", "username", set.userId);
            return View(set);
        }

        // POST: Users/UploadSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,userId,creationDate,likes,sizeData,combinationData")] Set set)
        {
            if (ModelState.IsValid)
            {
                db.Entry(set).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.userId = new SelectList(db.Users, "id", "username", set.userId);
            return View(set);
        }

        // GET: Users/UploadSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Set set = db.Sets.Find(id);
            if (set == null)
            {
                return HttpNotFound();
            }
            return View(set);
        }

        // POST: Users/UploadSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Set set = db.Sets.Find(id);
            db.Sets.Remove(set);
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

