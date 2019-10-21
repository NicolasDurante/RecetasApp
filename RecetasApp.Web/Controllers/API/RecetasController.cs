namespace RecetasApp.Web.Controllers.API
{
    using Data;
 
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RecetasApp.Web.Data.Entities;
    using RecetasApp.Web.Helpers;
    using RecetasApp.Web.Models;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class RecetasController : Controller
    {
        private readonly IRecetaRepository recetaRepository;
        private readonly IUserHelper userHelper;
        private readonly DataContext _dataContext;

        public RecetasController( IRecetaRepository recetaRepository, IUserHelper userHelper, DataContext dataContext)
        {
            
            this.recetaRepository = recetaRepository;
            this.userHelper = userHelper;
            this._dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetRecetas()
        {
            return Ok(this.recetaRepository.GetAllWithUsers());
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecetaViewModel view)
        {
        }
            
            if (ModelState.IsValid) 
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Products",
                        view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Products/{view.ImageFile.FileName}";
                }
                 
                var receta = this.ToReceta(view, path);
                // TODO: Pending to change to: this.User.Identity.Name
                receta.User = await this.userHelper.GetUserByEmailAsync("fer-nicolas-durante@hotmail.com");
                
                await this.recetaRepository.CreateAsync(receta);

                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Receta ToReceta(RecetaViewModel view, string path)
        {
            return new Receta
            {
                Id=view.Id,
                Nombre=view.Nombre,
                Descripcion=view.Descripcion,
                Tiempo = view.Tiempo,
                Raciones = view.Raciones,
                Temporada = view.Temporada,
                Dificultad = view.Descripcion,
                ActiComentarios = view.ActiComentarios,
                NumLikes = view.NumLikes,
                RegionId = view.RegionId,
                Region = view.Region,
                PasosRecetas = view.PasosRecetas.Select(p => new PasosReceta
                {
                    Id = p.Id,
                    RecetaId = view.Id,
                    NumPaso = p.NumPaso,
                    Instrucciones = p.Instrucciones,

                }).ToList(),

                ImagenUrl =path,
                User=view.User,

                RecetaIngredientes = view.RecetaIngredientes.Select(i => new RecetaIngrediente
                {
                    Id = i.Id,
                    RecetaId = view.Id,
                    Ingredientes = i.Ingredientes,
                    Medidas = i.Medidas,
                    Cantidad= i.Cantidad

                }).ToList(),

                Comentarios = view.Comentarios.Select(c => new Comentario
                {
                    Id = c.Id,
                    RecetaId = view.Id,
                    Receta = c.Receta,
                    User = c.User,
                    Comentari = c.Comentari

                }).ToList(),

                Observacions = view.Observacions.Select(o => new Observacion
                {
                    Id = o.Id,
                    RecetaId = view.Id,
                    Receta = o.Receta,
                    Observacio = o.Observacio,
                    

                }).ToList(),

                CategoriaComidaRecetas = view.CategoriaComidaRecetas.Select(c => new CategoriaComidaReceta
                {
                    Id = c.Id,
                    RecetaId = view.Id,
                    Receta = c.Receta,
                    CategoriaComidas = c.CategoriaComidas,
                   
                }).ToList(),

                Likes = view.Likes.Select(l=> new Like
                {
                    Id = l.Id,
                    RecetaId = view.Id,
                    Receta = l.Receta,
                    

                }).ToList(),
            };
        
            
           
        /*
        [HttpPost]
        [Route("GetRecetaByEmail")]
        public async Task<IActionResult> GetReceta(EmailRequest emailRequest)
        {
            var receta = await _dataContext.Recetas
                .FirstOrDefaultAsync(r => r.User.Email == emailRequest.Email);
            if(receta==null)
            {
                return NotFound();
            }




            return Ok(receta);
        }

            */
        
        
        /*

        
        [HttpPost]
        public async Task<IActionResult> PostReceta([FromBody] Common.Models.Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var user = await this.userHelper.GetUserByEmailAsync(receta.User.Email);
            if (user == null)
            {
                return this.BadRequest("Invalid user");
            }

            //TODO: Upload images
           /* var entityReceta = new Receta
            {
                Nombre = receta.Nombre,
                Descripcion = receta.Descripcion,
                Tiempo = receta.Tiempo,
                //Raciones = receta.Raciones,
                Dificultad = receta.Dificultad,
                // Region = receta.Region,
                ActiComentarios = receta.ActiComentarios,
                //NumLikes = receta.NumLikes,
                //Region = receta.Region,

                User = user
            };
            
            var newReceta = await this.recetaRepository.CreateAsync(entityReceta);
            return Ok(newReceta);
        }
        */
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta([FromRoute] int id, [FromBody] Common.Models.Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            if (id != receta.Id)
            {
                return BadRequest();
            }

            var oldReceta = await this.recetaRepository.GetByIdAsync(id);
            if (oldReceta == null)
            {
                return this.BadRequest("Receta Id don't exists.");
            }

            //TODO: Upload images
            oldReceta.Nombre = receta.Nombre;
            oldReceta.Descripcion = receta.Descripcion;
            oldReceta.Tiempo = receta.Tiempo;
            //oldReceta.Raciones = receta.Raciones;
            oldReceta.Dificultad = receta.Dificultad;
            // oldReceta.Region = receta.Region;
            oldReceta.ActiComentarios = receta.ActiComentarios;
            //oldReceta.NumLikes = receta.NumLikes;
            //oldReceta.Region = receta.Region;

            var updatedReceta = await this.recetaRepository.UpdateAsync(oldReceta);
            return Ok(updatedReceta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceta([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var receta = await this.recetaRepository.GetByIdAsync(id);
            if (receta == null)
            {
                return this.NotFound();
            }

            await this.recetaRepository.DeleteAsync(receta);
            return Ok(receta);
        }

    }
}
