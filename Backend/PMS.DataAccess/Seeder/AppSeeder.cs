using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core.CategoryFeatures;
using PMS.Core.OderFeatures;
using PMS.Core.ProductFeatures;
using PMS.Core.UserFeatures;
using PMS.DataAccess.Data;

namespace PMS.DataAccess.Seeder
{
    public class AppSeeder
    {
        public AppSeeder(ModelBuilder modelBuilder)
        {
            // Categories
            new CategorySeeder(modelBuilder);

            // Products
            new ProductSeeder(modelBuilder);

            //Users
            new UserSeeder(modelBuilder);

            //Orders
            new OrderSeeder(modelBuilder);

            //OrderItems
            new OrderItemsSeeder(modelBuilder);

            
        }
    }
}
