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
    public class RecetasController : Controller
    {
        private readonly IRepository repository;

        public RecetasController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Recetas
        public IActionResult Index()
        {
            return View(this.repository.GetRecetas());
        }

        // GET: Recetas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = this.repository.GetReceta(id.Value);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // GET: Recetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recetas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Receta receta)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddReceta(receta);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receta);
        }

        // GET: Recetas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = this.repository.GetReceta(id.Value);
            if (receta == null)
            {
                return NotFound();
            }
            return View(receta);
        }

        // POST: Recetas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Receta receta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateReceta(receta);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.RecetaExists(receta.Id))
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
            return View(receta);
        }

        // GET: Recetas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = this.repository.GetReceta(id.Value);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // POST: Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receta = this.repository.GetReceta(id);
            this.repository.RemoveReceta(receta);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
