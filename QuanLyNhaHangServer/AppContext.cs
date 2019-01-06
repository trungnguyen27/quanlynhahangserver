//using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuanLyNhaHangServer
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FoodWithOrder> FoodWithOrders { get; set; }
    }
}
