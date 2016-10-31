using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Squares.Models;
using System.Data.SqlClient;

namespace Squares.Controllers
{
    public class SignUpController : Controller
    {
        private SquaresEntities db = new SquaresEntities();

        // GET: SignUp/Create
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "username,fullName,email,password")] User user)
        {
            if (ModelState.IsValid)
            {
                // Define the SQL parameters used for the procedure:
                SqlParameter username = new SqlParameter("@username", user.username);
                SqlParameter fullName = new SqlParameter("@fullName", user.fullName);
                SqlParameter email = new SqlParameter("@email", user.email);
                SqlParameter password = new SqlParameter("@passw", user.password);

                // Call the "Create User" stored procedure:
                db.Database.ExecuteSqlCommand("PROC_CreateUser @username, @fullName, @email, @passw", username, fullName, email, password);


                return RedirectToAction("Index", "UserSignIn", new { area = "Users" });

            }
            return View(user);
        }

        //public ActionResult Index([Bind(Include = "id,username,fullName,email,password,signupDate,lastSignin")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dateTime = DateTime.Now;
        //        user.signupDate = dateTime;

        //        db.Users.Add(user);
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "UserSignIn", new { area = "Users" });
        //    }

        //    return View(user);
        //}

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
