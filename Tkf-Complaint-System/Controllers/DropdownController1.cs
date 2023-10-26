//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using Tkf_Complaint_System.Data;
//using Tkf_Complaint_System.Models;

//namespace Tkf_Complaint_System.Controllers
//{
//    public class DropdownController1 : Controller
//    {
//        private readonly Tkf_Complaint_System_Context _context;

//        public DropdownController1(Tkf_Complaint_System_Context context)
//        {
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            var viewModel = new DropDownViewModel
//            {
//                Provinces = _context.provinces.ToList(),
//                // Other properties initialization can be done here
//            };

//            return View(viewModel);
//        }

//        [HttpGet]
//        public IActionResult GetDistricts(int provinceId)
//        {
//            var districts = _context.districts
//                .Where(d => d.ProvinceId == provinceId)
//                .Select(d => new { d.DistrictId, d.DistrictName })
//                .ToList();

//            return Json(districts);
//        }

//        [HttpGet]
//        public IActionResult GetCities(int districtId)
//        {
//            var cities = _context.cities
//                .Where(c => c.DistrictId == districtId)
//                .Select(c => new { c.CityId, c.CityName })
//                .ToList();

//            return Json(cities);
//        }

//        [HttpGet]
//        public IActionResult GetUCs(int cityId)
//        {
//            var ucs = _context.uCs
//                .Where(uc => uc.CityId == cityId)
//                .Select(uc => new { uc.UCId, uc.UCName })
//                .ToList();

//            return Json(ucs);
//        }

//        [HttpGet]
//        public IActionResult GetProjects(int ucId)
//        {
//            var projects = _context.projects
//                .Where(p => p.UCId == ucId)
//                .Select(p => new { p.ProjectId, p.ProjectName })
//                .ToList();

//            return Json(projects);
//        }

//        // Rest of your actions...
//    }
//}
