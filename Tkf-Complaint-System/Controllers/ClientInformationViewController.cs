using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;
using static Tkf_Complaint_System.Controllers.ClientInformationController;

namespace Tkf_Complaint_System.Controllers
{
    public class ClientInformationViewController : Controller
    {
        private readonly Tkf_Complaint_System_Context _context;
        public ClientInformationViewController(Tkf_Complaint_System_Context context)
        {
            _context = context;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var clientInformationDTOList = await _context.clientInformation
        //        .Include(c => c.Feedbacks)
        //        .ThenInclude(f => f.Status)
        //        .Select(ci => new ClientInformationDTO 
        //        {
        //            Id = ci.Id,
        //            ClientType = ci.ClientType,
        //            Gender = ci.Gender,
        //            Name = ci.Name,
        //            AgeGroup = ci.AgeGroup,
        //            Nationality = ci.Nationality,
        //            CNIC = ci.CNIC,
        //            MobileNo = ci.MobileNo,
        //            EmailID = ci.EmailID,
        //            CallBackMethod = ci.CallBackMethod,
        //            Feedbacks = ci.Feedbacks.Select(f => new FeedbackDTO
        //            {
        //                Id = f.Id,
        //                ClientId = f.ClientId,
        //                ComplaintDate = f.ComplaintDate,
        //                Type = f.Type,
        //                SubType = f.SubType,
        //                ComplaintFeedbackRemarks = f.ComplaintFeedbackRemarks,
        //                FeedBackPriority = f.FeedBackPriority,
        //                ProjectId = f.ProjectId,
        //                FeedbackByAdmin = f.FeedbackByAdmin,
        //                FeedbackResponseDate = f.FeedbackResponseDate,
        //                StatusId = f.StatusId,
        //                StatusName = f.Status.StatusName,
        //                CreatedDate = f.Status.CreatedDate
        //            }).ToList()
        //        })
        //        .ToListAsync();


        //    return View(clientInformationDTOList);
        //}


        public IActionResult UpdateFeedback(FeedbackUpdateViewModel updateModel)
        {
            try
            {
                var id = updateModel.id;
                var fdback = _context.feedbacks.FirstOrDefault(f => f.ClientId == id);

                if (fdback == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }

                fdback.StatusId = updateModel.Action;
                fdback.FeedbackByAdmin = updateModel.Remarks;
                _context.SaveChanges();
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred: " + ex.Message });
            }


        }
        public class FeedbackUpdateViewModel
        {
            public int id { get; set; }
            public int Action { get; set; }
            public string Remarks { get; set; }
        }

        public async Task<IActionResult> Index()
        {
            var clientInformationDTOList = await _context.clientInformation
                .Include(c => c.Feedbacks)
                .ThenInclude(f => f.Status)
                .Select(ci => new ClientInformationDTO
                {
                    Id = ci.Id,
                    ClientType = ci.ClientType,
                    Gender = ci.Gender,
                    Name = ci.Name,
                    AgeGroup = ci.AgeGroup,
                    Nationality = ci.Nationality,
                    CNIC = ci.CNIC,
                    MobileNo = ci.MobileNo,
                    EmailID = ci.EmailID,
                    CallBackMethod = ci.CallBackMethod,
                    Feedbacks = ci.Feedbacks.Select(f => new FeedbackDTO
                    {
                        Id = f.Id,
                        ClientId = f.ClientId,
                        ComplaintDate = f.ComplaintDate,
                        Type = f.Type,
                        SubType = f.SubType,
                        ComplaintFeedbackRemarks = f.ComplaintFeedbackRemarks,
                        FeedBackPriority = f.FeedBackPriority,
                        ProjectId = f.ProjectId,
                        FeedbackByAdmin = f.FeedbackByAdmin,
                        FeedbackResponseDate = f.FeedbackResponseDate,
                        StatusId = f.StatusId,
                        StatusName = f.Status.StatusName,
                        CreatedDate = f.Status.CreatedDate,
                        Project = new ProjectDto
                        {
                            Id = f.Project.Id, // Assuming this is the correct property
                            Donor = f.Project.Donor,
                            ProjectType = f.Project.ProjectType,
                            ProjectCode = f.Project.ProjectCode,
                            ProjectName = f.Project.ProjectName,
                            ProjectProvince = f.Project.ProjectProvince,
                            ProjectDistrict = f.Project.ProjectDistrict,
                            ProjectUC = f.Project.ProjectUC
                        }
                    }).ToList()
                })
                .ToListAsync();

            return View(clientInformationDTOList);
        }


        public IActionResult Detail(int ClientId)
        {
            try
            {
                var clientInfo = _context.clientInformation
                    .Include(c => c.Feedbacks)
                    .ThenInclude(f => f.Project)
                    .FirstOrDefault(c => c.Id == ClientId);
                if (clientInfo != null)
                {
                    return View(clientInfo);
                }
                return NotFound();

            }
            catch   (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred: " + ex.Message });

            }
        }
    }
}
