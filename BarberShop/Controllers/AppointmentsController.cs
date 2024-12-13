using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Controllers
{
    public class AppointmentsController : Controller
    {
        // Randevu formunu göster
        public IActionResult Create()
        {
            return View();
        }

        // Randevu formunu gönder
        [HttpPost]
        public IActionResult Create(Appointments appointment)
        {
            if (ModelState.IsValid)
            {
                // Burada randevuyu veri tabanına kaydedebilirsiniz.
                // Örnek: _context.Appointments.Add(appointment);
                // _context.SaveChanges();

                return RedirectToAction("Success");
            }
            return View(appointment);
        }

        // Başarı sayfası
        public IActionResult Success()
        {
            return View();
        }
    }
}
