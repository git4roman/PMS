using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.OderFeatures;

namespace PMS.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("order_id");

            builder.Property(x => x.Guid)
                .IsRequired()
                .HasColumnType("uniqueidentifier")
                .HasColumnName("guid");

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)")
                .HasColumnName("description");

            builder.Property(x => x.CustomerId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("customer_id");

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("created_date");

            builder.Property(x => x.CreatedTime)
                .IsRequired()
                .HasColumnType("time")
                .HasColumnName("created_time");

            builder.Property(x => x.OrderStatus)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)")
                .HasConversion(
                    v => v.ToString(),
                    v => v)
                .HasColumnName("order_status");

            builder.Property(x => x.DelieveryAddress)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("nvarchar(300)")
                .HasColumnName("delivery_address");

            builder.Property(x => x.FinalPrice)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("final_price");
                 

            builder.HasIndex(x => x.CustomerId);
            builder.HasIndex(x => x.OrderStatus);
            builder.HasIndex(x => x.CreatedDate);

            builder.HasOne(x => x.CustomerEntity)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.OrderItems)
                .WithOne()
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}