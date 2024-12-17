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
    public class AdministrateurController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministrateurController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administrateur
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Administrateur.Include(a => a.Organisation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administrateur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrateur = await _context.Administrateur
                .Include(a => a.Organisation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrateur == null)
            {
                return NotFound();
            }

            return View(administrateur);
        }

        public IActionResult PageLoginAdmin()
        {
            return View();
        }

        // GET: Administrateur/Create
        public IActionResult Create()
        {
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom");
            return View();
        }

        // POST: Administrateur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdresseCourriel,MotDePasse,Identifiant,IdOrganisation")] Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom", administrateur.IdOrganisation);
            return View(administrateur);
        }

        // GET: Administrateur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrateur = await _context.Administrateur.FindAsync(id);
            if (administrateur == null)
            {
                return NotFound();
            }
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom", administrateur.IdOrganisation);
            return View(administrateur);
        }

        // POST: Administrateur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdresseCourriel,MotDePasse,Identifiant,IdOrganisation")] Administrateur administrateur)
        {
            if (id != administrateur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrateurExists(administrateur.Id))
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
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom", administrateur.IdOrganisation);
            return View(administrateur);
        }

        // GET: Administrateur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrateur = await _context.Administrateur
                .Include(a => a.Organisation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrateur == null)
            {
                return NotFound();
            }

            return View(administrateur);
        }

        [HttpPost]
        public IActionResult ValiderEmploye(int idemploye)
        {
            Employe employe = _context.Employe.FirstOrDefault(a => a.Id == idemploye);
            employe.Validation = true;
            employe.Traitement = true;
            _context.SaveChanges();
            return RedirectToAction("Index", "Employe");
        }

        [HttpPost]
        public IActionResult RefuserEmploye(int idemploye)
        {
            Employe employe = _context.Employe.FirstOrDefault(a => a.Id == idemploye);
            employe.Traitement = true;
            _context.SaveChanges();
            return RedirectToAction("Index", "Employe");
        }

        // POST: Administrateur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrateur = await _context.Administrateur.FindAsync(id);
            if (administrateur != null)
            {
                _context.Administrateur.Remove(administrateur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrateurExists(int id)
        {
            return _context.Administrateur.Any(e => e.Id == id);
        }
    }
}
