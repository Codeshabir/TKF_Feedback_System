using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tkf_Complaint_System.Data;
using Tkf_Complaint_System.Models;

namespace Tkf_Complaint_System.Controllers.ProjectCRUD
{
    [Authorize]
    public class UCsController : Controller
    {
        private readonly Tkf_Complaint_System_Context _context;

        public UCsController(Tkf_Complaint_System_Context context)
        {
            _context = context;
        }

        // GET: UCs
        public async Task<IActionResult> Index()
        {
            var tkf_Complaint_System_Context = _context.uCs.Include(u => u.City);
            return View(await tkf_Complaint_System_Context.ToListAsync());
        }

        // GET: UCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.uCs == null)
            {
                return NotFound();
            }

            var uC = await _context.uCs
                .Include(u => u.City)
                .FirstOrDefaultAsync(m => m.UCId == id);
            if (uC == null)
            {
                return NotFound();
            }

            return View(uC);
        }

        // GET: UCs/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.cities, "CityId", "CityName");
            return View();
        }

        // POST: UCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UCId,UCName,CityId")] UC uC)
        {
            if (!string.IsNullOrWhiteSpace(uC.UCName) && uC.CityId != 0)
            {
                _context.Add(uC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (string.IsNullOrWhiteSpace(uC.UCName))
                {
                    ModelState.AddModelError("UCName", "UC Name cannot be empty");
                }

                if (uC.CityId == 0)
                {
                    ModelState.AddModelError("CityId", "Please select a City");
                }
                ViewData["CityId"] = new SelectList(_context.cities, "CityId", "CityName", uC.CityId);
            }
                return View(uC);
        }

        // GET: UCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.uCs == null)
            {
                return NotFound();
            }

            var uC = await _context.uCs.FindAsync(id);
            if (uC == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.cities, "CityId", "CityName", uC.CityId);
            return View(uC);
        }

        // POST: UCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UCId,UCName,CityId")] UC uC)
        {
            if (id != uC.UCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UCExists(uC.UCId))
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
            ViewData["CityId"] = new SelectList(_context.cities, "CityId", "CityName", uC.CityId);
            return View(uC);
        }

        // GET: UCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.uCs == null)
            {
                return NotFound();
            }

            var uC = await _context.uCs
                .Include(u => u.City)
                .FirstOrDefaultAsync(m => m.UCId == id);
            if (uC == null)
            {
                return NotFound();
            }

            return View(uC);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (_context.uCs == null)
            {
                return Problem("Entity set 'Tkf_Complaint_System_Context.uCs'  is null.");
            }
            var uCs = await _context.uCs.FindAsync(id);
            if (uCs != null)
            {
                _context.uCs.Remove(uCs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool UCExists(int id)
        {
          return (_context.uCs?.Any(e => e.UCId == id)).GetValueOrDefault();
        }
    }
}
