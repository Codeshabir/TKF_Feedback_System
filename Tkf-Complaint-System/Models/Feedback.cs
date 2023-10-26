using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tkf_Complaint_System.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        //[Required]
        public int ClientId { get; set; }

        public ClientInformation? ClientInformation { get; set; }

        //[Required]
        public DateTime ComplaintDate { get; set; } 

        //[Required]
        public string Type { get; set; }

        //[Required]
        public string SubType { get; set; }

        //[Required]
        public string ComplaintFeedbackRemarks { get; set; }

        //[Required]
        public string FeedBackPriority { get; set; }

        public int ProjectId { get; set; }

        public Project_tbl? Project { get; set; }

        // 
        [JsonIgnore]
        public string FeedbackByAdmin { get; set; } = "";

        [JsonIgnore]
        public DateTime FeedbackResponseDate { get; set; }

        public int StatusId { get; set; } 

        // Navigation property for the Status relationship
        [ForeignKey("StatusId")]
        public Status? Status { get; set; }
    }
}
