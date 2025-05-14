using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core.OderFeatures;

namespace PMS.DataAccess.Seeder
{
    public class OrderSeeder
    {
        public OrderSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>().HasData(new OrderEntity(
                    Id: 1,
                    Description: "Grocery order for weekly supplies",
                    CustomerId: 101,
                    OrderStatus: "Pending",
                    DelieveryAddress: "123 Maple Street, Springfield"
                ),
                new OrderEntity(
                    Id: 2,
                    Description: "Electronics purchase",
                    CustomerId: 102,
                    OrderStatus: "Confirmed",
                    DelieveryAddress: "456 Oak Avenue, Rivertown"
                ),
                new OrderEntity(
                    Id: 3,
                    Description: "Clothing order for summer collection",
                    CustomerId: 103,
                    OrderStatus: "Shipped",
                    DelieveryAddress: "789 Pine Road, Hillview"
                ),
                new OrderEntity(
                    Id: 4,
                    Description: "Furniture delivery",
                    CustomerId: 104,
                    OrderStatus: "Delievered",
                    DelieveryAddress: "321 Cedar Lane, Lakeside"
                ),
                new OrderEntity(
                    Id: 5,
                    Description: "Cancelled book order",
                    CustomerId: 105,
                    OrderStatus: "Cancelled",
                    DelieveryAddress: "654 Birch Street, Sunnyvale"
                ));
        }
    }
}
