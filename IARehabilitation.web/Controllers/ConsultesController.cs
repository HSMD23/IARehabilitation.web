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
    public class ConsultesController : Controller
    {
        private readonly DataContext _context;

        public ConsultesController(DataContext context)
        {
            _context = context;
        }

        // GET: Consultes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultes.ToListAsync());
        }

        // GET: Consultes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulte = await _context.Consultes
                .FirstOrDefaultAsync(m => m.Id_Consulte == id);
            if (consulte == null)
            {
                return NotFound();
            }

            return View(consulte);
        }

        // GET: Consultes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Consulte,Date,Address,Id_Sportman,Id_Profesional")] Consulte consulte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consulte);
        }

        // GET: Consultes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulte = await _context.Consultes.FindAsync(id);
            if (consulte == null)
            {
                return NotFound();
            }
            return View(consulte);
        }

        // POST: Consultes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Consulte,Date,Address,Id_Sportman,Id_Profesional")] Consulte consulte)
        {
            if (id != consulte.Id_Consulte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsulteExists(consulte.Id_Consulte))
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
            return View(consulte);
        }

        // GET: Consultes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulte = await _context.Consultes
                .FirstOrDefaultAsync(m => m.Id_Consulte == id);
            if (consulte == null)
            {
                return NotFound();
            }

            return View(consulte);
        }

        // POST: Consultes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulte = await _context.Consultes.FindAsync(id);
            if (consulte != null)
            {
                _context.Consultes.Remove(consulte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsulteExists(int id)
        {
            return _context.Consultes.Any(e => e.Id_Consulte == id);
        }
    }
}
