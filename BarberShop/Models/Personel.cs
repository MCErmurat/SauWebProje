using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Personel
    {
        public int PersonelID { get; set; }

        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }

        public bool PersonelDurum { get; set; }

        public ICollection<PersonelHizmet> PersonelHizmetler { get; set; }
        public ICollection<PersonelTakvim> PersonelTakvimler { get; set; }
        public ICollection<Appointments> Appointments { get; set; }
    }
}