namespace Tkf_Complaint_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

   

    public class ClientInformation
    {
        public int Id { get; set; }

        [Required]
        public string ClientType { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Name { get; set; }

        public string AgeGroup { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string CNIC { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string EmailID { get; set; }

        [Required]
        public string CallBackMethod { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }

    

}
