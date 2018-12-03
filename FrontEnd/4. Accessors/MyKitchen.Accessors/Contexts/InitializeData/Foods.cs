using System.Collections.Generic;
using MyKitchen.Accessors.Entities;
using System.Linq;

namespace MyKitchen.Accessors.Contexts.InitializeData
{
    public static class Foods
    {
        public static List<Food> All
        {
            get 
            {
                var foods = new List<Food>
                {
                    Hamburger,
                    PillsburyCrescentRolls,
                    BbqSauce,
                    RedOnion,
                    FrenchFries,
                    Cola
                }; 
                return foods;
            }
        }

        private static Food Hamburger
        {
            get
            {
                return new Food
                {
                    Name = "Hamburger",
                    ServingSize = 0.25M,
                    Calories = 260,
                    Price = 3.84M
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
                    ServingSize = 0.25M,
                    Calories = 100,
                    Price = 2.18M
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
                    ServingSize = 1M,
                    Calories = 54,
                    Price = 2.64M
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
                    ServingSize = 5M,
                    Calories = 64,
                    Price = 1.32M
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
                    ServingSize = 3M,
                    Calories = 130,
                    Price = 2.89M
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
                    ServingSize = 1M,
                    Calories = 140,
                    Price = 17M
                };
            }
        }
    }
}