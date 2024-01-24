using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Tkf_Complaint_System.Models;
using Tkf_Complaint_System.Data;
using Microsoft.EntityFrameworkCore;

public class ProjectController : Controller
{
    private readonly Tkf_Complaint_System_Context _context;

    public ProjectController(Tkf_Complaint_System_Context context)
    {
        _context = context;
    }

    // ... other actions

    public async Task<IActionResult> Index()
    {
        var projects = await _context.projects.ToListAsync();
        return View(projects);
    }

    [HttpGet]
    public IActionResult CreateProject()
    {
        ViewBag.VillageList = new SelectList(_context.villages, "VillageId", "VillageName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProject(Project project)
    {
        if (!string.IsNullOrWhiteSpace(project.ProjectName) && project.VillageId != 0)
        {
            _context.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            if (string.IsNullOrWhiteSpace(project.ProjectName))
            {
                ModelState.AddModelError("ProjectName", "Project Name cannot be empty");
            }

            if (project.VillageId == 0)
            {
                ModelState.AddModelError("VillageId", "Please select a Village");
            }
            ViewBag.VillageList = new SelectList(_context.villages, "VillageId", "VillageName", project.VillageId);
        }
        return View(project);
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (_context.projects == null)
        {
            return Problem("Entity set 'Tkf_Complaint_System_Context.projects'  is null.");
        }
        var projects = await _context.projects.FindAsync(id);
        if (projects != null)
        {
            _context.projects.Remove(projects);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
