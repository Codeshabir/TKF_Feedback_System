namespace Tkf_Complaint_System.Models;
using System.Collections.Generic;

public class DropDownViewModel
{
    public int SelectedProvince { get; set; }
    public int SelectedDistrict { get; set; }
    public int SelectedCity { get; set; }
    public int SelectedUC { get; set; }
    public string SelectedProject { get; set; }

    public List<Province> Provinces { get; set; }
    public List<District> Districts { get; set; }
    public List<City> Cities { get; set; }
    public List<UC> UCs { get; set; }
    public List<Project> Projects { get; set; }
}
