using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{
    public class HizmetSecimViewModel
    {
        [Key]
        public int HizmetId { get; set; }

        // HizmetAd doğrulama dışında bırakıldı
        [NotMapped]
        public string HizmetAd { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Ucret { get; set; }
    }
}
