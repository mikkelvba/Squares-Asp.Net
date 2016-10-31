using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Squares.Areas.Admins.Controllers
{
    public class PanelController : Controller
    {
        // GET: Admins/Panel
        public ActionResult Index()
        {
            return View();
        }
    }
}