using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Appointments
    {
        [Required]
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Randevu Tarihi")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Randevu Saati")]
        public TimeSpan Time { get; set; }
    }
}
