using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestFhulu.Controllers
{
    public class AminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
	}
}