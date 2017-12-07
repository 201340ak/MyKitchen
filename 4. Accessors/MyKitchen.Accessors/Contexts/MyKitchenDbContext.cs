using Microsoft.EntityFrameworkCore;
using MyKitchen.Accessors.Entities;

namespace MyKitchen.Accessors.Contexts
{
    public class MyKitchenDbContext : DbContext
    {

        public MyKitchenDbContext(DbContextOptions<MyKitchenDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>()
                .HasDiscriminator<string>("type")
                .HasValue<Inventory>("inventory");
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Ingredient> Ingredients { get; set ; }
        
        public DbSet<Instruction> Instructions { get; set; }

        public DbSet<AcceptableUnit> AcceptableUnits { get; set; }

        public DbSet<List> Lists { get; set; }
    }
}