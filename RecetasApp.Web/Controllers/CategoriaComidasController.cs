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
    public class CategoriaComidasController : Controller
    {
        private readonly DataContext _context;

        public CategoriaComidasController(DataContext context)
        {
            _context = context;
        }

        // GET: CategoriaComidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaComidas.ToListAsync());
        }

        // GET: CategoriaComidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaComida = await _context.CategoriaComidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaComida == null)
            {
                return NotFound();
            }

            return View(categoriaComida);
        }

        // GET: CategoriaComidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaComidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria")] CategoriaComida categoriaComida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaComida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaComida);
        }

        // GET: CategoriaComidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaComida = await _context.CategoriaComidas.FindAsync(id);
            if (categoriaComida == null)
            {
                return NotFound();
            }
            return View(categoriaComida);
        }

        // POST: CategoriaComidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Categoria")] CategoriaComida categoriaComida)
        {
            if (id != categoriaComida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaComida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaComidaExists(categoriaComida.Id))
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
            return View(categoriaComida);
        }

        // GET: CategoriaComidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaComida = await _context.CategoriaComidas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaComida == null)
            {
                return NotFound();
            }

            return View(categoriaComida);
        }

        // POST: CategoriaComidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaComida = await _context.CategoriaComidas.FindAsync(id);
            _context.CategoriaComidas.Remove(categoriaComida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaComidaExists(int id)
        {
            return _context.CategoriaComidas.Any(e => e.Id == id);
        }
    }
}
