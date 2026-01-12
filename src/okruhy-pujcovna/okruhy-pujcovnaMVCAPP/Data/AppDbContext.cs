using okruhy_pujcovnaMVCAPP.Entities;
using okruhy_pujcovnaMVCAPP.Models;
using System.Reflection.PortableExecutable;
using Microsoft.EntityFrameworkCore;

namespace okruhy_pujcovnaMVCAPP.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Circuit> Circuits { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CircuitCar> CircuitCars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(
                "server=localhost;database=4c2_mraztomas_db2;user=mraztomas;password=123456;");
        }
        
    }
}
