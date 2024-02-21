using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models.DirectoryViewModel;

namespace Tkf_Complaint_System.Controllers.DirectorySettings
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentApiController : ControllerBase
    {
        readonly Tkf_Complaint_System_Context _context;
        public DepartmentApiController(Tkf_Complaint_System_Context complaint_System) {
            _context = complaint_System;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }
        [HttpGet("getDepartments/{DepartmentTypeId}")]
        public async Task<IActionResult> GetDepartments(int DepartmentTypeId)
        {
            if (DepartmentTypeId == 1)
            {
                var dpt_subtypes = await
                _context.DeptSubTypes
                .Where(x => x.DepartmentTypeId == 1)
                .ToListAsync();
                return Ok(dpt_subtypes);
            }
            else if(DepartmentTypeId == 2) 
            {
                var dpt_subtypes = await
                _context.DeptSubTypes
                .Where(x => x.DepartmentTypeId == 2)
                .ToListAsync();
                return Ok(dpt_subtypes);
            }
            else
            {
                var dpt_subtypes = await
                _context.DeptSubTypes
                .ToListAsync();
                return Ok(dpt_subtypes);
            }
        }

        [HttpGet("getDirectories/{DeptType}")]
        public async Task<IActionResult> GetDirectories(int DeptType, int? cityId)
        {
            try
            {
                if (DeptType != null)
                {
                    var departmentsWithPersons = await _context.Departments
                    .Where(x => x.DepartmentTypeId == DeptType && (cityId == null || x.DirectoryCityId == cityId))
                    .Include(p => p.Persons)
                    .ToListAsync();

                    var result = departmentsWithPersons.Select(department => new DepartmentApiResponse
                    {
                        Id = department.Id,
                        DepartmentName = department.DepartmentName,
                        DeptSubTypeId = department.DeptSubTypeId,
                        SubType_Name = department.DeptSubType?.SubType_Name,
                        Persons = department.Persons?.Select(person => new PersonResponse
                        {
                            PersonId = person.PersonId,
                            PersonName = person.PersonName,
                            Designation = person.Designation,
                            Phone = person.Phone,
                        }).ToList()
                    });


                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return Ok();
        }

    }
}
