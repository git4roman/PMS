using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.CategoryFeatures;

namespace PMS.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd()
                   .HasColumnType("int")
                   .HasColumnName("category_id");

            builder.Property(x => x.Guid)
                   .IsRequired()
                   .HasColumnType("char(36)")
                   .HasColumnName("guid");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("category_name");

            builder.Property(x => x.Description)
                   .HasMaxLength(500)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("description");

            builder.Property(x => x.ImageUrl)
                   .HasMaxLength(300)
                   .HasColumnType("nvarchar(300)")
                   .HasColumnName("image_url");

            builder.HasIndex(x => x.Name);

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}