using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticManagementSystem.Models
{
    public class EnquiryModel
    {   
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string JobTitle { get; set; }
            public string Company { get; set; }
            public string State { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Message { get; set; }
            public List<string> StateName = new List<string>();
        
    }
}