using System.Collections.Generic;
using MyKitchen.Accessors.Entities;

namespace MyKitchen.Accessors.Contexts.InitializeData
{
    public static class Foods
    {
        public static List<Food> All
        {
            get 
            {
                return new List<Food>
                {
                    Hamburger,
                    PillsburyCrescentRolls,
                    BbqSauce,
                    RedOnion,
                    FrenchFries,
                    Cola
                };
            }
        }

        private static Food Hamburger
        {
            get
            {
                return new Food
                {
                    Name = "Hamburger",
                    UnitId = 1, // Pound
                    ServingSize = 0.25M,
                    Calories = 260,
                    Price = 3.84M,
                    UnitQuantityForPrice = 1
                };
            }
        }

        private static Food PillsburyCrescentRolls
        {
            get
            {
                return new Food
                {
                    Name = "Pillsbury Crescent Rolls",
                    UnitId = 2, // Rolls
                    ServingSize = 0.25M,
                    Calories = 100,
                    Price = 2.18M,
                    UnitQuantityForPrice = 8
                };
            }
        }

        private static Food BbqSauce
        {
            get
            {
                return new Food
                {
                    Name = "BBQ Sauce",
                    UnitId = 3, // Ounces
                    ServingSize = 1M,
                    Calories = 54,
                    Price = 2.64M,
                    UnitQuantityForPrice = 28
                };
            }
        }

        private static Food RedOnion
        {
            get
            {
                return new Food
                {
                    Name = "Red Onion",
                    UnitId = 3, // Ounces
                    ServingSize = 5M,
                    Calories = 64,
                    Price = 1.32M,
                    UnitQuantityForPrice = 0.3125M
                };
            }
        }

        private static Food FrenchFries
        {
            get
            {
                return new Food
                {
                    Name = "Frozen French Fries",
                    UnitId = 3, // Ounces
                    ServingSize = 3M,
                    Calories = 130,
                    Price = 2.89M,
                    UnitQuantityForPrice = 30M
                };
            }
        }

        private static Food Cola
        {
            get
            {
                return new Food
                {
                    Name = "Cola",
                    UnitId = 4, // Cans
                    ServingSize = 1M,
                    Calories = 140,
                    Price = 17M,
                    UnitQuantityForPrice = 12M
                };
            }
        }
    }
}