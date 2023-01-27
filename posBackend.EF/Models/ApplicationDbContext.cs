using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posBackend.EF.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c =>
                       {
                           c.Property(x => x.IsActive).HasDefaultValue(true);
                           c.Property(x => x.CategoryName).IsRequired(true).HasMaxLength(50);
                       }
                );

            modelBuilder.Entity<Unit>(u =>
            {
                u.Property(x => x.IsActive).HasDefaultValue(true);
                u.Property(x => x.UnitName).IsRequired(true).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.Property(x => x.HalfSectoralSellingPrice).HasDefaultValue(0);
                p.Property(x => x.WholesaleSellingPrice).HasDefaultValue(0);
                p.Property(x => x.PurchaseingPrice).HasDefaultValue(0);
                p.Property(x => x.SectoralSellingPrice).HasDefaultValue(0);
                p.Property(p => p.IsActive).HasDefaultValue(true);
            });


            modelBuilder.Entity<Product>()
                .HasMany(p => p.Units)
                .WithMany(p => p.Products)
                .UsingEntity<ProductUnit>(
                    pu => pu
                    .HasOne(c => c.Unit)
                    .WithMany(c => c.ProductUnits)
                    .HasForeignKey(c => c.UnitID),

                    pu => pu
                    .HasOne(c => c.Product)
                    .WithMany(c => c.ProductUnits)
                    .HasForeignKey(c => c.ProductID),

                     pu =>
                     {
                         pu.Property(p => p.IsMainUnit).HasDefaultValue(false);
                         pu.Property(p => p.index).UseIdentityColumn(1, 1);
                         pu.HasKey(p => new { p.ProductID, p.UnitID });
                     }
                );

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
    }
}
