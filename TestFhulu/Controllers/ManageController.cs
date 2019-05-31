using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestFhulu.Models;

namespace TestFhulu.Controllers
{
    public class ManageController : Controller
    {

        usersbdEntities DB = new usersbdEntities();

        //
        // GET: /Manage/
        public string Index()
        {
            return "Fhulufhelo Hanyahanya";
        }

        public ActionResult UserRegistraion()
        {
            ViewBag.District = DB.Districts.ToList();
            return View();

        }


        [HttpPost]
        public ActionResult UserRegistraion(User userdet)
        {


            if (ModelState.IsValid)
            {
                Login log = new Login();
                log.Username = userdet.username;
                log.Password = userdet.Password;
                log.RoleID = 2;
                log.Isdeleted = false;
                log.Createdon = DateTime.Today.Date;

                DB.Logins.Add(log);
                DB.SaveChanges();

                userdet.LoginID = DB.Logins.Max(a => a.LoginID);
                DB.Users.Add(userdet);
                DB.SaveChanges();


                return RedirectToAction("UserRegistraion");
            }

            ViewBag.District = DB.Districts.ToList();

            return View(userdet);
        }

        public JsonResult IsUsernameAvailable(string username)
        {
            return Json(!DB.Logins.Any(x => x.Username == username), JsonRequestBehavior.AllowGet);
        }

        public ActionResult UsersList()
        {
            var users = DB.Users.ToList();
            return View();
        }
    }
}