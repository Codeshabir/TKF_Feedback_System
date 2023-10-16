using System.ComponentModel.DataAnnotations;

namespace Tkf_Complaint_System.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public DateTime CreatedDate { get; set; }
    }

}
