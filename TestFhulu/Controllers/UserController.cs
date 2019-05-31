using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFhulu.Models;

namespace TestFhulu.Controllers
{
    public class UserController : Controller
    {
        
        private usersbdEntities db = new usersbdEntities();

        // GET: /District/
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult secondPage()
        {
            return View();
        }
	}
}