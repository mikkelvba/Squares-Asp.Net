using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Squares.Areas.Admins.Controllers
{
    public class AdminToolsController : Controller
    {
        // GET: Admins/AdminTools
        [ChildActionOnly]
        public ActionResult AdminMenu()
        {
            string[] menuitems = { "Panel", "Admins", "Users" };

            return View("_AdminMenu", menuitems);
        }
    }
}