using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BarberShop.Controllers
{
    
    public class AppointmentsController : Controller
    {
        private readonly BarberContext _context;

        public AppointmentsController(BarberContext context)
        {
            _context = context;
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpGet]
        public IActionResult Randevular()
        {
            // Tüm randevuları veritabanından çek
            var randevular = _context.Randevular
                .Include(r => r.Hizmet)
                .Include(r => r.Personel)
                .ToList();

            return View(randevular);
        }

        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public IActionResult Onayla(int id)
        {
            // Onaylanacak randevuyu veritabanından alıyoruz
            var randevu = _context.Randevular
                .Include(r => r.Personel)  // Personel bilgilerini de dahil ediyoruz
                .FirstOrDefault(r => r.Id == id);

            if (randevu == null)
            {
                TempData["error"] = "Randevu bulunamadı!";
                return RedirectToAction("Randevular");
            }

            // Randevuyu onaylı hale getiriyoruz
            randevu.Onayli = true;

            // Personel Takviminde o gün ve saatte 'dolu' olarak işaretliyoruz
            var personelTakvim = _context.PersonelTakvim
                .FirstOrDefault(pt => pt.PersonelId == randevu.PersonelId && pt.Tarih == randevu.Tarih && pt.Saat == randevu.Saat);

            if (personelTakvim != null)
            {
                // Eğer PersonelTakvim kaydı varsa, Dolu olarak işaretliyoruz
                personelTakvim.Dolu = true;
            }
            else
            {
                // Eğer PersonelTakvim kaydı yoksa, yeni bir kayıt oluşturuyoruz
                _context.PersonelTakvim.Add(new PersonelTakvim
                {
                    PersonelId = randevu.PersonelId,
                    Tarih = randevu.Tarih,
                    Saat = randevu.Saat,
                    Dolu = true
                });
            }

            // Değişiklikleri veritabanına kaydediyoruz
            _context.SaveChanges();

            TempData["success"] = "Randevu onaylandı ve personel takvimi güncellendi!";
            return RedirectToAction("Randevular");
        }

        [Authorize(Roles = SD.Role_Admin)]

        [HttpPost]
        public IActionResult Sil(int id)
        {
            // Silinecek randevuyu veritabanından alıyoruz
            var randevu = _context.Randevular
                .Include(r => r.Personel)  // Personel bilgilerini dahil ediyoruz
                .FirstOrDefault(r => r.Id == id);

            if (randevu == null)
            {
                TempData["error"] = "Randevu bulunamadı!";
                return RedirectToAction("Randevular");
            }

            // Personel Takvimindeki ilgili kaydı buluyoruz
            var personelTakvim = _context.PersonelTakvim
                .FirstOrDefault(pt => pt.PersonelId == randevu.PersonelId && pt.Tarih == randevu.Tarih && pt.Saat == randevu.Saat);

            if (personelTakvim != null)
            {
                // Eğer PersonelTakvim kaydı varsa, Dolu alanını false yapıyoruz
                personelTakvim.Dolu = false;
            }

            // Randevuyu Randevular tablosundan siliyoruz
            _context.Randevular.Remove(randevu);

            // Değişiklikleri veritabanına kaydediyoruz
            _context.SaveChanges();

            TempData["success"] = "Randevu silindi ve personel takvimi güncellendi!";
            return RedirectToAction("Randevular");
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult OnayliRandevular()
        {
            var onayliRandevular = _context.Randevular
                .Include(r => r.Hizmet)
                .Include(r => r.Personel)
                .Where(r => r.Onayli)
                .ToList();

            return View(onayliRandevular);
        }


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