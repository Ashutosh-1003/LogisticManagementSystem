using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{  
   // [Authorize]
    public class DriverController : Controller
    {
        // GET: Driver
       // [Authorize(Roles ="Driver")]
        public ActionResult DriverHome(LoginModel oLoginModel)
        {

            ShipmentModel oShipmentModel = new ShipmentModel();
            DriverModelManager oDriverModelManager = new DriverModelManager();
            oShipmentModel = oDriverModelManager.DriverShipmentDetails(oLoginModel.UserEmail);
            return View("DriverHome",oShipmentModel);
        }
      /*  public ActionResult CurrentShipmentDetails(ShipmentModel oShipmentModel)
        {
            string Drivermail = oShipmentModel.UserInfo;
            DriverModelManager oDriverModelManager = new DriverModelManager();
                oShipmentModel= oDriverModelManager.DriverShipmentDetails(Drivermail);
            return View("DriverHome", oShipmentModel);
        }*/

         public ActionResult Deliveryform(ShipmentModel oShipmentModel)
        {
            return View("Deliveryform", oShipmentModel);
        }
        [HttpPost]
        public ActionResult Deliveryform (ShipmentModel oShipmentModel,string A)
        {
            DriverModelManager oDriverModelManager = new DriverModelManager();
            oDriverModelManager.DeliveryUpdate(oShipmentModel);
            return null;
        }
        public ActionResult UpdateShipmentlocation(ShipmentModel oShipmentModel)
        {
            string PublicIP;
            PublicIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
            PublicIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(PublicIP)[0].ToString();

            //string checkURL = "https://ipinfo.io/"+a4+"/region";
            string checkURL = "https://ipinfo.io/" + PublicIP + "/city";
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(checkURL);
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            StreamReader responseStream = new StreamReader(objResponse.GetResponseStream());
            string responseRead = responseStream.ReadToEnd();

            responseRead = responseRead.Replace("\n", String.Empty);
            responseStream.Close();
            responseStream.Dispose();
            oShipmentModel.ProductCurrentLocation = responseRead;
            DriverModelManager oDriverModelManager = new DriverModelManager();
            oDriverModelManager.UpdateShipmentLocation(oShipmentModel);
            return RedirectToAction("DriverHome");
        }
    }
}