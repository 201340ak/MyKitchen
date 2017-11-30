namespace MyKitchen.DataContracts
{
   using System;

   public partial class Ingredient
   {
       public int Id { get; set; }

       public int RecipeId { get; set; }

       public int FoodId { get; set; }

       public int UnitId { get; set; }

       public Recipe Recipe { get; set; }

       public Food Food { get; set; }

       public decimal Quantity { get; set; }

       public Unit Unit { get; set; }
   }
}