using System;
using System.Collections.Generic;

namespace MyKitchen.Accessors
{
    public interface IRecipeAccessor
    {
        /// <Summarry>
        /// Adds a recipe to the given context.
        /// </Summary>
        /// <Returns>Recipe that is added to context with Id.</Returns>
        DataContracts.Recipe Add(DataContracts.Recipe recipe);

        /// <Summarry>
        /// Gets recipe by Id.
        /// </Summary>
        /// <Returns>Recipe that is not marked as deleted.</Returns>
        DataContracts.Recipe Get(int recipeId);
        
        /// <Summarry>
        /// Get all recipes from context.
        /// </Summary>
        /// <Returns>List of recipes not marked as deleted.</Returns>
        List<DataContracts.Recipe> GetAll();

        /// <Summarry>
        /// Marks a recipe as deleted by Id.
        /// </Summary>
        /// <Returns>True if successfully marked as deleted; False if failed to mark as delete.</Returns>
        bool Delete(int recipeId);

        /// <Summarry>
        /// Updates the recipe with the updated information. Input recipe must include Id.
        /// </Summary>
        /// <Returns>Recipe with updated information.</Returns>
        DataContracts.Recipe Update(DataContracts.Recipe recipe);
    }
}
