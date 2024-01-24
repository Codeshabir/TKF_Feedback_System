using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Tkf_Complaint_System.Models;
using Tkf_Complaint_System.Data;
using Microsoft.EntityFrameworkCore;

public class VillageController : Controller
{
    private readonly Tkf_Complaint_System_Context _context;

    public VillageController(Tkf_Complaint_System_Context context)
    {
        _context = context;
    }

    // ... other actions

    public async Task<IActionResult> Index()
    {
        var cities = await _context.villages.ToListAsync();
        return View(cities);
    }

    [HttpGet]
    public IActionResult CreateVillage()
    {
        ViewBag.UCsList = new SelectList(_context.uCs, "UCId", "UCName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateVillage(Village village)
    {
        if (!string.IsNullOrWhiteSpace(village.VillageName) && village.UCId != 0)
        {
            _context.Add(village);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            if (string.IsNullOrWhiteSpace(village.VillageName))
            {
                ModelState.AddModelError("VillageName", "Village Name cannot be empty");
            }

            if (village.UCId == 0)
            {
                ModelState.AddModelError("UCId", "Please select a UC");
            }
            ViewBag.UCsList = new SelectList(_context.uCs, "UCId", "UCName", village.UCId);
        }
        return View(village);
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (_context.villages == null)
        {
            return Problem("Entity set 'Tkf_Complaint_System_Context.villages'  is null.");
        }
        var villages = await _context.villages.FindAsync(id);
        if (villages != null)
        {
            _context.villages.Remove(villages);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
