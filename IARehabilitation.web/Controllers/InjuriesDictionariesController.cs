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
    public class InjuriesDictionariesController : Controller
    {
        private readonly DataContext _context;

        public InjuriesDictionariesController(DataContext context)
        {
            _context = context;
        }

        // GET: InjuriesDictionaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.InjuriesDictionaries.ToListAsync());
        }

        // GET: InjuriesDictionaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injuriesDictionary = await _context.InjuriesDictionaries
                .FirstOrDefaultAsync(m => m.Id_Injury == id);
            if (injuriesDictionary == null)
            {
                return NotFound();
            }

            return View(injuriesDictionary);
        }

        // GET: InjuriesDictionaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InjuriesDictionaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Injury,Injury_name,Description,Injury_category")] InjuriesDictionary injuriesDictionary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(injuriesDictionary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(injuriesDictionary);
        }

        // GET: InjuriesDictionaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injuriesDictionary = await _context.InjuriesDictionaries.FindAsync(id);
            if (injuriesDictionary == null)
            {
                return NotFound();
            }
            return View(injuriesDictionary);
        }

        // POST: InjuriesDictionaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Injury,Injury_name,Description,Injury_category")] InjuriesDictionary injuriesDictionary)
        {
            if (id != injuriesDictionary.Id_Injury)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injuriesDictionary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjuriesDictionaryExists(injuriesDictionary.Id_Injury))
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
            return View(injuriesDictionary);
        }

        // GET: InjuriesDictionaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injuriesDictionary = await _context.InjuriesDictionaries
                .FirstOrDefaultAsync(m => m.Id_Injury == id);
            if (injuriesDictionary == null)
            {
                return NotFound();
            }

            return View(injuriesDictionary);
        }

        // POST: InjuriesDictionaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injuriesDictionary = await _context.InjuriesDictionaries.FindAsync(id);
            if (injuriesDictionary != null)
            {
                _context.InjuriesDictionaries.Remove(injuriesDictionary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjuriesDictionaryExists(int id)
        {
            return _context.InjuriesDictionaries.Any(e => e.Id_Injury == id);
        }
    }
}
