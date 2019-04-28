namespace RecetasApp.Web.Controllers
{
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

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
            return View(this.recetaRepository.GetAll());
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
        public async Task<IActionResult> Create(Receta receta)
        {
            if (ModelState.IsValid)
            {
                // TODO: Pending to change to: this.User.Identity.Name
                receta.User = await this.userHelper.GetUserByEmailAsync("fer-nicolas-durante@hotmail.com");
                await this.recetaRepository.CreateAsync(receta);
                return RedirectToAction(nameof(Index));
            }

            return View(receta);
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
                    // TODO: Pending to change to: this.User.Identity.Name
                    receta.User = await this.userHelper.GetUserByEmailAsync("fer-nicolas-durante@hotmail.com");
                    await this.recetaRepository.UpdateAsync(receta);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.recetaRepository.ExistAsync(receta.Id))
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
