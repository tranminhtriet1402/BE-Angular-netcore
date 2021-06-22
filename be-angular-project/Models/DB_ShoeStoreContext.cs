using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace be_angular_project.Models
{
    public partial class DB_ShoeStoreContext : DbContext
    {
        public DB_ShoeStoreContext()
        {
        }

        public DB_ShoeStoreContext(DbContextOptions<DB_ShoeStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DatabaseShoeStore");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Categori__E548B67396E615FD");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.CodeCategory).HasColumnName("code_category");

                entity.Property(e => e.Descriptions).HasColumnName("descriptions");

                entity.Property(e => e.NameCategory).HasColumnName("name_category");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Products__BA39E84F84EA87F3");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.CodeProduct).HasColumnName("code_product");

                entity.Property(e => e.Descriptions).HasColumnName("descriptions");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Images).HasColumnName("images");

                entity.Property(e => e.Images1).HasColumnName("images1");

                entity.Property(e => e.Images2).HasColumnName("images2");

                entity.Property(e => e.Images3).HasColumnName("images3");

                entity.Property(e => e.NameProduct).HasColumnName("name_product");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__id_cat__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
