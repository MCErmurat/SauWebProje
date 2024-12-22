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
            try
            {
                // Hizmet Ad hatalarını kaldır
                foreach (var key in ModelState.Keys.Where(k => k.Contains("HizmetAd")).ToList())
                {
                    ModelState.Remove(key);
                }

                if (!ModelState.IsValid)
                {
                    model.Hizmetler = _context.Hizmetler
                        .Select(h => new HizmetSecimViewModel
                        {
                            HizmetId = h.Id,
                            HizmetAd = h.Ad,
                            Ucret = 0
                        }).ToList();

                    TempData["HataMesajlari"] = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    return View(model);
                }

                // Geçerli HizmetId'leri kontrol et
                var mevcutHizmetler = _context.Hizmetler.Select(h => h.Id).ToList();
                foreach (var hizmet in model.Hizmetler)
                {
                    if (!mevcutHizmetler.Contains(hizmet.HizmetId))
                    {
                        TempData["HataMesajlari"] = new List<string> { $"Hizmet ID {hizmet.HizmetId} geçerli değil." };
                        return View(model);
                    }
                }

                // Personel kaydetme işlemi
                var yeniPersonel = new Personel
                {
                    PersonelAd = model.PersonelAd,
                    PersonelSoyad = model.PersonelSoyad,
                    PersonelDurum = model.PersonelDurum
                };

                _context.Personeller.Add(yeniPersonel);
                _context.SaveChanges();

                // PersonelHizmet ekleme işlemi
                foreach (var hizmet in model.Hizmetler)
                {
                    var personelHizmet = new PersonelHizmet
                    {
                        PersonelId = yeniPersonel.PersonelID,
                        HizmetId = hizmet.HizmetId,
                        Ucret = hizmet.Ucret
                    };

                    _context.PersonelHizmet.Add(personelHizmet);
                }

                _context.SaveChanges();

                TempData["SuccessMessage"] = "Personel başarıyla eklendi!";
                return RedirectToAction("PersonelList");
            }
            catch (Exception ex)
            {
                // Hata loglama
                TempData["HataMesajlari"] = new List<string> { "Bir hata oluştu: " + ex.Message };

                // Hatanın detaylarını görmek için
                Console.WriteLine($"Hata: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Modeli yeniden doldur
                model.Hizmetler = _context.Hizmetler
                    .Select(h => new HizmetSecimViewModel
                    {
                        HizmetId = h.Id,
                        HizmetAd = h.Ad,
                        Ucret = 0
                    }).ToList();

                return View(model);
            }
        }

       


    }
}
