﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Tkf_Complaint_System.Models
{
    public class Project_tbl
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        public string Donor { get; set; }

        //[Required]
        public string ProjectType { get; set; }

        //[Required]
        public string ProjectCode { get; set; }

        //[Required]
        public string ProjectName { get; set; }

        //[Required]
        public string ProjectProvince { get; set; }

        //[Required]
        public string ProjectDistrict { get; set; }

        public string CityName { get; set; }
        //[Required]
        public string ProjectUC { get; set; }

        public string VillageName { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
