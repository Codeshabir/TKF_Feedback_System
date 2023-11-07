namespace Tkf_Complaint_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

   

    public class ClientInformation
    {
        public int Id { get; set; }
        public string ClientType { get; set; }
        //adding additional fields for Other's Screen
        public string OtherType { get; set; }
        public string OthersCompanyName { get; set; }
        // end 

        public string Gender { get; set; }
        public string Name { get; set; }
        public string AgeGroup { get; set; }

        public string Nationality { get; set; }

        public string CNIC { get; set; }

        public string MobileNo { get; set; }
        [EmailAddress]
        public string EmailID { get; set; }

        public string CallBackMethod { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }

    

}
