namespace MyKitchen.Managers.Tests
{
    using System.Collections.Generic;

    public static class TestData
    {        
        public static DataContracts.Recipe TestRecipe
        {
            get 
            {
                return new DataContracts.Recipe 
                {
                    Name = "Runzas",
                    Description = "Just like real Runzas!!",
                    PreparationTime = 5,
                    CookTime = 20,
                    Servings = 4,
                    Ingredients = new List<DataContracts.Ingredient>(){
                        new DataContracts.Ingredient
                        {
                            FoodId = 1,
                            RecipeId = 1,
                            Quantity = 1
                        }
                    }
                };
            }
        }

        public static DataContracts.Food Hamburger
        {
            get
            {
                return new DataContracts.Food
                {
                    Name = "Hamburger",
                    Units = new List<DataContracts.Unit> {Pounds},
                    ServingSize = 0.25M,
                    Calories = 260,
                    Price = 3.84M
                };
            }
        }

        public static DataContracts.Unit Pounds
        {
            get
            {
                return new DataContracts.Unit
                {
                    Id = 1,
                    Name = "Pounds"
                };
            }
        }
    }
}