using System.Collections.Generic;
using MyKitchen.Accessors.Entities;

namespace MyKitchen.Accessors.Contexts.InitializeData
{
    public static class Recipes
    {
        public static List<Recipe> All
        {
            get
            {
                return new List<Recipe> {
                    Runzas
                };
            }
        }

        private static Recipe Runzas
        {
            get
            {
                return new Recipe
                {
                    Name = "Runzas",
                    Description = "Just like real Runzas!!",
                    PreparationTime = 5,
                    CookTime = 20,
                    Servings = 4
                };
            }
        }
    }
}