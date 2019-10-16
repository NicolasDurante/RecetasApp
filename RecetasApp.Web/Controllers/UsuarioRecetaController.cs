namespace RecetasApp.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecetasApp.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Authorize]
    public class UsuarioRecetaController : Controller
    {
        private readonly IUsuarioRecetaRepository usuarioRecetaRepository;

        public UsuarioRecetaController(IUsuarioRecetaRepository usuarioRecetaRepository)
        {
            this.usuarioRecetaRepository = usuarioRecetaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await usuarioRecetaRepository.GetUsuarioRecetasAsync(this.User.Identity.Name);
            return View(model);
        }



    }
}
