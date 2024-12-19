using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BarberShop.Controllers
{
    public class HomeController : Controller
    {
        BarberContext b=new BarberContext();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var model = new RandevuViewModel
            {
                Hizmetler = b.Hizmetler.ToList(), // Hizmetler listesini doldur
                Personeller=b.Personeller.ToList(),
                Appointment = new Appointments(), // Boş bir Appointment nesnesi oluştur
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
