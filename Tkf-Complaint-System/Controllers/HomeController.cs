using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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


        //public IActionResult Index()
        //{
        //    var projectTotals = _context.feedbacks
        //        .GroupBy(f => f.Project.ProjectName) // Group by ProjectName
        //        .Select(g => new
        //        {
        //            ProjectName = g.Key,
        //            Count = g.Count()
        //        })
        //        .ToDictionary(x => x.ProjectName, x => x.Count);
        //    ViewBag.ProjectTotals = projectTotals;

        //    var statusTotals = _context.feedbacks
        //        .Include(f => f.Status) // Include the associated Status
        //        .GroupBy(f => f.Status.StatusName) // Group by StatusName
        //        .Select(g => new
        //        {
        //            StatusName = g.Key,
        //            Count = g.Count()
        //        })
        //        .ToDictionary(x => x.StatusName, x => x.Count);
        //    ViewBag.StatusTotals = statusTotals;


        //    var complaintTypeTotals = _context.feedbacks
        //        .GroupBy(f => f.Type) // Group by ClientType
        //        .Select(g => new
        //        {
        //            ComplaintType = g.Key,
        //            Count = g.Count()
        //        })
        //        .ToDictionary(x => x.ComplaintType, x => x.Count);

        //    ViewBag.ComplaintTypeTotals = complaintTypeTotals;

        //    ViewBag.ComplaintTypeTotalsJson = JsonConvert.SerializeObject(complaintTypeTotals);




        //    return View();

        //}



        public IActionResult Index()
        {
            var projectTotals = _context.feedbacks
                .GroupBy(f => f.Project.ProjectName)
                .Select(g => new
                {
                    ProjectName = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.ProjectName, x => x.Count);
            ViewBag.ProjectTotals = projectTotals;

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

            var complaintTypeTotals = _context.feedbacks
                .GroupBy(f => f.Type)
                .Select(g => new
                {
                    ComplaintType = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.ComplaintType, x => x.Count);
           ViewBag.ComplaintTypeTotals = complaintTypeTotals;

            ViewBag.ComplaintTypeTotalsJson = JsonConvert.SerializeObject(complaintTypeTotals);

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

                        ViewBag.ComplaintData = JsonConvert.SerializeObject(aggregatedData);


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