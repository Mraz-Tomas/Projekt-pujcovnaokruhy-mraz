using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using okruhy_pujcovnaMVCAPP.Entities;
using okruhy_pujcovnaMVCAPP.Models;
using System.Reflection.PortableExecutable;

namespace okruhy_pujcovnaMVCAPP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public DbSet<circuit> Circuits { get; set; }
        public DbSet<car> Cars { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<reservation> Reservations { get; set; }
        public DbSet<circuitcar> CircuitCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;database=4c2_mraztomas_db2;user=mraztomas;password=123456");
        }
    }
}
