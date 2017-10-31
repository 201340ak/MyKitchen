using System;
using System.Collections.Generic;
using MyKitchen.Accessors;
using MyKitchen.DataContracts;
using MyKitchen.Managers;

namespace MyKitchen.Managers
{
    public class FoodManager : IFoodManager
    {
        public FoodManager(IFoodAccessor foodAccessor)
        {
            FoodAccessor = foodAccessor ?? throw new ArgumentNullException(nameof(foodAccessor));
        }

        private IFoodAccessor FoodAccessor { get; set; }

        public Food Get(int foodId)
        {
            return FoodAccessor.Get(foodId);
        }

        public List<Food> GetAll()
        {
            return FoodAccessor.GetAll();
        }

        public Food Add(Food food)
        {
            return FoodAccessor.Add(food);
        }
    }
}
