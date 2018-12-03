using System.Collections.Generic;

namespace MyKitchen.Accessors
{
    public interface IFoodAccessor
    {
        ///<Summary>
        /// Adds food to given context.
        ///</Summary>
        ///<Returns>Added Food with Id.</Returns>
        DataContracts.Food Add(DataContracts.Food food);

        ///<Summary>
        /// Gets food by Id.
        ///</Summary>
        ///<Returns>Food </Returns>
        DataContracts.Food Get(int foodId);

        ///<Summary>
        /// Gets all food in given context.
        ///</Summary>
        ///<Returns>List of all food items in given context.</Returns>
        List<DataContracts.Food> GetAll();
    }
}