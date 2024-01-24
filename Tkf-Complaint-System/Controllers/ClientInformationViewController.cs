using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Tkf_Complaint_System.Controllers.ClientInformationController;

namespace Tkf_Complaint_System.Controllers
{
    [Authorize]
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

        [HttpPut]
        public IActionResult UpdateFeedback(FeedbackUpdateViewModel updateModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            //    return BadRequest(new { message = "Validation failed", errors = errors });
            //}

            try
            {
                var Client = updateModel.id;
                var fdback = _context.feedbacks.FirstOrDefault(f => f.ClientId == Client);

                if (fdback == null)
                {
                    return NotFound(new { message = "Feedback not found." });
                }

                fdback.StatusId = updateModel.Action;
                fdback.FeedbackByAdmin = updateModel.Remarks;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred: " + ex.Message });
            }


        }


        public class FeedbackUpdateViewModel
        {
            
            public int id { get; set; }

            [Required(ErrorMessage = "Action is required.")]
            [Range(1, int.MaxValue, ErrorMessage = "Action must be a positive integer.")]
            public int Action { get; set; }

            [Required(ErrorMessage = "Remarks is required.")]
            public string Remarks { get; set; }
        }

        public async Task<IActionResult> Index(string clientTypeName, string statusTypeName)
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

            // Apply filters based on the parameters
            if (!string.IsNullOrEmpty(statusTypeName) && statusTypeName.ToLower() != "All")
            {
                clientInformationDTOList = clientInformationDTOList.Where(ci => ci.Feedbacks.Any(f => f.StatusName == statusTypeName)).ToList();
            }

            if (!string.IsNullOrEmpty(clientTypeName) && clientTypeName.ToLower() != "All")
            {
                clientInformationDTOList = clientInformationDTOList.Where(ci => ci.ClientType == clientTypeName).ToList();
            }


            // Populate dropdown data
            var status = await _context.feedbacks.Select(f => f.Status.StatusName).Distinct().ToListAsync();
            var clientTypes = await _context.clientInformation.Select(ci => ci.ClientType).Distinct().ToListAsync();

            ViewBag.Status = status;
            ViewBag.ClientType = clientTypes;
            ViewBag.SelectedClientType = clientTypeName; // Pass the selected client type back to the view

            return View(clientInformationDTOList);
        }

        public IActionResult Detail(int ClientInfoId)
        {
            try
            {
                var clientInfo = _context.clientInformation
                    .Include(c => c.Feedbacks)
                    .ThenInclude(f => f.Project)
                    .FirstOrDefault(c => c.Id == ClientInfoId);
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
