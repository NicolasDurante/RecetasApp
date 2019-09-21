namespace RecetasApp.Web.Controllers.API
{
    using Data;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecetasApp.Web.Data.Entities;
    using RecetasApp.Web.Helpers;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecetasController : Controller
    {
        private readonly IRecetaRepository recetaRepository;
        private readonly IUserHelper userHelper;

        public RecetasController(IRecetaRepository recetaRepository, IUserHelper userHelper )
        {
            this.recetaRepository = recetaRepository;
            this.userHelper = userHelper;
        }

        [HttpGet]
        public IActionResult GetRecetas()
        {
            return Ok(this.recetaRepository.GetAllWithUsers());
        }



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
            var entityReceta = new Receta
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
