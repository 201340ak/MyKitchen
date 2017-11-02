using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyKitchen.DataContracts;
using MyKitchen.Managers;
using MyKitchen.Accessors;
using MyKitchen.Accessors.Contexts;

namespace MyKitchen_Client_WebApp.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {

        public RecipeController(IRecipeManager manager)
        {
            Manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        private IRecipeManager Manager { get; }


        [HttpGet("[action]")]
        public IEnumerable<Recipe> GetAll()
        {
            var recipes = Manager.GetAll().OrderByDescending(recipe => recipe.Id);
            return recipes;
        }

        [HttpPost("[action]")]
        public bool Add([FromBody] Recipe recipe)
        {
            try
            {
                var addedRecipe = Manager.Add(recipe);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("[action]")]
        public bool Delete([FromBody] int recipeId)
        {
            try
            {
                var deletedRecipe = Manager.Delete(recipeId);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
