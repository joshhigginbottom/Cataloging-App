using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CataloguingAppApi.Models
{
    public partial class appContext : DbContext
    {
        public appContext()
        {
        }

        public appContext(DbContextOptions<appContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collectable> Collectables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collectable>(entity =>
            {
                entity.ToTable("collectable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Currentworth)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("currentworth");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.Pricepaid)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("pricepaid");

                entity.Property(e => e.Size)
                    .HasMaxLength(45)
                    .HasColumnName("size");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
