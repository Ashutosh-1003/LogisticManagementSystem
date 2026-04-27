using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{
    public class DiverLoginController : Controller
    {
        // GET: DiverLogi
        public ActionResult DriverLogin()
        {
            DriverLoginModel oDriverLoginModel = new DriverLoginModel();
            return View("DriverLogin");

        }

        [HttpPost]
        public ActionResult DriverLogin(DriverLoginModel oDriverLoginModel)
        {
            DriverLoginModelManager oDriverLoginModelManager = new DriverLoginModelManager();
            oDriverLoginModel = oDriverLoginModelManager.DriverAuth(oDriverLoginModel);
            if (oDriverLoginModel.IsValid == 1)
            {
                Session["Username"] = oDriverLoginModel.UserName;
                FormsAuthentication.SetAuthCookie(oDriverLoginModel.UserName, false);
                var authTicket = new FormsAuthenticationTicket(1, oDriverLoginModel.UserEmail, DateTime.Now, DateTime.Now.AddMinutes(20), false, oDriverLoginModel.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("DriverHome", "Driver", oDriverLoginModel);
            }
            else
            {
                oDriverLoginModel.LoginErrorMessage = "Wrong Username or Password";
                return View("DriverLogin", oDriverLoginModel);
            }

        }
    }
}
    
