using System.Collections.Generic;
using MyKitchen.Accessors.Entities;

namespace MyKitchen.Accessors.Contexts.InitializeData
{
    public static class Units
    {
        public static List<Unit> All
        {
            get { return new List<Unit> { Pounds, Rolls, Ounces, Cans }; }
        }

        private static Unit Pounds
        {
            get
            {
                return new Unit
                {
                    Name = "Pounds"
                };
            }
        }

        private static Unit Rolls
        {
            get
            {
                return new Unit
                {
                    Name = "Rolls"
                };
            }
        }

        private static Unit Ounces
        {
            get
            {
                return new Unit
                {
                    Name = "Ounces"
                };
            }
        }

        private static Unit Cans
        {
            get
            {
                return new Unit
                {
                    Name = "Cans"
                };
            }
        }
    }
}