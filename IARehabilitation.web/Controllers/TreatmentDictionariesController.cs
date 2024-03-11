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
    public class TreatmentDictionariesController : Controller
    {
        private readonly DataContext _context;

        public TreatmentDictionariesController(DataContext context)
        {
            _context = context;
        }

        // GET: TreatmentDictionaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.TreatmentDictionaries.ToListAsync());
        }

        // GET: TreatmentDictionaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentDictionary = await _context.TreatmentDictionaries
                .FirstOrDefaultAsync(m => m.Id_TreatmentDictionary == id);
            if (treatmentDictionary == null)
            {
                return NotFound();
            }

            return View(treatmentDictionary);
        }

        // GET: TreatmentDictionaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreatmentDictionaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_TreatmentDictionary,Treatment_name,Treatment_length")] TreatmentDictionary treatmentDictionary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatmentDictionary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatmentDictionary);
        }

        // GET: TreatmentDictionaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentDictionary = await _context.TreatmentDictionaries.FindAsync(id);
            if (treatmentDictionary == null)
            {
                return NotFound();
            }
            return View(treatmentDictionary);
        }

        // POST: TreatmentDictionaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_TreatmentDictionary,Treatment_name,Treatment_length")] TreatmentDictionary treatmentDictionary)
        {
            if (id != treatmentDictionary.Id_TreatmentDictionary)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatmentDictionary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentDictionaryExists(treatmentDictionary.Id_TreatmentDictionary))
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
            return View(treatmentDictionary);
        }

        // GET: TreatmentDictionaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentDictionary = await _context.TreatmentDictionaries
                .FirstOrDefaultAsync(m => m.Id_TreatmentDictionary == id);
            if (treatmentDictionary == null)
            {
                return NotFound();
            }

            return View(treatmentDictionary);
        }

        // POST: TreatmentDictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatmentDictionary = await _context.TreatmentDictionaries.FindAsync(id);
            if (treatmentDictionary != null)
            {
                _context.TreatmentDictionaries.Remove(treatmentDictionary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentDictionaryExists(int id)
        {
            return _context.TreatmentDictionaries.Any(e => e.Id_TreatmentDictionary == id);
        }
    }
}
