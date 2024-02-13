using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CataloguingAppApi.Data
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
        public virtual DbSet<Directory> Directories { get; set; } = null!;
        public virtual DbSet<Hierarchynode> Hierarchynodes { get; set; } = null!;
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
                entity.HasKey(e => e.Hierarchynodeid)
                    .HasName("PRIMARY");

                entity.ToTable("collectable");

                entity.HasIndex(e => e.Hierarchynodeid, "fk_collectable_hierarchynode_idx");

                entity.Property(e => e.Hierarchynodeid)
                    .ValueGeneratedNever()
                    .HasColumnName("hierarchynodeid");

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

                entity.HasOne(d => d.Hierarchynode)
                    .WithOne(p => p.Collectable)
                    .HasForeignKey<Collectable>(d => d.Hierarchynodeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_collectable_hierarchynode");
            });

            modelBuilder.Entity<Directory>(entity =>
            {
                entity.HasKey(e => e.Hierarchynodeid)
                    .HasName("PRIMARY");

                entity.ToTable("directory");

                entity.Property(e => e.Hierarchynodeid)
                    .ValueGeneratedNever()
                    .HasColumnName("hierarchynodeid");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Hierarchynode)
                    .WithOne(p => p.Directory)
                    .HasForeignKey<Directory>(d => d.Hierarchynodeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_directory_hierarchynode");
            });

            modelBuilder.Entity<Hierarchynode>(entity =>
            {
                entity.ToTable("hierarchynode");

                entity.HasIndex(e => e.ParentNodeId, "hierarchynode_hierarchynode_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ParentNodeId).HasColumnName("parentNodeId");

                entity.HasOne(d => d.ParentNode)
                    .WithMany(p => p.InverseParentNode)
                    .HasForeignKey(d => d.ParentNodeId)
                    .HasConstraintName("fk_hierarchynode_hierarchynode");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.HasIndex(e => e.Collectableid, "fk_image_collectable_idx");

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
                    .HasConstraintName("fk_image_collectable");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
