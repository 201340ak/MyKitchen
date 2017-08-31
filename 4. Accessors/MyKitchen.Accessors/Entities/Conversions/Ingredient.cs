namespace MyKitchen.Accessors.Entities
{
    public partial class Ingredient
    {
        public static explicit operator DataContracts.Ingredient(Ingredient entity)
        {
            if(entity == null)
            {
                return null;
            }

            if(entity.Recipe?.Ingredients != null)
            {
                entity.Recipe.Ingredients = null;
            }
            
            if(entity.Food?.Ingredients != null)
            {
                entity.Food.Ingredients = null;
            }

            return new DataContracts.Ingredient
            {
                Id = entity.Id,
                RecipeId = entity.RecipeId,
                Recipe = (DataContracts.Recipe)entity.Recipe,
                FoodId = entity.FoodId,
                Food = (DataContracts.Food)entity.Food,
                Quantity = entity.Quantity
            };
        }

        public static explicit operator Ingredient(DataContracts.Ingredient entity)
        {
            if(entity == null)
            {
                return null;
            }

            if(entity.Recipe?.Ingredients != null)
            {
                entity.Recipe.Ingredients = null;
            }

            if(entity.Food?.Ingredients != null)
            {
                entity.Food.Ingredients = null;
            }

            return new Ingredient
            {
                Id = entity.Id,
                RecipeId = entity.RecipeId,
                Recipe = (Recipe)entity.Recipe,
                FoodId = entity.FoodId,
                Food = (Food)entity.Food,
                Quantity = entity.Quantity
            };
        }
    }
}