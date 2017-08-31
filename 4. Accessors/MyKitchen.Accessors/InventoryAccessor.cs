using MyKitchen.Accessors.Entities;
using MyKitchen.DataContracts;
using MyKitchen.Accessors.Contexts;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyKitchen.Accessors
{
    public class InventoryAccessor : IInventoryAccessor
    {
        public InventoryAccessor(MyKitchenDbContext myKitchenDbContext)
        {
            MyKitchenDbContext = myKitchenDbContext ?? throw new ArgumentNullException(nameof(myKitchenDbContext));
        }

        private MyKitchenDbContext MyKitchenDbContext { get; set; }

        public DataContracts.Inventory Add(DataContracts.Inventory inventory)
        {
            var inventoryToAdd = (Entities.Inventory)inventory;
            inventoryToAdd.Foods = GetFoodFromContext(inventoryToAdd.Foods.ToList());
            var addedInventory = MyKitchenDbContext.Lists.Add(inventoryToAdd).Entity as Entities.Inventory;
            MyKitchenDbContext.SaveChanges();
            return (DataContracts.Inventory)addedInventory;
        }

        public DataContracts.Inventory Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public DataContracts.Inventory GetAll()
        {
            throw new System.NotImplementedException();
        }

        public DataContracts.Inventory Get(int id)
        {
            throw new System.NotImplementedException();
        }

        private List<Entities.Food> GetFoodFromContext(List<Entities.Food> foods)
        {
            if(foods == null)
            {
                return null;
            }

            var foodsFromContext = new List<Entities.Food>();

            foreach(Entities.Food food in foods)
            {
                var foodFromContext = food?.Id != null ? MyKitchenDbContext.Food.FirstOrDefault(f => f.Id == food.Id) : null;
                if(foodFromContext == null)
                {
                    // TODO: Decide how to actually handle this scenerio..
                    throw new Exception($"Food {food?.Name} with id {food.Id} does not exist. Please use existing Food Item");
                }

                foodsFromContext.Add(foodFromContext);
            }

            return foodsFromContext;
        }
    }
}