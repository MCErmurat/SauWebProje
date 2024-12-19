using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Appointments
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen isim alanını boş bırakmayınız!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İsim 2 ile 50 karakter arasında olmalıdır.")]
        [RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+(?: [a-zA-ZğüşıöçĞÜŞİÖÇ]+)*$", ErrorMessage = "İsim yalnızca harflerden oluşmalıdır.")]

        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^(?:\+90\s?)?(?:\((\d{3})\)\s?|\d{3})\d{3}[-]?\d{2}[-]?\d{2}$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli tarih ve saat giriniz!")]
        [Display(Name = "Randevu Tarihi")]
        public DateOnly Tarih { get; set; }

        public TimeSpan Saat { get; set; }

        public int HizmetId { get; set; }
        public Hizmet? Hizmet { get; set; }

        public int PersonelId { get; set; }
        public Personel? Personel { get; set; }
    }
}