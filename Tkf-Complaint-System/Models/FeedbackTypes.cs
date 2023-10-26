using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tkf_Complaint_System.Models
{
    public class FeedbackTypes
    {
        [Key]
        public int Id { get; set; }
        public string FeedbackType { get; set; }
        public DateTime CreatedAT { get; set; }
        public bool isActive { get; set; }
        public ICollection<FeedbackSubtypes>feedbackSubtypes { get; set; }
    }

    public class FeedbackSubtypes
    {
        [Key]
        public int Id { get; set; }
        
        public string FeedbackSubtype { get; set; }


        public int Feedbacktype { get; set; }

        [ForeignKey("Feedbacktype")]
        public FeedbackTypes FeedbackTypes { get; set; }

        public DateTime CreatedAT { get; set;}
        public bool isActive { get; set; }

    }
}
