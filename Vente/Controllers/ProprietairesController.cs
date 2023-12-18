using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vente.Data;
using Vente.Models;

namespace Vente.Controllers
{
    public class ProprietairesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProprietairesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proprietaires
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proprietaires.Include(p => p.Utilisateur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proprietaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proprietaires == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.Proprietaires
                .Include(p => p.Utilisateur)
                .FirstOrDefaultAsync(m => m.IDUtilisateur == id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return View(proprietaire);
        }

        // GET: Proprietaires/Create
        public IActionResult Create()
        {
            ViewData["IDUtilisateur"] = new SelectList(_context.Utilisateurs, "ID", "ID");
            return View();
        }

        // POST: Proprietaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomEntreprise,AdresseEntreprise,IDUtilisateur")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proprietaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDUtilisateur"] = new SelectList(_context.Utilisateurs, "ID", "ID", proprietaire.IDUtilisateur);
            return View(proprietaire);
        }

        // GET: Proprietaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proprietaires == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.Proprietaires.FindAsync(id);
            if (proprietaire == null)
            {
                return NotFound();
            }
            ViewData["IDUtilisateur"] = new SelectList(_context.Utilisateurs, "ID", "ID", proprietaire.IDUtilisateur);
            return View(proprietaire);
        }

        // POST: Proprietaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("NomEntreprise,AdresseEntreprise,IDUtilisateur")] Proprietaire proprietaire)
        {
            if (id != proprietaire.IDUtilisateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proprietaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietaireExists(proprietaire.IDUtilisateur))
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
            ViewData["IDUtilisateur"] = new SelectList(_context.Utilisateurs, "ID", "ID", proprietaire.IDUtilisateur);
            return View(proprietaire);
        }

        // GET: Proprietaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proprietaires == null)
            {
                return NotFound();
            }

            var proprietaire = await _context.Proprietaires
                .Include(p => p.Utilisateur)
                .FirstOrDefaultAsync(m => m.IDUtilisateur == id);
            if (proprietaire == null)
            {
                return NotFound();
            }

            return View(proprietaire);
        }

        // POST: Proprietaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Proprietaires == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Proprietaires'  is null.");
            }
            var proprietaire = await _context.Proprietaires.FindAsync(id);
            if (proprietaire != null)
            {
                _context.Proprietaires.Remove(proprietaire);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProprietaireExists(int? id)
        {
          return (_context.Proprietaires?.Any(e => e.IDUtilisateur == id)).GetValueOrDefault();
        }
    }
}
