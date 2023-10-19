using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tkf_Complaint_System.Models
{
    public class ClientInformationDTO
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

        //FEEDBACK DTO

        [Required]
        public int ClientId { get; set; }

        public ClientInformation? ClientInformation { get; set; }

        [Required]
        public DateTime ComplaintDate { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string SubType { get; set; }



        [Required]
        public string ComplaintFeedbackRemarks { get; set; }

        [Required]
        public string FeedBackPriority { get; set; }

        public int ProjectId { get; set; }

       // public Project_tbl? Project { get; set; }


        // 
        [JsonIgnore]
        public string FeedbackByAdmin { get; set; } = "";

        [JsonIgnore]
        public DateTime FeedbackResponseDate { get; set; }


        public int StatusId { get; set; }


        // FEEDBACK DTO

        public string StatusName { get; set; }

        public DateTime CreatedDate { get; set; }




        internal List<FeedbackDTO> Feedbacks { get; set; }
    }
}
