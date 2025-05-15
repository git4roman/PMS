using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.ProductFeatures;

namespace PMS.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd()
                   .HasColumnType("int")
                   .HasColumnName("product_id");

            builder.Property(x => x.Guid)
                   .IsRequired()
                   .HasColumnType("char(36)")
                   .HasColumnName("guid");

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("product_name");

            builder.Property(x => x.Description)
                   .HasMaxLength(500)
                   .HasColumnType("varchar(500)")
                   .HasColumnName("description");

            builder.Property(x => x.ImageUrl)
                   .HasMaxLength(300)
                   .HasColumnType("varchar(300)")
                   .HasColumnName("image_url");

            builder.Property(x => x.Quantity)
                   .IsRequired()
                   .HasColumnType("int")
                   .HasColumnName("quantity");

            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("price");

            builder.Property(x => x.CategoryId)
                   .IsRequired()
                   .HasColumnType("int")
                   .HasColumnName("category_id");

            builder.Property(x => x.CreatedDate)
                   .IsRequired()
                   .HasColumnType("date")
                   .HasConversion(
                       v => v.ToDateTime(TimeOnly.MinValue),
                       v => DateOnly.FromDateTime(v))
                   .HasColumnName("created_date");

            builder.Property(x => x.UpdatedDate)
                   .HasColumnType("date")
                   .HasConversion(
                       v => v.ToDateTime(TimeOnly.MinValue),
                       v => DateOnly.FromDateTime(v))
                   .HasColumnName("updated_date");

            builder.Property(x => x.CreatedTime)
                   .IsRequired()
                   .HasColumnType("time")
                   .HasConversion(
                       v => v.ToTimeSpan(),
                       v => TimeOnly.FromTimeSpan(v))
                   .HasColumnName("created_time");

            builder.Property(x => x.UpdatedTime)
                   .HasColumnType("time")
                   .HasConversion(
                       v => v.ToTimeSpan(),
                       v => TimeOnly.FromTimeSpan(v))
                   .HasColumnName("updated_time");

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnType("varchar(20)")
                   .HasConversion(
                       v => v.ToString(),
                       v => (string)v)
                   .HasColumnName("status");

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.CategoryId);
            builder.HasIndex(x => x.Status);

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}