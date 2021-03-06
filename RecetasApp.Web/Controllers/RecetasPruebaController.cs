﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecetasApp.Web.Data;
using RecetasApp.Web.Data.Entities;
using RecetasApp.Web.Helpers;
using RecetasApp.Web.Models;

namespace RecetasApp.Web.Controllers
{
    public class RecetasPruebaController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IRecetaRepository _recetaRepository;

        public RecetasPruebaController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper, IRecetaRepository recetaRepository)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _recetaRepository = recetaRepository;

        }
        
        public IActionResult Index()
        {
            return View(_context.Recetas
                .Include(r => r.User)
                .Include(r => r.Region)
                .Include(r => r.PasosRecetas)

                .Include(r => r.RecetaIngredientes)
                .ThenInclude(i => i.Ingredientes)

                .Include(r => r.RecetaIngredientes)
                .ThenInclude(i => i.Medidas)

                .Include(r => r.Comentarios)
                .Include(r => r.Observacions)
                .Include(r => r.CategoriaComidaRecetas)

                .ThenInclude(c => c.CategoriaComidas)
                .Include(r => r.Likes)


                );
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Recetas
                .Include(r => r.User)
                .Include(r => r.Region)
                .Include(r => r.PasosRecetas)

                .Include(r => r.RecetaIngredientes)
                .ThenInclude(i => i.Ingredientes)

                .Include(r => r.RecetaIngredientes)
                .ThenInclude(i => i.Medidas)

                .Include(r => r.Comentarios)
                .Include(r => r.Observacions)
                .Include(r => r.CategoriaComidaRecetas)

                .ThenInclude(c => c.CategoriaComidas)
                .Include(r => r.Likes)

                .FirstOrDefaultAsync(m => m.Id == id);

            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        public async Task<IActionResult> AddIngrediente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Recetas.FindAsync(id.Value);
                

            if (receta == null)
            {
                return NotFound();
            }

            var model = new PasosViewModel
            {
                RecetaId= receta.Id,
               


            };

            return View(model);
        }


        // GET: Recetas1/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "NomRegion");
            ViewData["RecetaId"] = new SelectList(_context.Recetas, "Id", "Descripcion");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecetaViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";


                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Recetas",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Recetas/{file}";
                }

                var receta = this.ToReceta(view, path);



                receta.User = await this._userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                // receta.PasosRecetas.Add(pasosReceta);

                await this._recetaRepository.CreateAsync(receta);
               

                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Receta ToReceta(RecetaViewModel view, string path)
        {
            return new RecetaViewModel
            {
                Id = view.Id,
                Nombre = view.Nombre,
                Descripcion = view.Descripcion,
                Tiempo = view.Tiempo,
                Raciones = view.Raciones,
                ImagenUrl = path,
                RegionId = view.RegionId,
                Temporada = view.Temporada,
                Dificultad = view.Dificultad,
                User = view.User,
                ActiComentarios=view.ActiComentarios,
                Comentarios = view.Comentarios,
                NumLikes = view.NumLikes,

            };

        }

        // GET: Receta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await this._recetaRepository.GetByIdAsync(id.Value);
            if (receta == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions, "Id", "Id", receta.RegionId);
            var view = this.ToRecetaViewModel(receta);
            return View(view);
        }
        private RecetaViewModel ToRecetaViewModel(Receta receta)
        {
            return new RecetaViewModel
            {
                Id = receta.Id,
                Nombre = receta.Nombre,
                Descripcion = receta.Descripcion,
                Tiempo = receta.Tiempo,
                Raciones = receta.Raciones,
                ImagenUrl = receta.ImagenUrl,
                RegionId = receta.RegionId,
                Temporada = receta.Temporada,
                Dificultad = receta.Dificultad,
                User = receta.User,
                ActiComentarios = receta.ActiComentarios,
                Comentarios = receta.Comentarios,
                NumLikes = receta.NumLikes



            };
        }

    

        // POST: Receta/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RecetaViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImagenUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";


                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Recetas",
                            file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Recetas/{file}";
                    }

                    var receta = this.ToReceta(view, path);

                    // TODO: Pending to change to: this.User.Identity.Name
                    receta.User = await this._userHelper.GetUserByEmailAsync("fer-nicolas-durante@hotmail.com");
                    await this._recetaRepository.UpdateAsync(receta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this._recetaRepository.ExistAsync(view.Id))
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

            return View(view);
        }

        // GET: Receta/Delete/5
        // GET: Recetas/Delete/5
        // GET: Receta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Recetas
                .Include(r => r.User)
                .Include(r => r.Region)
                .Include(r => r.PasosRecetas)

                .Include(r => r.RecetaIngredientes)
                .ThenInclude(i => i.Ingredientes)

                .Include(r => r.RecetaIngredientes)
                .ThenInclude(i => i.Medidas)

                .Include(r => r.Comentarios)
                .Include(r => r.Observacions)
                .Include(r => r.CategoriaComidaRecetas)

                .ThenInclude(c => c.CategoriaComidas)
                .Include(r => r.Likes)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // POST: Receta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            _context.Recetas.Remove(receta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetaExists(int id)
        {
            return _context.Recetas.Any(e => e.Id == id);
        }
    }
}