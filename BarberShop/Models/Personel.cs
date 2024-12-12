using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Personel
    {


        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [Display(Name = "Personel ID")]
        public int PersonelID { get; set; }


        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [Display(Name = "Personel Ad")]
        public string PersonelAd { get; set; }


        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [Display(Name = "Personel Soyad")]
        public string PersonelSoyad { get; set; }


        public List<HizmetUcret> Hizmetler { get; set; }
    }

    public class HizmetUcret
    {
        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [Display(Name = "Hizmet Adi")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [Display(Name = "Hizmet Ucreti")]
        public int Ucret { get; set; }
    }
}
