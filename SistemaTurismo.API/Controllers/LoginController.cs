using Microsoft.AspNetCore.Mvc;

namespace SistemaTurismo.API.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
