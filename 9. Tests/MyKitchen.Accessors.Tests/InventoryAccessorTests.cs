using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyKitchen.Accessors.Contexts;

namespace MyKitchen.Accessors.Tests
{
    [TestClass]
    public class InventoryAccessorTests
    {
        private DbContextOptions<MyKitchenDbContext> inMemoryOptions = new DbContextOptionsBuilder<MyKitchenDbContext>()
            .UseInMemoryDatabase(databaseName: "MyKitchenMemoryDB")
            .Options;
        private Contexts.MyKitchenDbContext MyKitchenContext => new Contexts.MyKitchenDbContext(inMemoryOptions);     

        [TestMethod]
        public void AddInventoryTest()
        {
            using(var context = MyKitchenContext)
            {
                try {
                    // Setup
                    var accessor = new InventoryAccessor(MyKitchenContext);
                    var testList = TestData.UserOneInventory;
                    // AddUser
                    // var testUser = TestData.User;
                    // var user = context.Users.Add(user).Entity;

                    // AddFood
                    var hamburger = TestData.Hamburger;
                    var food = context.Food.Add((Entities.Food)hamburger).Entity;
                    context.SaveChanges();
                    testList.Foods = new List<DataContracts.Food>
                    {
                        (DataContracts.Food)food
                    };
                    
                    // Act
                    var addedList = accessor.Add(testList);
                    // Assert
                    Assert.AreEqual(1, addedList.Foods.Count);
                    // Assert.AreEqual(testList.UserId, addedList.UserId)

                    // Clean up 
                    context.Database.EnsureDeleted();
                }
                catch (Exception e)
                {
                    context.Database.EnsureDeleted();
                    throw e;
                }
            }
        }

        [TestMethod]
        public void GetInventory()
        {
            var inventoryId = AddInventoryToContextForMock(MyKitchenContext).Id;

            // Act
            using(var context = MyKitchenContext)
            {
                try{
                    var accessor = new InventoryAccessor(context);
                    var getInventory = accessor.Get(inventoryId);

                    // Assert
                    Assert.IsNotNull(getInventory);
                    Assert.AreEqual(1, getInventory.Foods.Count);
                }
                catch (Exception e)
                {
                    context.Database.EnsureDeleted();
                    throw e;
                }
            }
        }

        private DataContracts.Inventory AddInventoryToContextForMock(MyKitchenDbContext myKitchenContext)
        {
            using(var context = myKitchenContext)
            {
                var testList = TestData.UserOneInventory;    
                var hamburger = TestData.Hamburger;
                // var food = context.Food.Add((Entities.Food)hamburger).Entity;
                context.SaveChanges();
                testList.Foods = new List<DataContracts.Food>
                {
                    hamburger
                };
                
                var addedList = context.Lists.Add((Entities.Inventory)testList).Entity as Entities.Inventory;
                context.SaveChanges();
                return (DataContracts.Inventory)addedList;
            }
        } 
    }
}