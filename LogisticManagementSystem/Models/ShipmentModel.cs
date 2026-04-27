using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class ShipmentModel
    {
        public int ? ShipmentId { get; set; }
        public string CompanyName { get; set; }
        public string ContactPersonName { get; set; }
        public string CompanyState { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyStreetAdd { get; set; }
        public string CompanyPinId { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyType { get; set; }
        public string GoodsWeight { get; set; }
        public string PickUpDate { get; set; }
        public string PickUpState { get; set; }
        public string PickUpCity { get; set; }
        public string PickUpStreetAdd { get; set; }
        public string PickUpPin { get; set; }
        public string DestinationState { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationStreetAdd { get; set; }
        public string DestinationPin { get; set; }
        public string DropDate { get; set; }
        public string DriverName  { get; set; }
        public string DriverEmail { get; set; }
        public string DriverNumber { get; set; }
        public string ApprovedStatus { get; set; }
        public string ProductCurrentLocation { get; set; }
        public string ShipmentActive { get; set; }
        public string DeliveryTime { get; set; }
        public string GoodsVeifactionStatus { get; set; }
        public string DeliveryNotes { get; set; }
        public string UserInfo { get; set; }
        public List<string> ListofState = new List<string>();
        public List<string> ListofCity = new List<string>();
        public List<string> ListofComtype = new List<string>();
        public List<string> ListofDriver = new List<string>();


    }
}