using System.Collections.Generic;
using System.Linq;
using MyKitchen.Accessors.Entities;

namespace MyKitchen.Accessors.Contexts
{
    public static class MyKitchenDbInitializer
    {

        public static void Initialize(MyKitchenDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Units.Any())
            {
                return; // DB has beed seeded
            }

            // Add Units
            context.Units.AddRange(InitializeData.Units.All);

            // Add Foods
            context.Food.AddRange(InitializeData.Foods.All);

            // Add Recipes
            context.Recipes.AddRange(InitializeData.Recipes.All);

            // Add Ingredients
            context.Ingredients.AddRange(InitializeData.Ingredients.All);

            // Add Instructions
            context.Instructions.AddRange(InitializeData.Instructions.All);
        }
    }
}