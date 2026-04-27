using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{
    public class EmployeeLoginController : Controller
    {
        // GET: EmployeeLogin
        public ActionResult EmployeeLogin()
        {
            EmloyeeLoginModel oEmloyeeLoginModel = new EmloyeeLoginModel();
            return View("EmployeeLogin");
        }
          [HttpPost]
          public ActionResult EmployeeLogin(EmloyeeLoginModel oEmloyeeLoginModel)
        {
            EmployeeLoginModelManager oEmployeeLoginModelManager = new EmployeeLoginModelManager();
            oEmloyeeLoginModel = oEmployeeLoginModelManager.EmployeeAuthentication(oEmloyeeLoginModel);
            if (oEmloyeeLoginModel.IsValid == 1)
            {
                Session["Username"] = oEmloyeeLoginModel.UserName;
                FormsAuthentication.SetAuthCookie(oEmloyeeLoginModel.UserName, false);
                var authTicket = new FormsAuthenticationTicket(1, oEmloyeeLoginModel.UserEmail, DateTime.Now, DateTime.Now.AddMinutes(20), false, oEmloyeeLoginModel.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("EmployeeHome", "Employee",oEmloyeeLoginModel);
            }
            else
            {
                oEmloyeeLoginModel.LoginErrorMessage = "Wrong Username or Password";
                return View("EmployeeLogin", oEmloyeeLoginModel);
            }

        }
    }
}