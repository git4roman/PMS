using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.OrderItemFeatures;

namespace PMS.DataAccess.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.ToTable("order_items");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("order_item_id");

            builder.Property(x => x.Guid)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasColumnName("guid");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("name");

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)")
                .HasColumnName("description");

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("quantity");

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasColumnName("unit_price");

            builder.Property(x => x.ShippingCharge)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasColumnName("shipping_charge");

            builder.Property(x => x.TotalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasColumnName("total_price")
                .HasComputedColumnSql("[unit_price] * [quantity] + [shipping_charge]");

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("created_date");

            builder.Property(x => x.CreatedTime)
                .IsRequired()
                .HasColumnType("time")
                .HasColumnName("created_time");

            builder.Property(x => x.ProductId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("product_id");

            builder.Property(x => x.OrderId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("order_id");

            builder.HasIndex(x => x.ProductId);
            builder.HasIndex(x => x.OrderId);

            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}