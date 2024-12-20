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
        [RegularExpression(@"^(?:\(?(\d{3})\)?\s?)?\d{3}[-]?\d{2}[-]?\d{2}$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]

        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen geçerli tarih giriniz!")]
        [Display(Name = "Randevu Tarihi")]
        public DateOnly Tarih { get; set; }
        [Required(ErrorMessage = "Lütfen geçerli saat giriniz!")]
        [Display(Name = "Randevu Saati")]
        public TimeSpan Saat { get; set; }

        [Required(ErrorMessage = "Lütfen bir hizmet seçiniz!")]
        [Display(Name = "Hizmet")]
        public int HizmetId { get; set; }
        public Hizmet? Hizmet { get; set; }

        [Required(ErrorMessage = "Lütfen bir personel seçiniz!")]
        [Display(Name = "Personel")]
        public int PersonelId { get; set; }
        public Personel? Personel { get; set; }
    }
}