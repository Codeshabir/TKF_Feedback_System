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
            var viewModel = new DropDownViewModel
            {
                Provinces = _context.provinces.ToList(),
                // Other properties initialization can be done here
            };

            return Ok(viewModel); 
        }

        [HttpGet("getdistricts")]
        public ActionResult<IEnumerable<object>> GetDistricts(int provinceId)
        {
            var districts = _context.districts
                .Where(d => d.ProvinceId == provinceId)
                .Select(d => new { d.DistrictId, d.DistrictName })
                .ToList();

            return Ok(districts);
        }

        [HttpGet("getcities")]
        public ActionResult<IEnumerable<object>> GetCities(int districtId)
        {
            var cities = _context.cities
                .Where(c => c.DistrictId == districtId)
                .Select(c => new { c.CityId, c.CityName })
                .ToList();

            return Ok(cities);
        }

        [HttpGet("getucs")]
        public ActionResult<IEnumerable<object>> GetUCs(int cityId)
        {
            var ucs = _context.uCs
                .Where(uc => uc.CityId == cityId)
                .Select(uc => new { uc.UCId, uc.UCName })
                .ToList();

            return Ok(ucs);
        }

        [HttpGet("getprojects")]
        public ActionResult<IEnumerable<object>> GetProjects(int ucId)
        {
            var projects = _context.projects
                .Where(p => p.UCId == ucId)
                .Select(p => new { p.ProjectId, p.ProjectName })
                .ToList();

            return Ok(projects);
        }

        
    }
}
