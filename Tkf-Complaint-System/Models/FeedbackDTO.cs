namespace Tkf_Complaint_System.Models
{
    internal class FeedbackDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset ComplaintDate { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string ComplaintFeedbackRemarks { get; set; }
        public string FeedBackPriority { get; set; }
        public int ProjectId { get; set; }
        public string FeedbackByAdmin { get; set; }
        public DateTime FeedbackResponseDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDate { get; set; }

        public ProjectDto Project { get; set; }


    }
}