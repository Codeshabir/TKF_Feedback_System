using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tkf_Complaint_System.Data;

namespace Tkf_Complaint_System.Controllers
{
    public class ClientInformationViewController : Controller
    {
        private readonly Tkf_Complaint_System_Context _context;
        public ClientInformationViewController(Tkf_Complaint_System_Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var clientinfo = await _context.clientInformation.ToListAsync();
            return View(clientinfo);
        }

       
    }
}
