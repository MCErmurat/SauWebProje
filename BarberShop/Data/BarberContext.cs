using BarberShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class BarberContext:DbContext
    {
        public DbSet<Personel> Personeller { get; set; }

        public DbSet<Appointments> Randevular { get; set; }

        public DbSet<Hizmet> Hizmetler { get; set; }

        public DbSet<PersonelTakvim> PersonelTakvim { get; set; }

        public DbSet<PersonelHizmet> PersonelHizmet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BarberShop;Trusted_Connection=True;");
        }
        public DbSet<BarberShop.Models.PersonelEkleViewModel> PersonelEkleViewModel { get; set; } = default!;
    }
}
