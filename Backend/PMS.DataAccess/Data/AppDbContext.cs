using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core;
using PMS.Core.CategoryFeatures;
using PMS.Core.CustomerFeatures;
using PMS.Core.OderFeatures;
using PMS.Core.OrderItemFeatures;
using PMS.Core.ProductFeatures;
using PMS.Core.SellerFeatures;
using PMS.Core.UserFeatures;
using PMS.DataAccess.Seeder;

namespace PMS.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DommyTable> DommyTables { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        //public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        //public DbSet<SellerEntity> Sellers { get; set; }
        //public DbSet<CustomerEntity> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new AppSeeder(modelBuilder);
        }


    }
}
