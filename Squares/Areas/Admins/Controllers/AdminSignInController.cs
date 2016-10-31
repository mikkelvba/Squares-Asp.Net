using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Squares.Models;

namespace Squares.Areas.Admins.Controllers
{
    public class AdminSignInController : Controller
    {
        private SquaresEntities db = new SquaresEntities();

        // GET: Admins/AdminsSignIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "id,username,fullName,email,password,signupDate")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(admin.email, admin.password))
                {
                    FormsAuthentication.SetAuthCookie(admin.email, false);

                    return RedirectToAction("Index", "Panel");
                }
                else
                {
                    ModelState.AddModelError("", "Sign In is incorrect");
                }
            }
            return View(admin);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private bool IsValid(string email, string password)
        {
            bool IsValid = false;

            using (db)
            {
                var admin = db.Admins.FirstOrDefault(u => u.email == email);

                if (admin != null)
                {
                    if (admin.password == password)
                    {
                        //var dateTime = DateTime.Now;
                        //admin.lastSignin = dateTime;
                        //db.SaveChanges();

                        IsValid = true;
                    }
                }
            }

            return IsValid;
        }

    }
}