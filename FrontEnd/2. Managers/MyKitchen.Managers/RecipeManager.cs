using System;
using System.Collections.Generic;
using MyKitchen.Accessors;
using MyKitchen.DataContracts;

namespace MyKitchen.Managers
{
    public class RecipeManager : IRecipeManager
    {
        public RecipeManager(IRecipeAccessor recipeAccessor)
        {
            RecipeAccessor = recipeAccessor ?? throw new ArgumentNullException(nameof(recipeAccessor));
        }

        private IRecipeAccessor RecipeAccessor { get; set; }

        public Recipe Get(int recipeId)
        {
            return RecipeAccessor.Get(recipeId);
        }

        public List<Recipe> GetAll()
        {
            return RecipeAccessor.GetAll();
        }

        public Recipe Add(Recipe recipe)
        {
            return RecipeAccessor.Add(recipe);
        }

        public bool Delete(int recipeId)
        {
            return RecipeAccessor.Delete(recipeId);
        }

        public Recipe Update(Recipe recipe)
        {
            return RecipeAccessor.Update(recipe);
        }
    }
}
