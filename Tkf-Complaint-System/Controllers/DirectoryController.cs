using Microsoft.AspNetCore.Mvc;

namespace Tkf_Complaint_System.Controllers
{
    public class DirectoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }


    }
}
