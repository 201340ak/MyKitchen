using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Models
{
    public class MyKitchenContext : DbContext
    {
        public MyKitchenContext (DbContextOptions<MyKitchenContext> options)
            : base(options)
        {
        }

        public DbSet<MyKitchen.Models.InventoryEntry> InventoryEntry { get; set; }

        public DbSet<MyKitchen.Models.User> User { get; set; }

        public DbSet<MyKitchen.Models.Food> Food { get; set; }

        public DbSet<MyKitchen.Models.Recipe> Recipe {get;set;}

        public DbSet<MyKitchen.Models.Ingredient> Ingredient {get;set;}

        public DbSet<MyKitchen.Models.Unit> Unit {get;set;}

        public DbSet<MyKitchen.Models.FoodUnit> FoodUnit {get;set;}
    }
}
