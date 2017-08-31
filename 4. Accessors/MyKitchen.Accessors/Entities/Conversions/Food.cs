namespace MyKitchen.Accessors.Entities
{
   using System;
   using System.Linq;

   public partial class Food
   {
        public static explicit operator DataContracts.Food(Food entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new DataContracts.Food
            {
                Id = entity.Id,
                Name = entity.Name,
                Unit = (DataContracts.Unit)entity.Unit,
                ServingSize = entity.ServingSize,
                Calories = entity.Calories,
                Price = entity.Price,
                UnitQuantityForPrice = entity.UnitQuantityForPrice,
                Ingredients = entity.Ingredients?
                    .Select(r => (DataContracts.Ingredient)r)
                    .ToList()
            };
        }

        public static explicit operator Food(DataContracts.Food entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Food
            {
                Id = entity.Id,
                Name = entity.Name,
                Unit = (Unit)entity.Unit,
                ServingSize = entity.ServingSize,
                Calories = entity.Calories,
                Price = entity.Price,
                UnitQuantityForPrice = entity.UnitQuantityForPrice,
                Ingredients = entity.Ingredients?
                    .Select(r => (Ingredient)r)
                    .ToList()
            };
        }
   }
}