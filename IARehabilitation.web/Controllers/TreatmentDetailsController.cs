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
    public class TreatmentDetailsController : Controller
    {
        private readonly DataContext _context;

        public TreatmentDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: TreatmentDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.TreatmentDetails.ToListAsync());
        }

        // GET: TreatmentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentDetail = await _context.TreatmentDetails
                .FirstOrDefaultAsync(m => m.Id_DetalleTratamiento == id);
            if (treatmentDetail == null)
            {
                return NotFound();
            }

            return View(treatmentDetail);
        }

        // GET: TreatmentDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TreatmentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_DetalleTratamiento,Id_Consulte,Id_TreatmentDictionary")] TreatmentDetail treatmentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treatmentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treatmentDetail);
        }

        // GET: TreatmentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentDetail = await _context.TreatmentDetails.FindAsync(id);
            if (treatmentDetail == null)
            {
                return NotFound();
            }
            return View(treatmentDetail);
        }

        // POST: TreatmentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_DetalleTratamiento,Id_Consulte,Id_TreatmentDictionary")] TreatmentDetail treatmentDetail)
        {
            if (id != treatmentDetail.Id_DetalleTratamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treatmentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreatmentDetailExists(treatmentDetail.Id_DetalleTratamiento))
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
            return View(treatmentDetail);
        }

        // GET: TreatmentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatmentDetail = await _context.TreatmentDetails
                .FirstOrDefaultAsync(m => m.Id_DetalleTratamiento == id);
            if (treatmentDetail == null)
            {
                return NotFound();
            }

            return View(treatmentDetail);
        }

        // POST: TreatmentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treatmentDetail = await _context.TreatmentDetails.FindAsync(id);
            if (treatmentDetail != null)
            {
                _context.TreatmentDetails.Remove(treatmentDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreatmentDetailExists(int id)
        {
            return _context.TreatmentDetails.Any(e => e.Id_DetalleTratamiento == id);
        }
    }
}
