using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IARehabilitation.web.Data;
using IARehabilitation.web.Data.Entities;

namespace IARehabilitation.web.Controllers
{
    public class ProfesionalsController : Controller
    {
        private readonly DataContext _context;

        public ProfesionalsController(DataContext context)
        {
            _context = context;
        }

        // GET: Profesionals
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Profesionals.Include(p => p.User);
            return View(await dataContext.ToListAsync());
        }

        // GET: Profesionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionals
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id_Profesional == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesionals/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Profesionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Profesional,ProfessionalLicence,Speciality,UserId")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", profesional.UserId);
            return View(profesional);
        }

        // GET: Profesionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionals.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", profesional.UserId);
            return View(profesional);
        }

        // POST: Profesionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Profesional,ProfessionalLicence,Speciality,UserId")] Profesional profesional)
        {
            if (id != profesional.Id_Profesional)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalExists(profesional.Id_Profesional))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", profesional.UserId);
            return View(profesional);
        }

        // GET: Profesionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionals
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id_Profesional == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // POST: Profesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesional = await _context.Profesionals.FindAsync(id);
            if (profesional != null)
            {
                _context.Profesionals.Remove(profesional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionalExists(int id)
        {
            return _context.Profesionals.Any(e => e.Id_Profesional == id);
        }
    }
}
