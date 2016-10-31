using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Squares.Models;

namespace Squares.Areas.Users.Controllers
{
    public class UserSignInController : Controller
    {
        private SquaresEntities db = new SquaresEntities();

        int idfinal;

        // GET: Users/UserSignIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "id,username,fullName,email,password,signupDate,lastSignin")] User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.email, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.email, false);

                    int id = user.id;

                    return RedirectToAction("Index", "Profile", new { id = idfinal });
                }
                else
                {
                    ModelState.AddModelError("", "Sign In is incorrect");
                }
            }
            return View(user);
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
                var user = db.Users.FirstOrDefault(u => u.email == email);

                if (user != null)
                {
                    if(user.password == password)
                    {
                        idfinal = user.id;

                        var dateTime = DateTime.Now;
                        user.lastSignin = dateTime;
                        db.SaveChanges();

                        IsValid = true;
                    }
                }
            }

            return IsValid;
        }

    }
}