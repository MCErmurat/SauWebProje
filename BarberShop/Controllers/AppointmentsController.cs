using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BarberShop.Controllers
{
    public class AppointmentsController : Controller
    {
        BarberContext _context=new BarberContext();


        [HttpPost]
        public IActionResult BekleyenRandevu(Appointments appointment)
        
        {
            appointment.Hizmet = _context.Hizmetler.FirstOrDefault(h => h.Id == appointment.HizmetId);
            appointment.Personel = _context.Personeller.FirstOrDefault(p =>p.PersonelID  == appointment.PersonelId);

            if (appointment.Hizmet == null || appointment.Personel == null)
            {
                TempData["error"] = "Geçersiz hizmet veya personel seçimi!";
                return RedirectToAction("Index", "Home");
            }

            

            if (ModelState.IsValid)
            {

               
                var personelTakvim = _context.PersonelTakvim
		                            .FirstOrDefault(pt => pt.PersonelId == appointment.PersonelId && pt.Tarih == appointment.Tarih && pt.Saat == appointment.Saat);

				if (personelTakvim != null)
				{
					personelTakvim.Dolu = true; // Saat dolu olarak işaretlendi
					_context.SaveChanges();
				}
				_context.Randevular.Add(appointment);
				_context.SaveChanges();
				TempData["success"] = "Randevu isteğiniz gönderildi!";

                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Randevu isteğiniz başarısız, lütfen tekrar deneyin!";
            return RedirectToAction("Index", "Home");
        }

    }
}