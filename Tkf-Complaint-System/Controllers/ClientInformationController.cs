using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;

namespace Tkf_Complaint_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientInformationController : ControllerBase
    {
        private readonly Tkf_Complaint_System_Context _context;

        public ClientInformationController(Tkf_Complaint_System_Context context)
        {
            _context = context;
        }


        // GET: api/ClientInformation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientInformation>>> GetClientInformation()
        {
            return await _context.clientInformation.ToListAsync();
        }

        // GET: api/ClientInformation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientInformation>> GetClientInformation(int id)
        {
            var clientInformation = await _context.clientInformation.FindAsync(id);

            if (clientInformation == null)
            {
                return NotFound();
            }

            return clientInformation;
        }



        //[HttpPost]
        //public async Task<ActionResult<ClientInformation>> PostClientInformation(ClientInformation clientInformation)
        //{
        //    // Convert the ComplaintDate property to UTC before saving
        //    if (clientInformation.Feedbacks != null)
        //    {
        //        foreach (var feedback in clientInformation.Feedbacks)
        //        {
        //            if (feedback.ComplaintDate.Kind != DateTimeKind.Utc)
        //            {
        //                feedback.ComplaintDate = feedback.ComplaintDate.ToUniversalTime();
        //                feedback.FeedbackResponseDate = feedback.ComplaintDate.ToUniversalTime();
        //            }
        //        }

        //    }

        //    _context.clientInformation.Add(clientInformation);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetClientInformation), new { id = clientInformation.Id }, clientInformation);
        //}




        [HttpPost]
        public async Task<ActionResult<ClientInformation>> PostClientInformation([FromBody] ClientInformationDBDTO feedbackModel)
        {
            var ClientType = feedbackModel.ClientType;
            ClientInformation clientInformation;

            if (ClientType == "OTHER")
            {
                clientInformation = new ClientInformation
                {
                    ClientType = feedbackModel.ClientType,
                    Gender = "",
                    Name = feedbackModel.Name,
                    AgeGroup = "",
                    Nationality = "",
                    CNIC = "",
                    MobileNo = feedbackModel.MobileNo,
                    EmailID = feedbackModel.EmailID,
                    CallBackMethod = feedbackModel.CallBackMethod,
                    OtherType = feedbackModel.OtherType,
                    OthersCompanyName = feedbackModel.OthersCompanyName
                };

            }

            else
            {
                clientInformation = new ClientInformation
                {
                    ClientType = feedbackModel.ClientType,
                    Gender = feedbackModel.Gender,
                    Name = feedbackModel.Name,
                    AgeGroup = feedbackModel.AgeGroup,
                    Nationality = feedbackModel.Nationality,
                    CNIC = feedbackModel.CNIC,
                    MobileNo = feedbackModel.MobileNo,
                    EmailID = feedbackModel.EmailID,
                    CallBackMethod = feedbackModel.CallBackMethod,
                    OtherType = feedbackModel.OtherType,
                    OthersCompanyName = feedbackModel.OthersCompanyName
                };
            }
             
            


            var villageId = _context.villages
                .Where(p => p.VillageName == feedbackModel.ProjectVillage)
                .Select(p => p.UCId)
                .FirstOrDefault();

            var projectId = _context.projects
                            .Where(p => p.ProjectName == feedbackModel.ProjectName && p.VillageId == villageId)
                            .Select(p => p.ProjectId)
                            .FirstOrDefault();


            var random = new Random();
            int newId;

            do
            {
                newId = random.Next(1, int.MaxValue); // Generate a random integer ID
            } while (_context.projects.Any(p => p.ProjectId == newId)); // Check if it's unique in your context



            var project = new Project_tbl
            {
                Id = newId,
                ProjectName = feedbackModel.ProjectName,
                ProjectCode = "ABC-CODE",
                ProjectDistrict = feedbackModel.ProjectDistrict,
                ProjectProvince = feedbackModel.Province,
                ProjectType = "abc",
                ProjectUC = feedbackModel.ProjectUC,
                Donor = "Donor",
                CityName = feedbackModel.ProjectCity,
                VillageName = feedbackModel.ProjectVillage



            };

            var feedback = new Feedback
            {
                ComplaintDate = DateTime.UtcNow,
                Type = feedbackModel.FeedbackType,
                SubType = feedbackModel.FeedbackSubtype,
                ComplaintFeedbackRemarks = feedbackModel.ComplaintFeedbackRemarks,
                ClientInformation = clientInformation,
                FeedBackPriority = "",
                ProjectId = projectId,
                StatusId = 1

                // Project = project  // Assign the project to the feedback
            };




            _context.clientInformation.Add(clientInformation);
            _context.feedbacks.Add(feedback);
            _context.project_Tbls.Add(project);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/ClientInformation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientInformation(int id, ClientInformation clientInformation)
        {
            if (id != clientInformation.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ClientInformation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientInformation>> DeleteClientInformation(int id)
        {
            var clientInformation = await _context.clientInformation.FindAsync(id);
            if (clientInformation == null)
            {
                return NotFound();
            }

            _context.clientInformation.Remove(clientInformation);
            await _context.SaveChangesAsync();

            return clientInformation;
        }

        //[HttpPut("feedback/{id}/")]
        //public IActionResult UpdateFeedback(int id, [FromBody] FeedbackUpdateModel updateModel)
        //{
        //    var feedback = _context.feedbacks.FirstOrDefault(f => f.ClientId == id);
        //    if (feedback == null)
        //    {
        //        return NotFound(); 
        //    }
        //    feedback.StatusId = updateModel.Action;
        //    feedback.FeedbackByAdmin = updateModel.Remarks;
        //    _context.SaveChanges();
        //    return Redirect("https://localhost:7217/ClientInformationView/Index");
       
        //}

        //public class FeedbackUpdateModel
        //{
        //    public int Action { get; set; }
        //    public string Remarks { get; set; }
        //}




        private bool ClientInformationExists(int id)
        {
            return _context.clientInformation.Any(e => e.Id == id);
        }
    }
}



