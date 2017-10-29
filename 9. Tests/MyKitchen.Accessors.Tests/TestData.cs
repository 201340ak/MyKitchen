namespace MyKitchen.Accessors.Tests
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
                    Unit = Pounds,
                    ServingSize = 0.25M,
                    Calories = 260,
                    Price = 3.84M,
                    UnitQuantityForPrice = 1
                };
            }
        }

        public static DataContracts.Food PillsburyCrescentRolls
        {
            get
            {
                return new DataContracts.Food
                {
                    Name = "Pillsbury Crescent Rolls",
                    Unit = Rolls,
                    ServingSize = 0.25M,
                    Calories = 100,
                    Price = 2.18M,
                    UnitQuantityForPrice = 8
                };
            }
        }

        public static DataContracts.Food BbqSauce
        {
            get
            {
                return new DataContracts.Food
                {
                    Name = "BBQ Sauce",
                    Unit = Ounces,
                    ServingSize = 1M,
                    Calories = 54,
                    Price = 2.64M,
                    UnitQuantityForPrice = 28
                };
            }
        }

        public static DataContracts.Food RedOnion
        {
            get
            {
                return new DataContracts.Food
                {
                    Name = "Red Onion",
                    Unit = Ounces,
                    ServingSize = 5M,
                    Calories = 64,
                    Price = 1.32M,
                    UnitQuantityForPrice = 0.3125M
                };
            }
        }

        public static DataContracts.Food FrenchFries
        {
            get
            {
                return new DataContracts.Food
                {
                    Name = "Frozen French Fries",
                    Unit = Ounces,
                    ServingSize = 3M,
                    Calories = 130,
                    Price = 2.89M,
                    UnitQuantityForPrice = 30M
                };
            }
        }

        public static DataContracts.Food Cola
        {
            get
            {
                return new DataContracts.Food
                {
                    Name = "Cola",
                    Unit = Cans,
                    ServingSize = 1M,
                    Calories = 140,
                    Price = 17M,
                    UnitQuantityForPrice = 12M
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

        public static DataContracts.Unit Rolls
        {
            get
            {
                return new DataContracts.Unit
                {
                    Name = "Rolls"
                };
            }
        }

        public static DataContracts.Unit Ounces
        {
            get
            {
                return new DataContracts.Unit
                {
                    Name = "Ounces"
                };
            }
        }

        public static DataContracts.Unit Cans
        {
            get
            {
                return new DataContracts.Unit
                {
                    Name = "Cans"
                };
            }
        }

        public static DataContracts.Inventory UserOneInventory
        {
            get
            {
                return new DataContracts.Inventory
                {
                    Foods = new List<DataContracts.Food>
                    {
                        Hamburger
                    }   
                };
            }
        }
    }
}