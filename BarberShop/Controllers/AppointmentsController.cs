using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;


namespace BarberShop.Controllers
{
    public class AppointmentsController : Controller
    {
       
        [HttpPost]
        public IActionResult BekleyenRandevu(Appointments appointment)
        {
            if (ModelState.IsValid)
            {
                // Burada randevuyu veri tabanına kaydedebilirsiniz.
                // Örnek: _context.Appointments.Add(appointment);
                // _context.SaveChanges();
                TempData["success"] = "Randevu isteğiniz gönderildi!";
                
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Randevu isteğiniz başarısız, lütfen tekrar deneyin!";
            return RedirectToAction("Index", "Home");
        }

    }
}
