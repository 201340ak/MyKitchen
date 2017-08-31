using System;
using System.Collections.Generic;
using MyKitchen.Accessors;
using MyKitchen.DataContracts;

namespace MyKitchen.Managers
{
    public interface IRecipeManager
    {
        Recipe Get(int recipeId);

        List<Recipe> GetAll();

        Recipe Add(Recipe recipe);

        bool Delete(int recipeId);

        Recipe Update(Recipe recipe);
    }
}
