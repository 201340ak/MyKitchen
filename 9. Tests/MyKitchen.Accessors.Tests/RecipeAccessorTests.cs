using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Accessors.Contexts;
using System;
using System.Text;

namespace MyKitchen.Accessors.Tests
{
    [TestClass]
    public class RecipeAccessorTests
    {
        private DbContextOptions<MyKitchenDbContext> inMemoryOptions = new DbContextOptionsBuilder<MyKitchenDbContext>()
            .UseInMemoryDatabase(databaseName: "MyKitchenMemoryDB")
            .Options;
        private Contexts.MyKitchenDbContext MyKitchenContext => new Contexts.MyKitchenDbContext(inMemoryOptions);     

        [TestMethod]
        public void AddRecipe_Integration()
        {
            using(var context = MyKitchenContext)
            {
                try
                {
                    // Setup
                    var accessor = new RecipeAccessor(context);
                    var runzaRecipe = TestData.TestRecipe;
                    var unit = context.Units.Add((Entities.Unit)TestData.Pounds).Entity;
                    context.SaveChanges();

                    var unitList = new List<DataContracts.Unit>()
                    {
                        (DataContracts.Unit)unit
                    };

                    var testFood = TestData.Hamburger;
                    testFood.Units = unitList;
                    var hamburger = context.Food.Add((Entities.Food)testFood).Entity;
                    context.SaveChanges();

                    var ingredient = new DataContracts.Ingredient(){
                        FoodId = hamburger.Id,
                        Food = (DataContracts.Food)hamburger,
                        Quantity = 1
                    };
                    runzaRecipe.Ingredients = new List<DataContracts.Ingredient>()
                    {
                        ingredient
                    };

                    // Act
                    var addedRecipe = accessor.Add(runzaRecipe);
                    
                    // Assert
                    Assert.AreEqual(runzaRecipe.Name, addedRecipe.Name);
                    Assert.AreEqual(runzaRecipe.Description, addedRecipe.Description);
                    Assert.AreEqual(runzaRecipe.PreparationTime, addedRecipe.PreparationTime);
                    Assert.AreEqual(runzaRecipe.CookTime, addedRecipe.CookTime);
                    Assert.AreEqual(runzaRecipe.Servings, addedRecipe.Servings);
                    Assert.AreEqual(Encoding.ASCII.GetBytes(runzaRecipe.Image), addedRecipe.Image);

                    // Clean up
                    context.Database.EnsureDeleted();
                }
                catch (Exception e)
                {
                    // Clean up
                    context.Database.EnsureDeleted();
                    throw e;
                }
            }
        }

        [TestMethod]
        public void GetRecipe_Integration()
        {
            var recipeId = AddRecipeToContextForMocking(MyKitchenContext).Id;

            // Act
            using(var context = MyKitchenContext)
            {
                try
                {
                    var accessor = new RecipeAccessor(context);
                    var getRecipe = accessor.Get(recipeId);

                    //Assert
                    Assert.IsNotNull(getRecipe);
                    Assert.AreEqual(TestData.TestRecipe.Name, getRecipe.Name);
                    Assert.AreEqual(TestData.TestRecipe.Description, getRecipe.Description);
                    Assert.AreEqual(TestData.TestRecipe.PreparationTime, getRecipe.PreparationTime);
                    Assert.AreEqual(TestData.TestRecipe.CookTime, getRecipe.CookTime);
                    Assert.AreEqual(TestData.TestRecipe.Servings, getRecipe.Servings);
                    Assert.AreNotEqual(0, getRecipe.Ingredients.Select(recipeFood => recipeFood.Food));

                    // Clean up
                    context.Database.EnsureDeleted();
                }
                catch(Exception e)
                {
                    // Clean up
                    context.Database.EnsureDeleted();
                    throw e;
                }
            }            
        }

        [TestMethod]
        public void GetAll_Integration()
        {
            AddRecipeToContextForMocking(MyKitchenContext);
            using(var context = MyKitchenContext)
            {
                try 
                {
                    var accessor = new RecipeAccessor(context);
                    var listOfRecipes = accessor.GetAll();
                    Assert.IsNotNull(listOfRecipes);
                    Assert.AreEqual(1, listOfRecipes.Count());

                    // Clean up
                    context.Database.EnsureDeleted();
                }
                catch(Exception e)
                {
                    // Clean up
                    context.Database.EnsureDeleted();
                    throw e;
                }
            }
        }

        [TestMethod]
        public void DeleteRecipe_Integration()
        {
            // Setup
            var recipeId = AddRecipeToContextForMocking(MyKitchenContext).Id;

            // Act
            using(var context = MyKitchenContext)
            {
                try
                {
                    var accessor = new RecipeAccessor(context);
                    var deletedRecipe = accessor.Delete(recipeId);

                    //Assert
                    Assert.IsTrue(deletedRecipe);

                    var getRecipe = accessor.Get(recipeId);
                    Assert.IsNull(getRecipe);
                    
                    // Clean up
                    context.Database.EnsureDeleted();
                }
                catch (Exception e)
                {
                    // Clean up
                    context.Database.EnsureDeleted();

                    throw e;
                }
            } 
        }

        [TestMethod]
        public void UpdateRecipe_Integration()
        {
            // Setup
            var testRecipeToUpdate = AddRecipeToContextForMocking(MyKitchenContext);

            // Act
            using(var context = MyKitchenContext)
            {
                try 
                {
                    var accessor = new RecipeAccessor(context);
                    testRecipeToUpdate.Name = "New and Better Runzas";
                    var updatedRecipe = accessor.Update(testRecipeToUpdate);
                    Assert.IsNotNull(updatedRecipe);
                    Assert.AreEqual("New and Better Runzas", updatedRecipe.Name);

                    // Clean up
                    context.Database.EnsureDeleted();
                }
                catch (Exception e)
                {
                    // Clean up
                    context.Database.EnsureDeleted();

                    throw e;
                }
            }
        }

        private DataContracts.Recipe AddRecipeToContextForMocking(MyKitchenDbContext myKitchenContext)
        {
            using(var context = myKitchenContext)
            {
                var accessor = new RecipeAccessor(context);
                var runzaRecipe = TestData.TestRecipe;
                var unit = context.Units.Add((Entities.Unit)TestData.Pounds).Entity;
                context.SaveChanges();

                var unitList = new List<DataContracts.Unit>()
                {
                    (DataContracts.Unit)unit
                };

                var testFood = TestData.Hamburger;
                testFood.Units = unitList;
                var hamburger = context.Food.Add((Entities.Food)testFood).Entity;
                context.SaveChanges();

                var ingredient = new DataContracts.Ingredient(){
                    FoodId = hamburger.Id,
                    Food = (DataContracts.Food)hamburger,
                    Quantity = 1
                };
                runzaRecipe.Ingredients = new List<DataContracts.Ingredient>()
                {
                    ingredient
                };
                var addedRecipe = accessor.Add(runzaRecipe);
                Assert.IsNotNull(addedRecipe.Id);
                return addedRecipe;
            }
        }
    }
}
