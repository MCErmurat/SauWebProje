using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{
    public class PersonelEkleViewModel
    {
        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Personel adı zorunludur.")]
        public string PersonelAd { get; set; }

        [Required(ErrorMessage = "Personel soyadı zorunludur.")]
        public string PersonelSoyad { get; set; }

        public bool PersonelDurum { get; set; }

        public List<HizmetSecimViewModel> Hizmetler { get; set; } = new List<HizmetSecimViewModel>();
    }

    public class HizmetSecimViewModel
    {
        public int HizmetId { get; set; }
        public string HizmetAd { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Ucret { get; set; } // Bu, PersonelHizmet'teki ücret olacak
    }
}
