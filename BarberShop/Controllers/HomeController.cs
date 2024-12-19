using BarberShop.Data;
using BarberShop.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BarberShop.Controllers
{

    public class HomeController : Controller
    {
        BarberContext b = new BarberContext();

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
                Personeller = b.Personeller.ToList(),
                Appointment = new Appointments(), // Bo� bir Appointment nesnesi olu�tur
                PersonelHizmet=b.PersonelHizmet.ToList(),
            };
            var today = DateTime.Today;
            var nextSevenDays = new List<DateTime>();

            for (int i = 0; i < 7; i++)
            {
                nextSevenDays.Add(today.AddDays(i));
            }

            ViewBag.NextSevenDays = nextSevenDays;
            return View(model);
        }
        [HttpGet]
        public IActionResult GetPersonelByHizmet(int hizmetId)
        {
            var personeller = b.PersonelHizmet
                .Where(ph => ph.HizmetId == hizmetId)
                .Select(ph => new
                {
                    PersonelId = ph.PersonelId,
                    PersonelAd = ph.Personel.PersonelAd
                })
                .ToList();

            return Json(personeller);
        }

        public IActionResult GetAvailableHours(int personelId, DateOnly tarih)
        {
            // Se�ilen tarih ve personel ID'sine g�re personelin dolu saatlerini alal�m
            var doluSaatler = b.PersonelTakvim
                .Where(pt => pt.PersonelId == personelId && pt.Tarih == tarih && pt.Dolu)
                .Select(pt => pt.Saat.Hours)
                .ToList();

            return Json(doluSaatler); // Dolu saatleri JSON olarak d�nd�r�yoruz
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