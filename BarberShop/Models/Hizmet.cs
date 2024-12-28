namespace BarberShop.Models
{
    public class Hizmet
    {
        public int Id { get; set; }
        public string Ad { get; set; }

        public ICollection<PersonelHizmet>? PersonelHizmetler { get; set; }

        public ICollection<Appointments>? Appointments { get; set; }
    }
}