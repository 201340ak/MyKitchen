using System;
using System.Collections.Generic;
using MyKitchen.Accessors;
using MyKitchen.DataContracts;

namespace MyKitchen.Managers
{
    public interface IFoodManager
    {
        Food Get(int foodId);

        List<Food> GetAll();

        Food Add(Food food);
    }
}
