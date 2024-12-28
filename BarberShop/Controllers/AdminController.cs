using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Controllers
{
    //[Authorize(Roles=SD.Role_Admin)]
    public class AdminController : Controller
    {
        private readonly BarberContext _context;
        public AdminController(BarberContext context)
        {
            _context = context;
        }
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var personel = _context.Personeller
                .Include(p => p.PersonelHizmetler)
                .FirstOrDefault(p => p.PersonelID == id);

            if (personel == null)
            {
                TempData["HataMesajlari"] = new List<string> { "Personel bulunamadı." };
                return RedirectToAction("PersonelList");
            }

            return View(personel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var personel = _context.Personeller
                    .Include(p => p.PersonelHizmetler)
                    .FirstOrDefault(p => p.PersonelID == id);

                if (personel == null)
                {
                    TempData["HataMesajlari"] = new List<string> { "Personel bulunamadı." };
                    return RedirectToAction("PersonelList");
                }

                // İlişkili verileri sil
                if (personel.PersonelHizmetler != null && personel.PersonelHizmetler.Any())
                {
                    _context.PersonelHizmet.RemoveRange(personel.PersonelHizmetler);
                }

                _context.Personeller.Remove(personel);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Personel başarıyla silindi.";
                return RedirectToAction("PersonelList");
            }
            catch (Exception ex)
            {
                TempData["HataMesajlari"] = new List<string> { "Bir hata oluştu: " + ex.Message };
                return RedirectToAction("PersonelList");
            }
        }

        public IActionResult HizmetList()
        {
            // Hizmetleri veritabanından alıyoruz
            var model = _context.Hizmetler.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteHizmet(int id)
        {
            var hizmet = _context.Hizmetler.FirstOrDefault(h => h.Id == id);

            if (hizmet == null)
            {
                TempData["HataMesajlari"] = new List<string> { "Hizmet bulunamadı." };
                return RedirectToAction("HizmetList");
            }

            return View(hizmet);
        }

        // Hizmeti silme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedHizmet(int id)
        {
            try
            {
                var hizmet = _context.Hizmetler.FirstOrDefault(h => h.Id == id);

                if (hizmet == null)
                {
                    TempData["HataMesajlari"] = new List<string> { "Hizmet bulunamadı." };
                    return RedirectToAction("HizmetList");
                }

                _context.Hizmetler.Remove(hizmet);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Hizmet başarıyla silindi.";
                return RedirectToAction("HizmetList");
            }
            catch (Exception ex)
            {
                TempData["HataMesajlari"] = new List<string> { "Hizmet silinirken bir hata oluştu: " + ex.Message };
                return RedirectToAction("HizmetList");
            }
        }

        public IActionResult HizmetEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HizmetEkle(Hizmet hizmet)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Hizmetler.Add(hizmet);
                    _context.SaveChanges();
                    TempData["Mesaj"] = "Hizmet başarıyla eklendi.";
                    return RedirectToAction("HizmetList");
                }
                catch (Exception ex)
                {
                    TempData["HataMesajlari"] = new List<string> { "Hizmet eklenirken bir hata oluştu: " + ex.Message };
                }
            }
            else
            {
                TempData["HataMesajlari"] = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
            }

            return View(hizmet);
        }

    }



}










    
