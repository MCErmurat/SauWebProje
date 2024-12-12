using Microsoft.AspNetCore.Mvc;
using BarberShop.Models;

namespace BarberShop.Controllers
{
    public class PersonelController : Controller
    {
        static List<Personel> personeller = new List<Personel>();
        public IActionResult PersonelEkle()
        {
            return View();
        }
        public IActionResult PerKaydet(Personel per)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemi
                personeller.Add(per);
                TempData["msj"] = per.PersonelAd + " adlı personel Kaydedildi";
                return RedirectToAction("PersonelEkle");

            }
            TempData["msj"] = "Kayıt İşlemi Başarısız";
            return RedirectToAction("PersonelEkle");
            //Hata işlemi
        }

        public IActionResult PersonelList()
        {
            return View(personeller);
        }
    }
}
