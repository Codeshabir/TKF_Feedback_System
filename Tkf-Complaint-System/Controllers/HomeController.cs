using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using Tkf_Complaint_System.Areas.Identity.Data;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;

namespace Tkf_Complaint_System.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Tkf_Complaint_System_Context _context;
        private readonly UserManager<Tkf_Complaint_SystemUser> _userManager;

        public HomeController(ILogger<HomeController> logger, Tkf_Complaint_System_Context context, UserManager<Tkf_Complaint_SystemUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(string? projectName)
        {
            // Project
            var projectTotals = _context.feedbacks
                .GroupBy(f => f.Project.ProjectName)
                .Select(g => new
                {
                    ProjectName = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.ProjectName, x => x.Count);
            ViewBag.ProjectTotals = projectTotals;

            
            
            // Status
            
            var statusTotals = _context.feedbacks
                .Include(f => f.Status)
                .GroupBy(f => f.Status.StatusName)
                .Select(g => new
                {
                    StatusName = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.StatusName, x => x.Count);
            ViewBag.StatusTotals = statusTotals;

            if (projectName == null)
            {
                // Project Wise Complaint 
                var complaintTypeTotals = _context.feedbacks
                    .GroupBy(f => f.SubType)
                    .Select(g => new
                    {
                        ComplaintType = g.Key,
                        Count = g.Count()
                    })
                    .ToDictionary(x => x.ComplaintType, x => x.Count);
                ViewBag.ComplaintTypeTotals = complaintTypeTotals;

            }
            else
            {
                var feedbacksForSelectedProject = _context.feedbacks
                .Where(f => f.Project.ProjectName == projectName)
                .ToList();

                // Group feedbacks by the actual ComplaintType
                var complaintType = feedbacksForSelectedProject
                    .GroupBy(f => f.SubType)
                    .Select(g => new
                    {
                        ComplaintType = g.Key, // Use the actual ComplaintType
                        Count = g.Count()
                    })
                    .ToDictionary(x => x.ComplaintType, x => x.Count);

                ViewBag.ComplaintTypes = complaintType;
                Console.WriteLine($"ComplaintTypes count: {complaintType.Count}");




            }

            var aggregatedData = _context.feedbacks
                  .GroupBy(f => new
                  {
                      Year = f.ComplaintDate.Year,
                      Month = f.ComplaintDate.Month,
                      Gender = f.ClientInformation.Gender
                  })
                  .Select(g => new
                  {
                      Year = g.Key.Year,
                      Month = g.Key.Month,
                      Gender = g.Key.Gender,
                      Count = g.Count()
                  })
                  .GroupBy(g => new
                  {
                      Year = g.Year,
                      Gender = g.Gender
                  })
                  .Select(aggregated => new
                  {
                      Year = aggregated.Key.Year,
                      Gender = aggregated.Key.Gender,
                      TotalCount = aggregated.Sum(item => item.Count)
                  })
                  .ToList();
            return View();
        }

        public IActionResult SelectedProjGraph(string projectName)
        {
            try
            {
                var feedbacksForSelectedProject = _context.feedbacks
               .Where(f => f.Project.ProjectName == projectName)
               .ToList();

                // Group feedbacks by the actual ComplaintType
                var complaintType = feedbacksForSelectedProject
                    .GroupBy(f => f.SubType)
                    .Select(g => new
                    {
                        ComplaintType = g.Key, // Use the actual ComplaintType
                        Count = g.Count()
                    })
                    .ToDictionary(x => x.ComplaintType, x => x.Count);

                ViewBag.ComplaintTypes = complaintType;
                Console.WriteLine($"ComplaintTypes count: {complaintType.Count}");

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors here
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
            
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