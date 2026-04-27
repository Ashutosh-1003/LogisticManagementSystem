using LogisticManagementSystem.Models;
using System.Web.Mvc;

namespace LogisticManagementSystem.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Transportaion()
        {
            
            ShipmentDetailsManager oShipmentDetailsManager = new ShipmentDetailsManager();
            ShipmentModel oshipmentModel = new ShipmentModel();
            oshipmentModel = oShipmentDetailsManager.FillRequestForm(oshipmentModel);
            return View("Transportaion", oshipmentModel);
            

        }
        public JsonResult getcity(string statename)
        {

            ShipmentDetailsManager omanager = new ShipmentDetailsManager();
            ShipmentModel ocitydetails = omanager.SelectCity(statename);
           
             
            return Json(ocitydetails);


        }
        [HttpPost]
        public ActionResult Transportaion(ShipmentModel oDetails)
        {
            ShipmentModel oShipmentModel = new ShipmentModel();
            ShipmentDetailsManager oShipmentDetailsManager = new ShipmentDetailsManager();
            oShipmentDetailsManager.InsertCustomberRequest(oDetails);
            ModelState.Clear();
            oShipmentDetailsManager.ShipmentId(oShipmentModel);

            return View("Shipmentid", oShipmentModel);

        }
    }
}