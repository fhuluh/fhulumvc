using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestFhulu.Models;

namespace TestFhulu.Controllers
{
    public class AccountController : Controller
    {
        usersbdEntities Db = new usersbdEntities();

        public ActionResult Login()
        {

            return View();
            ViewBag.Message = "";

        }

        [HttpPost]
        public ActionResult Login(Login log)
        {
           var result = Db.Logins.Where(a => a.Username == log.Username && a.Password == log.Password).ToList();
           
           
           if (result.Count() > 0)
            {
                Session["LoginID"] = result[0].LoginID;
                FormsAuthentication.SetAuthCookie(result[0].Username, false);

                if (result[0].RoleID == 1)
                {

                    return RedirectToAction("../Admin/Index");
                }
                else if (result[0].RoleID == 2)
                {

                    return RedirectToAction("../Users/Index");
                }
            }

            else
            {
                ViewBag.Message = "Incorect username or password";

            }

            return View(log);
        }


        public ActionResult Logout()
        {
            Session["LoginID"] = 0;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

	}
}