namespace MyKitchen.Accessors.Entities
{
   using System;
   using System.Text;
   using System.Linq;

   public partial class Recipe
   {       
        public static explicit operator DataContracts.Recipe(Recipe entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new DataContracts.Recipe
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                PreparationTime = entity.PreparationTime,
                CookTime = entity.CookTime,
                Servings = entity.Servings,
                Image = entity.Image != null ? Encoding.ASCII.GetString(entity.Image) : null,
                Deleted = entity.Deleted,
                Ingredients = entity.Ingredients?
                    .Select(r => (DataContracts.Ingredient)r)
                    .ToList()
            };
        }

        public static explicit operator Recipe(DataContracts.Recipe entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Recipe
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                PreparationTime = entity.PreparationTime,
                CookTime = entity.CookTime,
                Servings = entity.Servings,
                Image = !string.IsNullOrEmpty(entity.Image) ? Encoding.ASCII.GetBytes(entity.Image) : null,
                Deleted = entity.Deleted,
                Ingredients = entity.Ingredients?
                    .Select(r => (Ingredient)r)
                    .ToList()
            };
        }
   }
}