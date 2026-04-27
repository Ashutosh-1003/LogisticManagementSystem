using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles ="Admin")]
        public ActionResult AdminHome()
        {
            ShipmentModel oShipmentModel = new ShipmentModel();
            AdminModelManager oAdminModelManager = new AdminModelManager();
            List<ShipmentModel> oDetails = oAdminModelManager.ShipmentDetailsfillAdminForm(oShipmentModel);
            return View("AdminHome", oDetails);
        }
        public ActionResult GetIddetails(ShipmentModel oShipmentModel)
        {
            AdminModelManager oAdminModelManager = new AdminModelManager();
            oAdminModelManager.DriverNames(oShipmentModel);

            return View("ShipmentidVerificationPage", oShipmentModel);
        }
        public JsonResult GetDriverInfo(string driverName)
        {
            AdminModelManager oAdminModelManager = new AdminModelManager();
            ShipmentModel oShipmentModel = oAdminModelManager.DriverInfo(driverName);
            return Json(oShipmentModel);
        }
        [HttpPost]
        public ActionResult GetIddetails(ShipmentModel oShipmentModel, string A = null)
        {
            AdminModelManager oAdminModelManager = new AdminModelManager();
            oAdminModelManager.UpdateShipmentDetails(oShipmentModel);
            return RedirectToAction("AdminHome","Admin");
        }
    }
}