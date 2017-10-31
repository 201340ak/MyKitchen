using System;
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
            context.SaveChanges();

            // Add Foods
            context.Food.AddRange(InitializeData.Foods.All);
            context.SaveChanges();

            // Add Recipes
            context.Recipes.AddRange(InitializeData.Recipes.All);
            context.SaveChanges();

            // Add Ingredients
            context.Ingredients.AddRange(InitializeData.Ingredients.All);
            context.SaveChanges();

            // Add Instructions
            context.Instructions.AddRange(InitializeData.Instructions.All);
            context.SaveChanges();
            

            if(!context.Units.Any())
            {
                throw new Exception("There was a problem seeding the database..");
            }
        }
    }
}