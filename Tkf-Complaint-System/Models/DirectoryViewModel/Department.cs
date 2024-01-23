using System;

namespace Tkf_Complaint_System.Models.DirectoryViewModel
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string OfficialEmail { get; set; }
        public string OfficialWebsite { get; set; }
        public string OfficialPhone { get; set; }

        // Navigation property for persons
        public ICollection<Person> Persons { get; set; }
    }
}
