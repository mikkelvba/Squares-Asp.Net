using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Squares.Models;

namespace Squares.Controllers
{
    public class ToolsController : Controller
    {

        private SquaresEntities db = new SquaresEntities();

        // GET: Tools
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            string[] menuitems = { "Discover", "Create" };

            return View("_MainMenu", menuitems);
        }

        [ChildActionOnly]
        public ActionResult FooterMenu()
        {
            string[] menuitems = { "About", "Help" };

            return View("_FooterMenu", menuitems);
        }

        public JsonResult UniqueUserName(string username)
        {
            return Json(!db.Users.Any(user => user.username == username), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UniqueAdminName(string username)
        {
            return Json(!db.Admins.Any(admin => admin.username == username), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UniqueUserEmail(string email)
        {
            return Json(!db.Users.Any(user => user.email == email), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UniqueAdminEmail(string email)
        {
            return Json(!db.Admins.Any(admin => admin.email == email), JsonRequestBehavior.AllowGet);
        }

    }
}