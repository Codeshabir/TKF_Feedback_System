using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;

namespace Tkf_Complaint_System.Controllers
{
   
    public class DropdownController1 : Controller
    {
        private readonly Tkf_Complaint_System_Context _context;

        public DropdownController1(Tkf_Complaint_System_Context context)
        {
            _context = context;
        }

        [HttpGet("index")]
        public ActionResult<DropDownViewModel> Index()
        {
            var provinces = _context.provinces.ToList();
            return Ok(provinces);
        }

        //[HttpGet("getdistricts")]
        //public ActionResult<IEnumerable<object>> GetDistricts(int provinceId)
        //{
        //    var districts = _context.districts
        //        .Where(d => d.ProvinceId == provinceId)
        //        .Select(d => new { d.DistrictId, d.DistrictName })
        //        .ToList();

        //    return Ok(districts);
        //}


    
        public ActionResult<IEnumerable<object>> GetDistricts(string provinceName)
        {
            var districts = _context.districts
                .Where(d => d.Province.ProvinceName == provinceName)
                .Select(d => new { d.DistrictId, d.DistrictName })
                .ToList();

            return Ok(districts);
        }




  
        public ActionResult<IEnumerable<object>> GetCities(string districtName)
        {
            var cities = _context.cities
                .Where(c => c.District.DistrictName == districtName)
                .Select(c => new { c.CityId, c.CityName })
                .ToList();

            return Ok(cities);
        }

        public ActionResult<IEnumerable<object>> GetUCs(string cityName)
        {
            var ucs = _context.uCs
                .Where(uc => uc.City.CityName == cityName)
                .Select(uc => new { uc.UCId, uc.UCName })
                .ToList();

            return Ok(ucs);
        }

        public ActionResult<IEnumerable<object>> GetVillages(string ucName)
        {
            var projects = _context.villages
                .Where(p => p.uC.UCName == ucName)
                .Select(p => new { p.VillageId, p.VillageName })
                .ToList();

            return Ok(projects);
        }


        public ActionResult<IEnumerable<object>> GetProjects(string villageName)
        {
            var projects = _context.projects
                .Where(p => p.village.VillageName == villageName)
                .Select(p => new { p.ProjectId, p.ProjectName })
                .ToList();

            return Ok(projects);
        }


    }
}
