using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tkf_Complaint_System.Models
{
    public class Province
    {
    [Key]
    public int ProvinceId { get; set; }

    [Required]
    public string ProvinceName { get; set; }

    public ICollection<District> Districts { get; set; }
    }

    public class District
    {
    [Key]
    public int DistrictId { get; set; }

    [Required]
    public string DistrictName { get; set; }

    public int ProvinceId { get; set; }

    [ForeignKey("ProvinceId")]
    public Province Province { get; set; }

    public ICollection<City> cities { get; set; }
    }

    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }

        public int DistrictId { get; set; }

        [ForeignKey("DistrictId")]
        public District District { get; set; }

        public ICollection<UC> UCs { get; set; }


    }

    public class UC
    {
        [Key]
        public int UCId { get; set; }

        [Required]
        public string UCName { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public ICollection<Village> villages { get; set; }
    }

    public class Village
    {
        [Key]
        public int VillageId { get; set; }

        [Required]
        public string VillageName { get; set; }

        public int UCId { get; set; }

        [ForeignKey("UCId")]
        public UC uC { get; set; }

        public ICollection<Project> projects { get; set; }
    }

    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public int VillageId { get; set; }

        [ForeignKey("VillageId")]
        public Village village { get; set; }
    }

}
