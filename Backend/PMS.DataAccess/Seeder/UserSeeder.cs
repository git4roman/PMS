using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMS.Core.UserFeatures;

namespace PMS.DataAccess.Seeder
{
    public class UserSeeder
    {
        public UserSeeder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
        new UserEntity(1, "Ram", "Bahadur", "Thapa", "hashedPassword1", "admin@admin.com", "9800000000", "Butwal"),
        new UserEntity(2, "Sita", "", "Maharjan", "hashedPassword2", "sita@example.com", "9800000001", "Lalitpur"),
        new UserEntity(3, "Kiran", "Kumar", "Gurung", "hashedPassword3", "kiran@example.com", "9800000002", "Pokhara"),
        new UserEntity(4, "Anil", "", "Shrestha", "hashedPassword4", "anil@example.com", "9800000003", "Kathmandu"),
        new UserEntity(5, "Meena", "Devi", "Tharu", "hashedPassword5", "meena@example.com", "9800000004", "Biratnagar"),
        new UserEntity(6, "Hari", "", "Rai", "hashedPassword6", "hari@example.com", "9800000005", "Dharan")
        );
        }
    }
}
