using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyKitchen.Accessors.Contexts;
using System.Linq;

namespace MyKitchen.Accessors.Tests
{
    [TestClass]
    public class ConverstionTests
    {
        private DbContextOptions<MyKitchenDbContext> inMemoryOptions = new DbContextOptionsBuilder<MyKitchenDbContext>()
            .UseInMemoryDatabase(databaseName: "MyKitchenMemoryDB")
            .Options;
        private Contexts.MyKitchenDbContext MyKitchenContext => new Contexts.MyKitchenDbContext(inMemoryOptions);     

        [TestMethod]
        public void ConvertFood()
        {
            var testUnit1 = new Entities.Unit
            {
                Id = 1,
                Name = "TestUnit1",
                Abbreviation = "Abbr1",
                Type = Entities.UnitType.Metric
            };
            var testUnit2 = new Entities.Unit
            {
                Id = 1,
                Name = "TestUnit2",
                Abbreviation = "Abbr2",
                Type = Entities.UnitType.US_Conventional
            };
            var acceptableUnits = new List<Entities.AcceptableUnit>
            {
                new Entities.AcceptableUnit
                {
                    Unit = testUnit1,
                    UnitId = testUnit1.Id
                },
                new Entities.AcceptableUnit
                {
                    Unit = testUnit2,
                    UnitId = testUnit2.Id
                }
            };
            var entityFood = new Entities.Food()
            {
                Id = 1,
                Name = "TestFood",
                ServingSize = 1,
                Calories = 1,
                Price = 1.00M,
                Units = acceptableUnits,
            };

            var convertedDataContractFood = (DataContracts.Food)entityFood;
            Assert.AreEqual(entityFood.Id, convertedDataContractFood.Id);
            Assert.AreEqual(entityFood.Name, convertedDataContractFood.Name);
            Assert.AreEqual(entityFood.ServingSize, convertedDataContractFood.ServingSize);
            Assert.AreEqual(entityFood.Calories, convertedDataContractFood.Calories);
            Assert.AreEqual(entityFood.Price, convertedDataContractFood.Price);
            
            Assert.AreEqual(entityFood.Units.Count, convertedDataContractFood.Units.Count);
            Assert.AreEqual(entityFood.Units.First().Unit.Name, convertedDataContractFood.Units.First().Name);
        }
    }
}