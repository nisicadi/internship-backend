using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Recipes.Models
{
    public partial class PraksaDBContext : DbContext
    {
        public PraksaDBContext()
        {
        }

        public PraksaDBContext(DbContextOptions<PraksaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Foodstuff> Foodstuffs { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<StorageInput> StorageInputs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-V6I3GMK;Initial Catalog=PraksaDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<Foodstuff>(entity =>
            {
                entity.ToTable("Foodstuff");

                entity.Property(e => e.FoodstuffId).HasColumnName("foodstuffId");

                entity.Property(e => e.FoodstuffName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("foodstuffName");

                entity.Property(e => e.MeasurementId).HasColumnName("measurementId");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.Foodstuffs)
                    .HasForeignKey(d => d.MeasurementId)
                    .HasConstraintName("FK__Foodstuff__measu__5EBF139D");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.IngredientId).HasColumnName("ingredientID");

                entity.Property(e => e.FoodstuffId).HasColumnName("foodstuffId");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("quantity");

                entity.Property(e => e.RecipeId).HasColumnName("recipeID");

                entity.HasOne(d => d.Foodstuff)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.FoodstuffId)
                    .HasConstraintName("FK__Ingredien__foods__5FB337D6");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Ingredien__recip__5165187F");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.HasKey(e => e.MeasurementId)
                    .HasName("PK__measurem__5524F4D2E1BD477E");

                entity.ToTable("MeasurementUnit");

                entity.Property(e => e.MeasurementId).HasColumnName("measurementId");

                entity.Property(e => e.Measurement)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("measurement");

                entity.Property(e => e.MeasurementLong)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("measurement_long");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecipeDescription).HasColumnName("recipeDescription");

                entity.Property(e => e.RecipePrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("recipePrice");

                entity.Property(e => e.RecipeTitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_categoryID");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.ToTable("Storage");

                entity.Property(e => e.StorageId).HasColumnName("storageId");

                entity.Property(e => e.FoodstuffId).HasColumnName("foodstuffId");

                entity.Property(e => e.MinQuantity)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("min_quantity");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("quantity");

                entity.Property(e => e.UnderMin)
                    .IsRequired()
                    .HasColumnName("under_min")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Foodstuff)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.FoodstuffId)
                    .HasConstraintName("FK__Storage__foodstu__6FE99F9F");
            });

            modelBuilder.Entity<StorageInput>(entity =>
            {
                entity.ToTable("Storage_input");

                entity.Property(e => e.StorageInputId).HasColumnName("storageInputId");

                entity.Property(e => e.FoodstuffId).HasColumnName("foodstuffId");

                entity.Property(e => e.InputDate)
                    .HasColumnType("datetime")
                    .HasColumnName("inputDate");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("quantity");

                entity.HasOne(d => d.Foodstuff)
                    .WithMany(p => p.StorageInputs)
                    .HasForeignKey(d => d.FoodstuffId)
                    .HasConstraintName("FK__Storage_i__foods__73BA3083");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
