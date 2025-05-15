using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.UserFeatures;

namespace PMS.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("user_id");

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("first_name");

            builder.Property(x => x.MiddleName)
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("middle_name");

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)")
                .HasColumnName("last_name");

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("nvarchar(255)")
                .HasColumnName("password_hash");

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)")
                .HasColumnName("email");

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("phone_number");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("nvarchar(300)")
                .HasColumnName("address");

            builder.Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("created_date");

            builder.Property(x => x.CreatedTime)
                .IsRequired()
                .HasColumnType("time")
                .HasColumnName("created_time");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)")
                .HasConversion(
                    v => v.ToString(),
                    v => v)
                .HasColumnName("status");

            builder.HasIndex(x => x.Email)
                .IsUnique()
                .HasFilter("[email] IS NOT NULL");

            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder.HasIndex(x => new { x.FirstName, x.LastName });
           
        }
    }
}