using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Appointments
    {


		[Required(ErrorMessage = "Lütfen isim alanını boş bırakmayınız!")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "İsim 2 ile 50 karakter arasında olmalıdır.")]
		[RegularExpression(@"^[a-zA-ZğüşıöçĞÜŞİÖÇ]+(?: [a-zA-ZğüşıöçĞÜŞİÖÇ]+)*$", ErrorMessage = "İsim yalnızca harflerden oluşmalıdır.")]

		[Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Lütfen geçerli tarih ve saat giriniz!")]
        [Display(Name = "Randevu Tarihi")]
        public DateTime Date { get; set; }
    }
}
