using MyKitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyKitchen.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MyKitchenContext context)
        {
            if(context.User.Any())
            {
                return;
                // Database already exists;
            }

            // Seed(context);
        }

        private static void Seed(MyKitchenContext context)
        {
            SeedUsers(context);
            SeedUnits(context);
            SeedFood(context);
        }

        private static void SeedUsers(MyKitchenContext context)
        {
            var users = new User[]
            {
                new User{Email="FirstUserEmail@site.com",DisplayName="First User",Password="FirstUserPassword"}
            };

            context.User.AddRange(users);
            context.SaveChanges();            
        }

        private static void SeedUnits(MyKitchenContext context)
        {
            var ounces = new Unit
            {
                SingularName = "ounce",
                PluralName = "ounces",
                Abbreviation = "oz"
            };
            var pounds = new Unit
            {
                SingularName = "pound",
                PluralName = "pounds",
                Abbreviation = "lbs"
            };
            var cups = new Unit
            {
                SingularName = "cup",
                PluralName = "cups",
                Abbreviation = "c"
            };
            var units = new Unit[] {ounces, pounds, cups};
            context.Unit.AddRange(units);
            context.SaveChanges();
        }

        private static void SeedFood(MyKitchenContext context)
        {
            var potatoes = new Food{
                Name = "Potato",
            };

            context.Food.Add(potatoes);
            context.SaveChanges();
        }

        private static void SeedFoodUnits(MyKitchenContext context)
        {
            var potato = context.Food.Find(1);
            var ounces = context.Unit.Find(1);
            var pounds = context.Unit.Find(2);

            var potatoOunces = new FoodUnit
            {
                Food = potato,
                Unit = ounces
            };

            var potatoPounds = new FoodUnit
            {
                Food = potato,
                Unit = pounds
            };

            context.FoodUnit.Add(potatoOunces);
            context.FoodUnit.Add(potatoPounds);
        }
    }
}