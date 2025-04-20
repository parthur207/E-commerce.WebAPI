using Microsoft.AspNetCore.Mvc;

namespace E_commerce_WEB_API___Teste_técnico_Rota.WebAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
