using MyKitchen.Accessors.Entities;
using MyKitchen.DataContracts;

namespace MyKitchen.Accessors
{
    using System;
    using Contexts;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class FoodAccessor : IFoodAccessor
    {
        public FoodAccessor(MyKitchenDbContext myKitchenDbContext)
        {
            MyKitchenDbContext = myKitchenDbContext ?? throw new ArgumentNullException(nameof(myKitchenDbContext));
        }

        private MyKitchenDbContext MyKitchenDbContext { get; }

        public DataContracts.Food Add(DataContracts.Food food)
        {
            var unitFromContext = MyKitchenDbContext.Units.FirstOrDefault(unit => unit.Id == food.Unit.Id);
            if(unitFromContext == null)
            {
                // TODO: Decide how to actually handle this scenerio..
                throw new Exception($"Unit {food.Unit?.Name} with id {food.UnitId} does not exist. Please use existing Unit");
            }
            food.Unit = (DataContracts.Unit)unitFromContext;
            var addedFood = MyKitchenDbContext.Food.Add((Entities.Food)food).Entity;
            MyKitchenDbContext.SaveChanges();
            return (DataContracts.Food)addedFood;
        }

        public DataContracts.Food Get(int foodId)
        {
            var gotFood = MyKitchenDbContext.Food
            .Include(f => f.Unit)
            .FirstOrDefault(f => f.Id == foodId);

            MyKitchenDbContext.Entry(gotFood)
            .Collection(food => food.Ingredients).Query()
            .Include(recipeFood => recipeFood.Recipe).Load();

            return (DataContracts.Food)gotFood;
        }

        public List<DataContracts.Food> GetAll()
        {
            var foods = MyKitchenDbContext.Food
            .Include(f => f.Unit);

            foreach(Entities.Food food in foods)
            {
                MyKitchenDbContext.Entry(food)
                .Collection(f => f.Ingredients).Query()
                .Include(recipeFood => recipeFood.Recipe).Load();                
            }

            return foods.ToList().Select(f => (DataContracts.Food)f).ToList();
        }

        public DataContracts.Food Update(DataContracts.Food food)
        {            
            var foodToUpdate = MyKitchenDbContext.Food.Single(f => f.Id == food.Id);
            MyKitchenDbContext.Entry(foodToUpdate).CurrentValues.SetValues(food);
            MyKitchenDbContext.SaveChanges();
            return (DataContracts.Food)foodToUpdate;
        }
    }
}