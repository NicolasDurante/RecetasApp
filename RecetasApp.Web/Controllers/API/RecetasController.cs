namespace RecetasApp.Web.Controllers.API
{
    using Data;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            return Ok(this.recetaRepository.GetAllWithUsers());
        }
    }
}
