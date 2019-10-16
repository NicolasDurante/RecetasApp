using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecetasApp.Web.Data;
using RecetasApp.Web.Data.Entities;

namespace RecetasApp.Web.Controllers
{
    public class PasosRecetasController : Controller
    {
        private readonly DataContext _context;

        public PasosRecetasController(DataContext context)
        {
            _context = context;
        }

        // GET: PasosRecetas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.PasosRecetas.Include(p => p.Receta);
            return View(await dataContext.ToListAsync());
        }

        // GET: PasosRecetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasosReceta = await _context.PasosRecetas
                .Include(p => p.Receta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasosReceta == null)
            {
                return NotFound();
            }

            return View(pasosReceta);
        }

        // GET: PasosRecetas/Create
        public IActionResult Create()
        {
            ViewData["RecetaId"] = new SelectList(_context.Recetas, "Id", "Descripcion");
            return View();
        }

        // POST: PasosRecetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RecetaId,NumPaso,Instrucciones")] PasosReceta pasosReceta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasosReceta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecetaId"] = new SelectList(_context.Recetas, "Id", "Descripcion", pasosReceta.RecetaId);
            return View(pasosReceta);
        }

        // GET: PasosRecetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasosReceta = await _context.PasosRecetas.FindAsync(id);
            if (pasosReceta == null)
            {
                return NotFound();
            }
            ViewData["RecetaId"] = new SelectList(_context.Recetas, "Id", "Descripcion", pasosReceta.RecetaId);
            return View(pasosReceta);
        }

        // POST: PasosRecetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RecetaId,NumPaso,Instrucciones")] PasosReceta pasosReceta)
        {
            if (id != pasosReceta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasosReceta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasosRecetaExists(pasosReceta.Id))
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
            ViewData["RecetaId"] = new SelectList(_context.Recetas, "Id", "Descripcion", pasosReceta.RecetaId);
            return View(pasosReceta);
        }

        // GET: PasosRecetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasosReceta = await _context.PasosRecetas
                .Include(p => p.Receta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasosReceta == null)
            {
                return NotFound();
            }

            return View(pasosReceta);
        }

        // POST: PasosRecetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasosReceta = await _context.PasosRecetas.FindAsync(id);
            _context.PasosRecetas.Remove(pasosReceta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasosRecetaExists(int id)
        {
            return _context.PasosRecetas.Any(e => e.Id == id);
        }
    }
}
