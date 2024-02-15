using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Tkf_Complaint_System.Models;
using Tkf_Complaint_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class DistrictController : Controller
{
    private readonly Tkf_Complaint_System_Context _context;

    public DistrictController(Tkf_Complaint_System_Context context)
    {
        _context = context;
    }

    // ... other actions

    public async Task<IActionResult> Index()
    {
        var districts = await _context.districts.ToListAsync();
        return View(districts);
    }

    [HttpGet]
    public IActionResult CreateDistrict()
    {
        ViewBag.ProvinceList = new SelectList(_context.provinces, "ProvinceId", "ProvinceName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateDistrict(District district)
    {
        if (!string.IsNullOrWhiteSpace(district.DistrictName) && district.ProvinceId != 0)
        {
            _context.Add(district);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            if (string.IsNullOrWhiteSpace(district.DistrictName))
            {
                ModelState.AddModelError("DistrictName", "District Name cannot be empty");
            }

            if (district.ProvinceId == 0)
            {
                ModelState.AddModelError("ProvinceId", "Please select a province");
            }
            ViewBag.DistrictList = new SelectList(_context.provinces, "ProvinceId", "ProvinceName", district.ProvinceId);
        }
            return View(district);
    }
   
 
    public async Task<IActionResult> Delete(int id)
    {
        if (_context.districts == null)
        {
            return Problem("Entity set 'Tkf_Complaint_System_Context.uCs'  is null.");
        }
        var districts = await _context.districts.FindAsync(id);
        if (districts != null)
        {
            _context.districts.Remove(districts);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
