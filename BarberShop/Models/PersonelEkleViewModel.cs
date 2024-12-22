using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{
    public class PersonelEkleViewModel
    {
        [Key]
        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Personel adı zorunludur.")]
        public string PersonelAd { get; set; }

        [Required(ErrorMessage = "Personel soyadı zorunludur.")]
        public string PersonelSoyad { get; set; }

        public bool PersonelDurum { get; set; }

        public List<HizmetSecimViewModel> Hizmetler { get; set; } = new List<HizmetSecimViewModel>();
    }

   
}
