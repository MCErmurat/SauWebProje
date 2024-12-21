using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Controllers
{
    public class AdminController : Controller
    {
        BarberContext _context=new BarberContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonelList()
        {
            var model = _context.Personeller
                .Include(p => p.PersonelHizmetler)
                .ThenInclude(ph => ph.Hizmet)
                .ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult PersonelEkle()
        {
            var model = new PersonelEkleViewModel
            {
                Hizmetler = _context.Hizmetler
                    .Select(h => new HizmetSecimViewModel
                    {
                        HizmetId = h.Id,
                        HizmetAd = h.Ad,
                        Ucret = 0, // Başlangıçta ücret 0
                    }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PersonelEkle(PersonelEkleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Hizmetler = _context.Hizmetler
                    .Select(h => new HizmetSecimViewModel
                    {
                        HizmetId = h.Id,
                        HizmetAd = h.Ad,
                        Ucret = 0, // Hatalı veri girişi durumunda ücret sıfırlanır
                    }).ToList(); // Hizmetler listesi yeniden güncelleniyor

                return View(model);
            }

            // Yeni personel kaydı oluşturuluyor
            var yeniPersonel = new Personel
            {
                PersonelAd = model.PersonelAd,
                PersonelSoyad = model.PersonelSoyad,
                PersonelDurum = model.PersonelDurum
            };

            _context.Personeller.Add(yeniPersonel);
            _context.SaveChanges(); // Personel kaydını veritabanına ekliyoruz

            // Seçilen hizmetleri PersonelHizmet tablosuna ekliyoruz
            foreach (var hizmet in model.Hizmetler)
            {
                var personelHizmet = new PersonelHizmet
                {
                    PersonelId = yeniPersonel.PersonelID,
                    HizmetId = hizmet.HizmetId,
                    Ucret = hizmet.Ucret // PersonelHizmet tablosuna ücret bilgisi ekleniyor
                };

                _context.PersonelHizmet.Add(personelHizmet);
            }

            _context.SaveChanges(); // PersonelHizmet kayıtlarını veritabanına ekliyoruz

            TempData["SuccessMessage"] = "Personel ve hizmet bilgileri başarıyla kaydedildi.";
            return RedirectToAction("PersonelList");
        }




    }
}
