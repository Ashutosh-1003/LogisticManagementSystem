using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticManagementSystem.Models;

namespace LogisticManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: LogisticHome
        public ActionResult Home()
        {
            EnquiryModelManager oEnquiryModelManager = new EnquiryModelManager();
            EnquiryModel oEnquiryModel = new EnquiryModel();
            oEnquiryModel = oEnquiryModelManager.FillState(oEnquiryModel);
          
            return View(oEnquiryModel);
        }
        [HttpPost]
        public ActionResult Home(EnquiryModel oEnquiryModel)
        {
           
            EnquiryModelManager oEnquiryModelManager = new EnquiryModelManager();
            ModelState.Clear();
            oEnquiryModelManager.InsertEnquiryDetail(oEnquiryModel);

            return RedirectToAction("Home");
        }
        public ActionResult Login()
        {
            return View();

        }
        public ActionResult About()
        {
            EnquiryModelManager oEnquiryModelManager = new EnquiryModelManager();
            EnquiryModel oEnquiryModel = new EnquiryModel();
            oEnquiryModel = oEnquiryModelManager.FillState(oEnquiryModel);
            return View(oEnquiryModel);

        }

        public ActionResult Track()
        {
            return View();
        }
    }
}