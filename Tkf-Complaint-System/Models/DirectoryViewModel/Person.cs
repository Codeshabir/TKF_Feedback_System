namespace Tkf_Complaint_System.Models.DirectoryViewModel
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Foreign key for Department
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
