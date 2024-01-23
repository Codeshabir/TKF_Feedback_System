// DepartmentController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models; // Make sure to include the correct namespace for your models
using Tkf_Complaint_System.Models.DirectoryViewModel;
[Controller]
[Route("directory")]
public class DirectoryController : Controller
{
    private readonly Tkf_Complaint_System_Context _context;

    public DirectoryController(Tkf_Complaint_System_Context context)
    {
        _context = context;
    }

    [HttpGet("index")]
    public async Task<IActionResult> Index()
    {
        var departments = await _context.Departments.ToListAsync();
       
        return View(departments);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Departments
            .Include(d => d.Persons)
            .FirstOrDefaultAsync(m => m.DepartmentId == id);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }
    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var departments = await _context.Departments.ToListAsync();
        ViewBag.Departments = departments;
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    [HttpPost("create")]
    public async Task<IActionResult> Create([Bind("DepartmentName,OfficialEmail,OfficialWebsite,OfficialPhone")] Department department, List<Person> persons)
    {
        
            department.Persons = persons;

            _context.Add(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        return View(department);
    }



    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Departments.FindAsync(id);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,UCName,OfficialEmail,OfficialWebsite,OfficialPhone")] Department department)
    {
        if (id != department.DepartmentId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(department);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(department.DepartmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }


    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = await _context.Departments
            .FirstOrDefaultAsync(m => m.DepartmentId == id);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DepartmentExists(int id)
    {
        return _context.Departments.Any(e => e.DepartmentId == id);
    }
}
