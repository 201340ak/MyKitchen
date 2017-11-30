namespace MyKitchen.Accessors
{
    using System;
    using System.Collections.Generic;
    using Contexts;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyKitchen.Accessors.Entities;

    public class RecipeAccessor : IRecipeAccessor
    {
        public RecipeAccessor(MyKitchenDbContext myKitchenDbContext)
        {
            MyKitchenDbContext = myKitchenDbContext ?? throw new ArgumentNullException(nameof(myKitchenDbContext));
        }

        private MyKitchenDbContext MyKitchenDbContext { get; }

        public DataContracts.Recipe Add(DataContracts.Recipe recipe)
        {
            var recipeToAdd = (Entities.Recipe)recipe;
            GetFoodFromContext(recipeToAdd.Ingredients.ToList());
            var addedRecipe = MyKitchenDbContext.Recipes.Add(recipeToAdd).Entity;
            MyKitchenDbContext.SaveChanges();
            return (DataContracts.Recipe)addedRecipe;
        }

        public DataContracts.Recipe Get(int recipeId)
        {
            var gotRecipe = MyKitchenDbContext.Recipes.FirstOrDefault(r => r.Id == recipeId && !r.Deleted);
            if (gotRecipe == null)
            {
                return null;
            }

            MyKitchenDbContext.Entry(gotRecipe)
            .Collection(recipe => recipe.Ingredients).Query()
            .Include(recipeFood => recipeFood.Food)
            .ThenInclude(food => food.Unit).Load();

            return (DataContracts.Recipe)gotRecipe;
        }

        public List<DataContracts.Recipe> GetAll()
        {
            var recipes = MyKitchenDbContext.Recipes.Where(recipe => !recipe.Deleted);

            foreach(Entities.Recipe recipe in recipes)
            {
                MyKitchenDbContext.Entry(recipe)
                .Collection(r => r.Ingredients).Query()
                .Include(recipeFood => recipeFood.Food)
                .ThenInclude(food => food.Unit).Load();
            }

            return recipes.Select(r => (DataContracts.Recipe)r).ToList();
        }

        public bool Delete(int recipeId)
        {
            var recipe = MyKitchenDbContext.Recipes.Single(r => r.Id == recipeId);
            recipe.Deleted = true;
            var returnValue = MyKitchenDbContext.SaveChanges();
            return returnValue > 0 ? true : false;
        }

        public DataContracts.Recipe Update(DataContracts.Recipe recipe)
        {
            var recipeToUpdate = MyKitchenDbContext.Recipes.Single(r => r.Id == recipe.Id);
            MyKitchenDbContext.Entry(recipeToUpdate).CurrentValues.SetValues(recipe);
            MyKitchenDbContext.SaveChanges();
            return (DataContracts.Recipe)recipeToUpdate;
        }

        private void GetFoodFromContext(List<Entities.Ingredient> recipeFoods)
        {
            if(recipeFoods == null)
            {
                return;
            }

            foreach(Entities.Ingredient recipeFood in recipeFoods)
            {
                var foodId = recipeFood.FoodId != 0 ? recipeFood.FoodId : recipeFood.Food.Id;
                var foodFromContext = recipeFood?.FoodId != null ? MyKitchenDbContext.Food.FirstOrDefault(food => food.Id == recipeFood.FoodId) : null;
                if(foodFromContext == null)
                {
                    // TODO: Decide how to actually handle this scenerio..
                    MyKitchenDbContext.Food.Add(recipeFood.Food);
                    // throw new Exception($"Food {recipeFood?.Food?.Name} with id {recipeFood.FoodId} does not exist. Please use existing Food Item");
                }

                recipeFood.Food = foodFromContext;
            }
        }
    }
}