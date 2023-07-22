using Microsoft.EntityFrameworkCore;
using ScadaAPI.Models;

namespace ScadaAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SCADA_SensorLog> sCADA_SensorLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SCADA_SensorLog>(b =>
            {
                b.HasKey(e => e.SensorLogID);
                b.Property(e => e.SensorLogID);
            });
        }
    }
}
