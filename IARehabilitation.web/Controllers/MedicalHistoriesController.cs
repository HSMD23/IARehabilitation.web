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
    public class MedicalHistoriesController : Controller
    {
        private readonly DataContext _context;

        public MedicalHistoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: MedicalHistories
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.MedicalHistories.Include(m => m.Consulte).Include(m => m.InjuriesDictionary);
            return View(await dataContext.ToListAsync());
        }

        // GET: MedicalHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistory = await _context.MedicalHistories
                .Include(m => m.Consulte)
                .Include(m => m.InjuriesDictionary)
                .FirstOrDefaultAsync(m => m.Id_MedicalHistory == id);
            if (medicalHistory == null)
            {
                return NotFound();
            }

            return View(medicalHistory);
        }

        // GET: MedicalHistories/Create
        public IActionResult Create()
        {
            ViewData["Id_Consulte"] = new SelectList(_context.Consultes, "Id_Consulte", "Address");
            ViewData["Id_InjuriesDictionary"] = new SelectList(_context.InjuriesDictionaries, "Id_Injury", "Description");
            return View();
        }

        // POST: MedicalHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_MedicalHistory,Id_Sportsman,Id_Professional,Id_Consulte,Id_InjuriesDictionary")] MedicalHistory medicalHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Consulte"] = new SelectList(_context.Consultes, "Id_Consulte", "Address", medicalHistory.Id_Consulte);
            ViewData["Id_InjuriesDictionary"] = new SelectList(_context.InjuriesDictionaries, "Id_Injury", "Description", medicalHistory.Id_InjuriesDictionary);
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistory = await _context.MedicalHistories.FindAsync(id);
            if (medicalHistory == null)
            {
                return NotFound();
            }
            ViewData["Id_Consulte"] = new SelectList(_context.Consultes, "Id_Consulte", "Address", medicalHistory.Id_Consulte);
            ViewData["Id_InjuriesDictionary"] = new SelectList(_context.InjuriesDictionaries, "Id_Injury", "Description", medicalHistory.Id_InjuriesDictionary);
            return View(medicalHistory);
        }

        // POST: MedicalHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_MedicalHistory,Id_Sportsman,Id_Professional,Id_Consulte,Id_InjuriesDictionary")] MedicalHistory medicalHistory)
        {
            if (id != medicalHistory.Id_MedicalHistory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalHistoryExists(medicalHistory.Id_MedicalHistory))
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
            ViewData["Id_Consulte"] = new SelectList(_context.Consultes, "Id_Consulte", "Address", medicalHistory.Id_Consulte);
            ViewData["Id_InjuriesDictionary"] = new SelectList(_context.InjuriesDictionaries, "Id_Injury", "Description", medicalHistory.Id_InjuriesDictionary);
            return View(medicalHistory);
        }

        // GET: MedicalHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalHistory = await _context.MedicalHistories
                .Include(m => m.Consulte)
                .Include(m => m.InjuriesDictionary)
                .FirstOrDefaultAsync(m => m.Id_MedicalHistory == id);
            if (medicalHistory == null)
            {
                return NotFound();
            }

            return View(medicalHistory);
        }

        // POST: MedicalHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalHistory = await _context.MedicalHistories.FindAsync(id);
            if (medicalHistory != null)
            {
                _context.MedicalHistories.Remove(medicalHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalHistoryExists(int id)
        {
            return _context.MedicalHistories.Any(e => e.Id_MedicalHistory == id);
        }
    }
}
