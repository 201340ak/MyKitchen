namespace MyKitchen.DataContracts
{
   using System;
   using System.Collections.Generic;

   public class Recipe
   {
       public int Id { get; set; }

       public string Name { get; set; }

       public string Description { get; set; }

       public int PreparationTime { get; set; }

       public int CookTime { get; set; }

       public int Servings { get; set; }

       public bool Deleted { get; set; }

       public ICollection<Ingredient> Ingredients { get; set; }
   }
}