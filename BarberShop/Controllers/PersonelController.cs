using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
