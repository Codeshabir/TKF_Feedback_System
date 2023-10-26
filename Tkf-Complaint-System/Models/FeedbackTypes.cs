using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tkf_Complaint_System.Models
{
    public class FeedbackTypes
    {
        [Key]
        public int Id { get; set; }
        public string FeedbackType { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public ICollection<FeedbackSubtypes> FeedbackSubtypes { get; set; }
    }

    public class FeedbackSubtypes
    {
        [Key]
        public int Id { get; set; }
        public string FeedbackSubtype { get; set; }
        public int FeedbackTypeId { get; set; }

        [ForeignKey("FeedbackTypeId")]
        public FeedbackTypes FeedbackType { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
