using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportData.Data;
using SportData.Models;

namespace SportData.Controllers
{
    public class EmployeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employe.Include(e => e.Organisation).Where(a => a.Validation);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Attente()
        {
            var applicationDbContext = _context.Employe.Include(e => e.Organisation).Where(a => !a.Validation && !a.Traitement);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .Include(e => e.Organisation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        public IActionResult PageLoginEmploye(string? messageerreur)
        {
            string message = "";
            if(messageerreur != null)
            {
                message = messageerreur;
            }
            ViewBag.messageerreur = message;
            return View();
        }

        [HttpPost]
        public IActionResult LoginEmploye(string adressecourriel, string motdepasse)
        {
            List<Employe> employe = _context.Employe
                    .Where(a => a.AdresseCourriel.ToLower().Equals(adressecourriel.ToLower()) && a.MotDePasse.ToLower().Equals(motdepasse.ToLower()) && a.Validation == true)
                    .ToList();
            if (employe.Count > 0)
            {
                HttpContext.Session.SetString("idemploye", employe[0].Id + "");
                return RedirectToAction("Index", "Evenement");
            }
            else
            {
                return RedirectToAction("PageLoginEmploye", new { messageerreur = "Verifiez vos identifiants" });
            }
        }

        // GET: Employe/Create
        public IActionResult Create()
        {
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom");
            return View();
        }

        // POST: Employe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,AdresseCourriel,MotDePasse,Validation,IdOrganisation")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employe);
                await _context.SaveChangesAsync();
                return RedirectToAction("PageLoginEmploye");
            }
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom", employe.IdOrganisation);
            return View(employe);
        }

        // GET: Employe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom", employe.IdOrganisation);
            return View(employe);
        }

        // POST: Employe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,AdresseCourriel,MotDePasse,Validation,IdOrganisation")] Employe employe)
        {
            if (id != employe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeExists(employe.Id))
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
            ViewData["IdOrganisation"] = new SelectList(_context.Organisation, "Id", "Nom", employe.IdOrganisation);
            return View(employe);
        }

        // GET: Employe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employe = await _context.Employe
                .Include(e => e.Organisation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employe == null)
            {
                return NotFound();
            }

            return View(employe);
        }

        // POST: Employe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employe = await _context.Employe.FindAsync(id);
            if (employe != null)
            {
                _context.Employe.Remove(employe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeExists(int id)
        {
            return _context.Employe.Any(e => e.Id == id);
        }
    }
}
