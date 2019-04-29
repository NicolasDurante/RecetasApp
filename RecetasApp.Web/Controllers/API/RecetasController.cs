namespace RecetasApp.Web.Controllers.API
{
    using Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    public class RecetasController : Controller
    {
        private readonly IRecetaRepository recetaRepository;

        public RecetasController(IRecetaRepository recetaRepository)
        {
            this.recetaRepository = recetaRepository;
        }

        [HttpGet]
        public IActionResult GetRecetas()
        {
            return Ok(this.recetaRepository.GetAll());
        }
    }
}
