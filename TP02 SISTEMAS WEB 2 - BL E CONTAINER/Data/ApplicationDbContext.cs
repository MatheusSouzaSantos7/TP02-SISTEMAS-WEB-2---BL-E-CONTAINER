// Matheus Angelo - CB3025489
using Microsoft.EntityFrameworkCore;
using TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Models;

namespace TP02_SISTEMAS_WEB_2___BL_E_CONTAINER.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BL> BLs { get; set; }
        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BL>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).IsRequired();
                entity.HasMany(e => e.Containers).WithOne(c => c.BL!).HasForeignKey(c => c.BLId).IsRequired();
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).HasMaxLength(11).IsRequired();
                entity.Property(e => e.Tipo).IsRequired();
            });
        }
    }
}
