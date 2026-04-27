using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            LoginModel ologinview = new LoginModel();


            return View("Login");
        }
        [HttpPost]
      
        public ActionResult Login(LoginModel oLoginModel)
        {
            LoginModelManager ologinmanager = new LoginModelManager();
            oLoginModel = ologinmanager.UserAuth(oLoginModel);
            if (oLoginModel.IsValid == 1)
            {
                Session["Username"] = oLoginModel.UserName;
                FormsAuthentication.SetAuthCookie(oLoginModel.UserName, false);
                var authTicket = new FormsAuthenticationTicket(1, oLoginModel.UserEmail, DateTime.Now, DateTime.Now.AddMinutes(20), false, oLoginModel.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("EmployeeAuth", "EmployeeHome", oLoginModel);
            }
            else
            {
                oLoginModel.LoginErrorMessage = "Wrong Username or Password";
                return View("Login", oLoginModel);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult ErrorPage()
        {
            return View("Error");
        }
    }
}