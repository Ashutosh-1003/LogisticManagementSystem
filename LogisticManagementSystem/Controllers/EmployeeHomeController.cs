using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{    [Authorize]
    public class EmployeeHomeController : Controller
    {
        // GET: Admin
       
             public ActionResult EmployeeAuth(LoginModel ologinModel )
        {

            if (ologinModel.Role == "Admin")
            {

                return RedirectToAction("AdminHome", "Admin", ologinModel);
            }
            else if (ologinModel.Role == "Employee")
            {
                return RedirectToAction("EmployeeHome", "Employee", ologinModel);
            } else if (ologinModel.Role == "driver")
            {
                return RedirectToAction("DriverHome", "Driver", ologinModel);
             }
            return null;
            
        }
   
    }
}