using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportData.Data;
using SportData.Models;
using System.Diagnostics;

namespace SportData.Controllers
{
    public class EvenementSpecController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvenementSpecController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            List<SpecificiteEvenement> liste = _context.SpecificiteEvenement
                .Include(a => a.Sport)
                .Include(a => a.Evenement)
                .Where(a => a.IdEvenement == id)
                .ToList();
            ViewData["detailevenement"] = liste;

            ViewBag.Evenement = _context.Evenement.FirstOrDefault(a => a.Id == id).Libelle;

            return View();
        }
    }
}
