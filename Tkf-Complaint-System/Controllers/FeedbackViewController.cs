using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tkf_Complaint_System.Data;

namespace Tkf_Complaint_System.Controllers
{
    public class FeedbackViewController : Controller
    {
        private readonly Tkf_Complaint_System_Context _context;
        public FeedbackViewController(Tkf_Complaint_System_Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var clientinfo = await _context.feedbacks.ToListAsync();
            return View(clientinfo);
        }
    }
}
