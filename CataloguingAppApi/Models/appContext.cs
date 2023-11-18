using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Collectable> Collectables { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=AppDb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Collectable>(entity =>
            {
                entity.ToTable("collectable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Currentworth)
                    .HasPrecision(10, 2)
                    .HasColumnName("currentworth");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.Pricepaid)
                    .HasPrecision(10, 2)
                    .HasColumnName("pricepaid");

                entity.Property(e => e.Size)
                    .HasMaxLength(45)
                    .HasColumnName("size");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.HasIndex(e => e.Collectableid, "image_collectable_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Collectableid).HasColumnName("collectableid");

                entity.Property(e => e.Data)
                    .HasColumnType("mediumblob")
                    .HasColumnName("data");

                entity.Property(e => e.Filename)
                    .HasMaxLength(260)
                    .HasColumnName("filename");

                entity.HasOne(d => d.Collectable)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.Collectableid)
                    .HasConstraintName("image_collectable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
