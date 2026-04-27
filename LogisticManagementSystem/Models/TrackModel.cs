using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class TrackModel
    {
        public int ShipmentId { get; set; }
        public string CustomberName { get; set; }
        public string CompanyName { get; set; }
        public string Message { get; set; }
        public string Currentlocation { get; set; }
        public string ApprovedStatus { get; set; }
         
        
    }
}