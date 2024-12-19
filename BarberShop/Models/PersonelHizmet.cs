using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{
    public class PersonelHizmet
    {
        public int Id { get; set; }

        // Foreign Keyler
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }

        public int HizmetId { get; set; }
        public Hizmet Hizmet { get; set; }

        // Ücret bilgisi
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ucret { get; set; }
    }
}