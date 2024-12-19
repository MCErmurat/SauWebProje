using System.Security.Policy;

namespace BarberShop.Models
{
    public class PersonelTakvim
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public Personel personel { get; set; }

        public DateOnly Tarih { get; set; }
        public TimeSpan Saat { get; set; }

        public bool Dolu{ get; set; }
    }
}