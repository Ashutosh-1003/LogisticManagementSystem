using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogisticManagementSystem.Models
{  
    [Authorize]
    public class EmployeeController : Controller
    {
        
        [Authorize(Roles = "Employee")]
        public ActionResult EmployeeHome(LoginModel oLoginModel)
        {   
            
           // Session["details"] = oEmloyeeLoginModel.WorkLocation;
            return View("EmployeeHome",null,oLoginModel.Worklocation);
           
        } 
         public ActionResult ARRIVALORDER(string Worklocation)
        {
            EmployeeManager oEmployeeManager = new EmployeeManager();
            //string s = Session["details"].ToString();
            List<ShipmentModel> oShipmentModels = oEmployeeManager.ArrivalsDetails(Worklocation);
            return View("ArriValDetailsPage", oShipmentModels);

        }
        public ActionResult GetIddetails(ShipmentModel oShipmentModel)
        {
            return View("ShipmentidDetailspage", oShipmentModel);
        }
         public ActionResult ShipmentOrder(string Worklocation)
        {
            EmployeeManager oEmployeeManager = new EmployeeManager();
            List<ShipmentModel> oShipmentModels = oEmployeeManager.ShippedItemsDetails(Worklocation);
            return View("ShippedDetailspage", oShipmentModels);
        }
    }
}