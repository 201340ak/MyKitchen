using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyKitchen.Accessors;
using MyKitchen.Accessors.Contexts;
using MyKitchen.Clients;
using MyKitchen.Managers;
using MyKitchen_Client_WebApp.Controllers;
using MyKitchen.DataContracts;
using System.Collections.Generic;

namespace MyKitchen.Clients.Tests
{
    [TestClass]
    public class RecipeControllerTests
    {
        private DbContextOptions<MyKitchenDbContext> options = new DbContextOptionsBuilder<MyKitchenDbContext>()
                            .UseInMemoryDatabase(@"MyKitchenDb")
                            .Options;
        private MyKitchenDbContext MyKicthenContext => new MyKitchenDbContext(options);

        public void SetupTestData()
        {
        }

        [TestMethod]
        public void GetAll_Integration()
        {
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);

                using(var controller = new RecipeController(manager)){
                    var recipes = controller.GetAll();
                    Assert.IsNotNull(recipes);
                    Assert.AreNotEqual(0, recipes.Count());
                }
            }
        }
        
        [TestMethod]
        public void Add_Integration()
        {
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);

                using(var controller = new RecipeController(manager)){
                    var recipeAdded = controller.Add(1); //TestRecipe);
                    Assert.IsNotNull(recipeAdded);
                    Assert.IsTrue(recipeAdded);
                }
            }
        }

        private Recipe TestRecipe
        {
            get {
                return new Recipe
                {
                    Name = "First Recipe",
                    Description = "Very first recipe.",
                    PreparationTime = 5,
                    CookTime = 20,
                    Servings = 2,
                    Deleted = false,
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient
                        {
                            FoodId = 1,
                            RecipeId = 1,
                            Quantity = 1
                        }
                    }
                };
            }
        }
    }
}
