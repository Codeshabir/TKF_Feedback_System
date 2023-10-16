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

        //public IActionResult Detail(int ClientId)
        //{
        //    var clientinfo = _context.clientInformation.FirstOrDefault();
        //    return View(clientinfo);
        //   // return View();
        //}

        public IActionResult Detail(int ClientId)
        {
            var clientInfo = _context.clientInformation
                .Include(c => c.Feedbacks) // Include related feedback data
                .FirstOrDefault(c => c.Id == ClientId);

            if (clientInfo != null)
            {
                return View(clientInfo);
            }

            // Handle the case when the client with the given ClientId is not found.
            // You can return a "Not Found" view or redirect to an error page.
            return NotFound();
        }



    }
}
