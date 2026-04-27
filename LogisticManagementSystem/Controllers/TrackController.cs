using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        public ActionResult TrackYourShipment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TrackYourShipment(TrackModel oTrackModel)
        {
            TrackModelManager oTrackModelManager = new TrackModelManager();
            oTrackModel = oTrackModelManager.ShipmentLocationDetails(oTrackModel);
            if (oTrackModel.ApprovedStatus=="Approve"&& oTrackModel.Currentlocation!="")
            {
                string location = oTrackModel.Currentlocation;

                oTrackModel.Message = string.Format("Your Shipment current Location is {0} ", oTrackModel.Currentlocation);
            }
              else if (oTrackModel.ApprovedStatus=="Reject")
            {
                oTrackModel.Message = "Sorry we cant Proceed Your Request ";
            }
            else if (oTrackModel.ApprovedStatus is null)
            {
                oTrackModel.Message = "Your Shipment Request Is still Under Revision";
            }
             else if (oTrackModel.ApprovedStatus=="Approve"&&oTrackModel.Currentlocation=="")
            {
                oTrackModel.Message = "Your Order Is Accpted And your shipment will start Shortly Thank You";
            }
            return View("TrackYourShipment", oTrackModel);


        }
    }
}