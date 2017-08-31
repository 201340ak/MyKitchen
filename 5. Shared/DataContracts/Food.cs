namespace MyKitchen.DataContracts
{
    using System;
    using System.Collections.Generic;

    public class Food
    {
        public int Id { get; set; }

        public int UnitId { get; set; }

        public string Name { get; set; }

        public Unit Unit { get; set; }

        public decimal ServingSize { get; set; }

        public int Calories { get; set; }

        public decimal Price { get; set; }

        public decimal UnitQuantityForPrice { get; set; }

       public ICollection<Ingredient> Ingredients { get; set; }
    }
}