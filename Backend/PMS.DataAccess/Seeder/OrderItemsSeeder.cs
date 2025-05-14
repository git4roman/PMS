using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core.OrderItemFeatures;

namespace PMS.DataAccess.Seeder
{
    public class OrderItemsSeeder
    {
        public OrderItemsSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemEntity>().HasData(
    new OrderItemEntity(1, "Tomato Seeds x2", "Two packets of tomato seeds", 2, 3.00m, 7.00m, 1, 1.00m, 1),
    new OrderItemEntity(2, "Hand Trowel", "Garden hand tool", 1, 7.00m, 8.00m, 4, 1.00m, 1),
    new OrderItemEntity(3, "Neem Oil Bottle", "Organic pesticide", 1, 8.00m, 9.00m, 7, 1.00m, 2),
    new OrderItemEntity(4, "Spinach Plant x3", "Set of 3 spinach plants", 3, 5.00m, 16.00m, 2, 1.00m, 3),
    new OrderItemEntity(5, "Pruning Shears", "Sharp pruning shears", 1, 10.00m, 11.00m, 5, 1.00m, 4)
);

        }
    }
}
