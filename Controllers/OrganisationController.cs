using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportData.Data;
using SportData.Models;

namespace SportData.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganisationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organisation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organisation.ToListAsync());
        }

        // GET: Organisation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organisation == null)
            {
                return NotFound();
            }

            return View(organisation);
        }

        // GET: Organisation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organisation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organisation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organisation);
        }

        // GET: Organisation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation.FindAsync(id);
            if (organisation == null)
            {
                return NotFound();
            }
            return View(organisation);
        }

        // POST: Organisation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Organisation organisation)
        {
            if (id != organisation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organisation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganisationExists(organisation.Id))
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
            return View(organisation);
        }

        // GET: Organisation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organisation == null)
            {
                return NotFound();
            }

            return View(organisation);
        }

        // POST: Organisation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisation = await _context.Organisation.FindAsync(id);
            if (organisation != null)
            {
                _context.Organisation.Remove(organisation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganisationExists(int id)
        {
            return _context.Organisation.Any(e => e.Id == id);
        }
    }
}
