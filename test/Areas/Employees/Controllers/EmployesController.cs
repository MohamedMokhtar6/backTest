using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employees/Employes
        public async Task<IActionResult> Index()
        {
              return _context.Employes != null ? 
                          View(await _context.Employes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Employes'  is null.");
        }

        // GET: Employees/Employes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employes == null)
            {
                return NotFound();
            }

            var employes = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employes == null)
            {
                return NotFound();
            }

            return View(employes);
        }

        // GET: Employees/Employes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Employes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeName,EmployeePhone,EmployeeEmail,EmployeeAge,EmployeeSalary")] Employes employes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employes);
        }

        // GET: Employees/Employes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employes == null)
            {
                return NotFound();
            }

            var employes = await _context.Employes.FindAsync(id);
            if (employes == null)
            {
                return NotFound();
            }
            return View(employes);
        }

        // POST: Employees/Employes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeName,EmployeePhone,EmployeeEmail,EmployeeAge,EmployeeSalary")] Employes employes)
        {
            if (id != employes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployesExists(employes.Id))
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
            return View(employes);
        }

        // GET: Employees/Employes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employes == null)
            {
                return NotFound();
            }

            var employes = await _context.Employes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employes == null)
            {
                return NotFound();
            }

            return View(employes);
        }

        // POST: Employees/Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employes == null)
            {
                return Problem("Entity set 'AppDbContext.Employes'  is null.");
            }
            var employes = await _context.Employes.FindAsync(id);
            if (employes != null)
            {
                _context.Employes.Remove(employes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployesExists(int id)
        {
          return (_context.Employes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
