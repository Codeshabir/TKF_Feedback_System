using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;

namespace Tkf_Complaint_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Tkf_Complaint_System_Context _context;


        public HomeController(ILogger<HomeController> logger, Tkf_Complaint_System_Context context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            var projectTotals = _context.feedbacks
                .GroupBy(f => f.Project.ProjectName) // Group by ProjectName
                .Select(g => new
                {
                    ProjectName = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.ProjectName, x => x.Count);
            ViewBag.ProjectTotals = projectTotals;

            var statusTotals = _context.feedbacks
                .Include(f => f.Status) // Include the associated Status
                .GroupBy(f => f.Status.StatusName) // Group by StatusName
                .Select(g => new
                {
                    StatusName = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.StatusName, x => x.Count);
            ViewBag.StatusTotals = statusTotals;


            var complaintTypeTotals = _context.feedbacks
                .GroupBy(f => f.Type) // Group by ClientType
                .Select(g => new
                {
                    ComplaintType = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.ComplaintType, x => x.Count);

            // Pass the complaint type totals to the view
            ViewBag.ComplaintTypeTotals = complaintTypeTotals;


            return View();

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}