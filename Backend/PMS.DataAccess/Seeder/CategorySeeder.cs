using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core.CategoryFeatures;

namespace PMS.DataAccess.Seeder
{
    public class CategorySeeder
    {
        public CategorySeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity(1, "Crops", "Seeds and plants for agriculture and gardening.", "images/categories/crops.jpg"),
                new CategoryEntity(2, "Tools", "Essential tools for planting, digging, and maintaining your garden.", "images/categories/tools.jpg"),
                new CategoryEntity(3, "Chemicals", "Fertilizers, pesticides, and insecticides for healthy plant growth.", "images/categories/chemicals.jpg")
            );

        }
    }
}
