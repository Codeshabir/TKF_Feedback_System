using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tkf_Complaint_System.Data;

namespace Tkf_Complaint_System.Controllers.DirectorySettings
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentApiController : ControllerBase
    {
        readonly Tkf_Complaint_System_Context _context;
        DepartmentApiController(Tkf_Complaint_System_Context complaint_System) {
            _context = complaint_System;
        
        }
        [HttpGet("/getDptSubTypes/DepartmentTypeId{}")]
        public async Task<IActionResult> GetDepartments(int DepartmentTypeId)
        {
            
            if (DepartmentTypeId == 1)
            {
                var dpt_subtypes = await
                _context.deptSubTypes
                .Where(x => x.DepartmentTypeId == 1)
                .ToListAsync();
                return Ok(dpt_subtypes);
            }
            else
            {
                var dpt_subtypes = await
                _context.deptSubTypes
                .Where(x => x.DepartmentTypeId == 2)
                .ToListAsync();
                return Ok(dpt_subtypes);
            }

            
        }
    }
}
