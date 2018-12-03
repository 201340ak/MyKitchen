using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyKitchen.Accessors;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Accessors.Contexts;

namespace MyKitchen.Managers.Tests
{
    [TestClass]
    public class RecipeManagerTests
    {
        private DbContextOptions<MyKitchenDbContext> options = new DbContextOptionsBuilder<MyKitchenDbContext>()
                            .UseSqlServer(@"Server=localhost;Database=MyKitchen;Trusted_Connection=True;")
                            .Options;
        private MyKitchenDbContext MyKicthenContext => new MyKitchenDbContext(options);

        [TestMethod]
        public void GetRecipe_Integration()
        {
            var recipeId = 0;
            // Setup
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                var addedRecipe = manager.Add(TestData.TestRecipe);
                Assert.IsNotNull(addedRecipe.Id);
                recipeId = addedRecipe.Id;
            }

            // Act
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                var getRecipe = manager.Get(recipeId);

                //Assert
                Assert.IsNotNull(getRecipe);
                Assert.AreEqual(TestData.TestRecipe.Name, getRecipe.Name);
                Assert.AreEqual(TestData.TestRecipe.Description, getRecipe.Description);
                Assert.AreEqual(TestData.TestRecipe.PreparationTime, getRecipe.PreparationTime);
                Assert.AreEqual(TestData.TestRecipe.CookTime, getRecipe.CookTime);
                Assert.AreEqual(TestData.TestRecipe.Servings, getRecipe.Servings);
                Assert.AreNotEqual(0, getRecipe.Ingredients.Select(recipeFood => recipeFood.Food).Count());
            }
        }

        [TestMethod]
        public void GetAll_Integration()
        {
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                var listOfRecipes = manager.GetAll();
                Assert.IsNotNull(listOfRecipes);
                Assert.AreNotEqual(0, listOfRecipes.Count());
            }
        }

        [TestMethod]
        public void AddRecipe_Integration()
        {
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                var addedRecipe = manager.Add(TestData.TestRecipe);
                Assert.AreEqual(TestData.TestRecipe.Name, addedRecipe.Name);
                Assert.AreEqual(TestData.TestRecipe.Description, addedRecipe.Description);
                Assert.AreEqual(TestData.TestRecipe.PreparationTime, addedRecipe.PreparationTime);
                Assert.AreEqual(TestData.TestRecipe.CookTime, addedRecipe.CookTime);
                Assert.AreEqual(TestData.TestRecipe.Servings, addedRecipe.Servings);
            }
        }

        [TestMethod]
        public void DeleteRecipe_Integration()
        {
            var recipeId = 0;
            // Setup
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                var addedRecipe = manager.Add(TestData.TestRecipe);
                Assert.IsNotNull(addedRecipe.Id);
                recipeId = addedRecipe.Id;
            }

            // Act
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                var deletedRecipe = manager.Delete(recipeId);

                //Assert
                Assert.IsTrue(deletedRecipe);

                var getRecipe = manager.Get(recipeId);
                Assert.IsNull(getRecipe);
            } 
        }

        [TestMethod]
        public void UpdateRecipe_Integration()
        {
            var testRecipeToUpdate = TestData.TestRecipe;
            // Setup
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                var addedRecipe = manager.Add(TestData.TestRecipe);
                Assert.IsNotNull(addedRecipe.Id);
                testRecipeToUpdate = addedRecipe;
            }

            // Act
            using(var context = MyKicthenContext)
            {
                var accessor = new RecipeAccessor(context);
                var manager = new RecipeManager(accessor);
                testRecipeToUpdate.Name = "New and Better Runzas";
                var updatedRecipe = manager.Update(testRecipeToUpdate);
                Assert.IsNotNull(updatedRecipe);
                Assert.AreEqual("New and Better Runzas", updatedRecipe.Name);
            }
        }
    }
}
