namespace RecetasApp.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Models;

    [Authorize]
    public class RecetasController : Controller
    {
        private readonly IRecetaRepository recetaRepository;

        private readonly IUserHelper userHelper;

        public RecetasController(IRecetaRepository recetaRepository, IUserHelper userHelper)
        {
            this.recetaRepository = recetaRepository;
            this.userHelper = userHelper;
        }

        // GET: Recetas
        public IActionResult Index()
        {
            return View(this.recetaRepository.GetAll().OrderBy(r=> r.Nombre));
        }

        // GET: Recetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await this.recetaRepository.GetByIdAsync(id.Value);
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

                    
                    receta.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.recetaRepository.CreateAsync(receta);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Receta ToReceta(RecetaViewModel view, string path)
        {
            return new Receta
            {
                Id= view.Id,
                ImagenUrl= path,
                Categoria=view.Categoria,
                Comentarios= view.Comentarios,
                Descripcion= view.Descripcion,
                Dificultad=view.Dificultad,
                Ingredientes=view.Ingredientes,
                MedidaIngredientes=view.MedidaIngredientes,
                Nombre=view.Nombre,
                NumIngredientes=view.NumIngredientes,
                Observaciones=view.Observaciones,
                Pasos=view.Pasos,
                PublicadaEn=view.PublicadaEn,
                Raciones=view.Raciones,
                Region=view.Region,
                Temporada=view.Temporada,
                Tiempo=view.Tiempo,
                UrlVideo=view.UrlVideo,
                Stock=view.Stock,
                User=view.User

            };
        }

        // GET: Recetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await this.recetaRepository.GetByIdAsync(id.Value);
            if (receta == null)
            {
                return NotFound();
            }

            var view = this.ToRecetaViewModel(receta);
            return View(view);
        }

        private RecetaViewModel ToRecetaViewModel(Receta receta)
        {
            return new RecetaViewModel
            {
                Id = receta.Id,
                Categoria = receta.Categoria,
                ImagenUrl= receta.ImagenUrl,
                Comentarios = receta.Comentarios,
                Descripcion = receta.Descripcion,
                Dificultad = receta.Dificultad,
                Ingredientes = receta.Ingredientes,
                MedidaIngredientes = receta.MedidaIngredientes,
                Nombre = receta.Nombre,
                NumIngredientes = receta.NumIngredientes,
                Observaciones = receta.Observaciones,
                Pasos = receta.Pasos,
                PublicadaEn = receta.PublicadaEn,
                Raciones = receta.Raciones,
                Region = receta.Region,
                Temporada = receta.Temporada,
                Tiempo = receta.Tiempo,
                UrlVideo = receta.UrlVideo,
                Stock = receta.Stock,
                User = receta.User
            };
        }

        // POST: Recetas/Edit/5
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

                    receta.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await this.recetaRepository.UpdateAsync(receta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.recetaRepository.ExistAsync(view.Id))
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

        // GET: Recetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await this.recetaRepository.GetByIdAsync(id.Value);
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
            var receta = await this.recetaRepository.GetByIdAsync(id);
            await this.recetaRepository.DeleteAsync(receta);
            return RedirectToAction(nameof(Index));
        }
    }

}
