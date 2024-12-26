using BarberShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class BarberContext:IdentityDbContext<IdentityUser>
    {
        public BarberContext(DbContextOptions<BarberContext> options)
        : base(options)
        {
        }

        public DbSet<Personel> Personeller { get; set; }

        public DbSet<Appointments> Randevular { get; set; }

        public DbSet<Hizmet> Hizmetler { get; set; }

        public DbSet<PersonelTakvim> PersonelTakvim { get; set; }

        public DbSet<PersonelHizmet> PersonelHizmet { get; set; }
        public DbSet<AppUser> Kullanıcılar {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BarberShop;Trusted_Connection=True;");
        //}
        public DbSet<BarberShop.Models.PersonelEkleViewModel> PersonelEkleViewModel { get; set; } = default!;
    }
}
