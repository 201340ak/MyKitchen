using System.Collections.Generic;
using MyKitchen.Accessors.Entities;
using System.Linq;

namespace MyKitchen.Accessors.Contexts.InitializeData
{
    public static class AcceptableUnits
    {
        public static List<AcceptableUnit> All
        {
            get 
            {
                var acceptableUnits = new List<AcceptableUnit>
                {
                    HamburgerPound,
                    PillsburyCrescentRolls,
                    BbqSauceOunces,
                    RedOnionOunces,
                    FrenchFriesOunces,
                    ColaCans
                }; 
                return acceptableUnits;
            }
        }

        public static AcceptableUnit HamburgerPound
        {
            get
            {
                return new AcceptableUnit
                {
                    UnitId = 1, // Pound
                    FoodId = 1 // Hamburger
                };
            }
        }

        public static AcceptableUnit PillsburyCrescentRolls
        {
            get
            {
                return new AcceptableUnit
                {
                    UnitId = 2, // Roll
                    FoodId = 2 // PillsburyCrescentRolls
                };
            }
        }

        public static AcceptableUnit BbqSauceOunces
        {
            get
            {
                return new AcceptableUnit
                {
                    UnitId = 3, // Ounces
                    FoodId = 3 // Bbq Sauce
                };
            }
        }

        public static AcceptableUnit RedOnionOunces
        {
            get
            {
                return new AcceptableUnit
                {
                    UnitId = 3, // Ounces
                    FoodId = 4 // Red Onion
                };
            }
        }

        public static AcceptableUnit FrenchFriesOunces
        {
            get
            {
                return new AcceptableUnit
                {
                    UnitId = 3, // Ounces
                    FoodId = 5 // French Fries
                };
            }
        }

        public static AcceptableUnit ColaCans
        {
            get
            {
                return new AcceptableUnit
                {
                    UnitId = 4, // Cans
                    FoodId = 6 // Cola
                };
            }
        }
    }
}