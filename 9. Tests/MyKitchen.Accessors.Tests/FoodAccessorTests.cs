namespace MyKitchen.Accessors.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Contexts;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class FoodAccessorTests
    {
        private DbContextOptions<MyKitchenDbContext> inMemoryOptions = new DbContextOptionsBuilder<MyKitchenDbContext>()
            .UseInMemoryDatabase(databaseName: "MyKitchenMemoryDB")
            .Options;

        private Contexts.MyKitchenDbContext MyKicthenContext => new Contexts.MyKitchenDbContext(inMemoryOptions);

        [TestMethod]
        public void Add_Integration()
        {
            using(var context = MyKicthenContext)
            {
                try
                {
                    // Setup
                    var hamburger = TestData.Hamburger;
                    var unit = context.Units.Add((Entities.Unit)TestData.Pounds).Entity;

                    context.SaveChanges();

                    var unitList = new List<DataContracts.Unit>()
                    {
                        (DataContracts.Unit)unit
                    };

                    hamburger.Units = unitList;
                    var accessor = new FoodAccessor(context);
                    
                    // Act
                    var addedFood = accessor.Add(hamburger);

                    // Assert
                    Assert.AreEqual(hamburger.Name, addedFood.Name);
                    Assert.AreEqual(hamburger.Units.First().Name, addedFood.Units.First().Name);
                    Assert.AreEqual(hamburger.ServingSize, addedFood.ServingSize);
                    Assert.AreEqual(hamburger.Calories, addedFood.Calories);
                    Assert.AreEqual(hamburger.Price, addedFood.Price);

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
        public void GetFood_Integration()
        {
            // Act
            using(var context = MyKicthenContext)
            {
                // Setup
                var testFood = AddFoodToContextForMock(MyKicthenContext);
                try
                {
                    var accessor = new FoodAccessor(context);
                    var getFood = accessor.Get(testFood.Id);

                    //Assert
                    Assert.IsNotNull(getFood);
                    Assert.AreEqual(testFood.Name, getFood.Name);
                    Assert.AreEqual(testFood.Units.First().Name, getFood.Units.First().Name);
                    Assert.AreEqual(testFood.ServingSize, getFood.ServingSize);
                    Assert.AreEqual(testFood.Calories, getFood.Calories);
                    Assert.AreEqual(testFood.Price, getFood.Price);

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
            AddFoodToContextForMock(MyKicthenContext);
            using(var context = MyKicthenContext)
            {
                try {
                    var accessor = new FoodAccessor(context);
                    var listOfFood = accessor.GetAll();
                    Assert.IsNotNull(listOfFood);
                    Assert.AreEqual(1, listOfFood.Count());

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
        public void Update_Integration()
        {
                // Setup
                var testFood = AddFoodToContextForMock(MyKicthenContext);
            // Act
            using(var context = MyKicthenContext)
            {
                try
                {
                    var accessor = new FoodAccessor(context);
                    testFood.Name = "Branded Hamburger";
                    var updatedFood = accessor.Update(testFood);
                    Assert.IsNotNull(updatedFood);
                    Assert.AreEqual("Branded Hamburger", updatedFood.Name);

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

        private DataContracts.Food AddFoodToContextForMock(MyKitchenDbContext myKitchenContext)
        {
            using(var context = myKitchenContext)
            {
                var hamburger = TestData.Hamburger;
                var unit = context.Units.Add((Entities.Unit)TestData.Pounds).Entity;

                var unitList = new List<DataContracts.Unit>()
                {
                    (DataContracts.Unit)unit
                };
                context.SaveChanges();
                hamburger.Units = unitList;
                var accessor = new FoodAccessor(context);
                return accessor.Add(hamburger);
            }
        }
    }
}