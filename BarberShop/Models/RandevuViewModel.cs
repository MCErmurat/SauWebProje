using Microsoft.AspNetCore.Mvc.Rendering;

namespace BarberShop.Models
{
    public class RandevuViewModel
    {
        public List<Hizmet> Hizmetler { get; set; }
        public Appointments Appointment { get; set; }

        public List<Personel> Personeller { get; set; }
        public List<PersonelHizmet> PersonelHizmet { get; set; }

        public List<PersonelTakvim> PersonelTakvim { get; set; } // Personel takvimlerini burada tutacağız
    }
}