using Microsoft.EntityFrameworkCore;
using Grafos.Models;
namespace Grafos.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pais> Paises { get; set; } = null!;
        public DbSet<Ciudad> Ciudades { get; set; } = null!;
        public DbSet<Carretera> Carreteras { get; set; } = null!;
        public DbSet<TipoCarretera> TiposCarretera { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<Carretera>()
                .HasOne(c=>c.CiudadOrigen)
                .WithMany(co=>co.CarreterasOrigen)
                .HasForeignKey(c=>c.CiudadOrigenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Carretera>()
                .HasOne(c=>c.CiudadDestino)
                .WithMany(cd=>cd.CarreterasDestino)
                .HasForeignKey(c=>c.CiudadDestinoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    }

