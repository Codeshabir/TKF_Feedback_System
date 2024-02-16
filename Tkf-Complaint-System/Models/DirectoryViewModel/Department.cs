using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tkf_Complaint_System.Models.DirectoryViewModel
{
    public class DepartmentType
    {
        [Key]
        public int Id { get; set; }
        public string Dpt_Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<DeptSubType> DeptSubTypes { get; set; }
    }

    public class DeptSubType
    {
        [Key]
        public int Id { get; set; }
        public string SubType_Name { get; set; }
        public int DepartmentTypeId { get; set; }
        public DepartmentType DepartmentType { get; set; }
        public ICollection<Department> Departments { get; set; }
    }

    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentTypeId { get; set; }
        public string OfficialEmail { get; set; }
        public string OfficialWebsite { get; set; }
        public string OfficialPhone { get; set; }
        public int DeptSubTypeId { get; set; }
        public DeptSubType DeptSubType { get; set; }    
        public ICollection<Person> Persons { get; set; }
        public int DirectoryCityId { get; set; }
    }
    public class DirectoryCity
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime CreatedDate { get; set; }
    }



    public class DepartmentApiResponse
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int DeptSubTypeId { get; set; }
        public string SubType_Name { get; set; } 
        public ICollection<PersonResponse> Persons { get; set; }
    }

    public class PersonResponse
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

}
