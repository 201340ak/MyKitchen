using System.Collections.Generic;
using MyKitchen.Accessors.Entities;

namespace MyKitchen.Accessors.Contexts.InitializeData
{
    public static class Ingredients
    {
        public static List<Ingredient> All
        {
            get{
                var ingredients = new List<Ingredient>();
                ingredients.AddRange(RunzaIngredients);
                return ingredients;
            }
        }
        
        private static List<Ingredient> RunzaIngredients
        {
            get
            {
                return new List<Ingredient>
                {
                    new Ingredient
                    {
                        RecipeId = 1, // Runza
                        FoodId = 1, // Hamburger
                        Quantity = 1,
                        UnitId = 1 // Pounds
                    },
                    new Ingredient
                    {
                        RecipeId = 1, // Runza
                        FoodId = 2, // Crescent Rolls
                        Quantity = 8,
                        UnitId = 2 // Rolls
                    },
                    new Ingredient
                    {
                        RecipeId = 1, // Runza
                        FoodId = 3, // BBQ Sauce
                        Quantity = 3,
                        UnitId = 3 // Ounces
                    },
                    new Ingredient
                    {
                        RecipeId = 1, // Runza
                        FoodId = 4, // Red Onion
                        Quantity = 0.25M,
                        UnitId = 3, //Ounces 
                    }                    
                };
            }
        }
    }
}