using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;

namespace Tkf_Complaint_System.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class DropdownController : ControllerBase 
    {
        private readonly Tkf_Complaint_System_Context _context;

        public DropdownController(Tkf_Complaint_System_Context context)
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


        [HttpGet("getdistricts")]
        public ActionResult<IEnumerable<object>> GetDistricts(string provinceName)
        {
            var districts = _context.districts
                .Where(d => d.Province.ProvinceName == provinceName)
                .Select(d => new { d.DistrictId, d.DistrictName })
                .ToList();

            return Ok(districts);
        }




        [HttpGet("getcities")]
        public ActionResult<IEnumerable<object>> GetCities(string districtName)
        {
            var cities = _context.cities
                .Where(c => c.District.DistrictName == districtName)
                .Select(c => new { c.CityId, c.CityName })
                .ToList();

            return Ok(cities);
        }

        [HttpGet("getucs")]
        public ActionResult<IEnumerable<object>> GetUCs(string cityName)
        {
            var ucs = _context.uCs
                .Where(uc => uc.City.CityName == cityName)
                .Select(uc => new { uc.UCId, uc.UCName })
                .ToList();

            return Ok(ucs);
        }

        [HttpGet("getprojects")]
        public ActionResult<IEnumerable<object>> GetProjects(string ucName)
        {
            var projects = _context.projects
                .Where(p => p.UC.UCName == ucName)
                .Select(p => new { p.ProjectId, p.ProjectName })
                .ToList();

            return Ok(projects);
        }

        
    }
}
