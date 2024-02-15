using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Tkf_Complaint_System.Models;
using Tkf_Complaint_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

[Authorize]
public class CityController : Controller
{
    private readonly Tkf_Complaint_System_Context _context;

    public CityController(Tkf_Complaint_System_Context context)
    {
        _context = context;
    }

    // ... other actions

    public async Task<IActionResult> Index()
    {
        var city = await _context.cities.ToListAsync();
        return View(city);
    }

    [HttpGet]
    public IActionResult CreateCity()
    {
        ViewBag.DistrictList = new SelectList(_context.districts, "DistrictId", "DistrictName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCity(City city)
    {
        if (!string.IsNullOrWhiteSpace(city.CityName) && city.DistrictId != 0)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            if (string.IsNullOrWhiteSpace(city.CityName))
            {
                ModelState.AddModelError("CityName", "City Name cannot be empty");
            }

            if (city.DistrictId == 0)
            {
                ModelState.AddModelError("DistrictId", "Please select a District");
            }
            ViewBag.CityList = new SelectList(_context.districts, "DistrictId", "DistrictName", city.DistrictId);
        }
        return View(city);
    }


    public async Task<IActionResult> Delete(int id)
    {
        if (_context.cities == null)
        {
            return Problem("Entity set 'Tkf_Complaint_System_Context.cities'  is null.");
        }
        var cities = await _context.cities.FindAsync(id);
        if (cities != null)
        {
            _context.cities.Remove(cities);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
