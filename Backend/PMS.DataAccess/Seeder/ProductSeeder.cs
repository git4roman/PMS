using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core.ProductFeatures;

namespace PMS.DataAccess.Seeder
{
    public class ProductSeeder
    {
        public ProductSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().HasData(
                // Crops
                new ProductEntity(1, "Tomato Seeds", "High-yield tomato seeds suitable for home and farm use.", "images/products/tomato_seeds.jpg", 1, 3, 299), // $2.99
                new ProductEntity(2, "Spinach Plant", "Nutritious leafy vegetable ready for home garden transplant.", "images/products/spinach_plant.jpg", 1, 5, 499), // $4.99
                new ProductEntity(3, "Chili Seeds", "Spicy chili seeds ideal for warm climates.", "images/products/chili_seeds.jpg", 1, 2, 349), // $3.49

                // Tools
                new ProductEntity(4, "Hand Trowel", "Durable tool for digging and planting small plants.", "images/products/hand_trowel.jpg", 2, 7, 999), // $9.99
                new ProductEntity(5, "Pruning Shears", "Sharp blade tool for trimming plants and bushes.", "images/products/pruning_shears.jpg", 2, 10, 1499), // $14.99
                new ProductEntity(6, "Watering Can", "Lightweight watering can with long spout for even watering.", "images/products/watering_can.jpg", 2, 12, 1999), // $19.99

                // Chemicals
                new ProductEntity(7, "Pesticide - Neem Oil", "Organic pesticide for controlling aphids and mealybugs.", "images/products/neem_oil.jpg", 3, 8, 1299), // $12.99
                new ProductEntity(8, "Insecticide - Cypermethrin", "Fast-acting insecticide for outdoor crops.", "images/products/cypermethrin.jpg", 3, 10, 1599), // $15.99
                new ProductEntity(9, "Fertilizer - NPK 20:20:20", "Balanced fertilizer to promote plant growth.", "images/products/npk_fertilizer.jpg", 3, 15, 1099) // $10.99
            );
        }
    }
}