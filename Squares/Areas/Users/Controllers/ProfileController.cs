using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Squares.Models;

namespace Squares.Areas.Users.Controllers
{
    public class ProfileController : Controller
    {
        private SquaresEntities db = new SquaresEntities();

        public ActionResult Index(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.id == id);

            return View(user);
        }

    }
}