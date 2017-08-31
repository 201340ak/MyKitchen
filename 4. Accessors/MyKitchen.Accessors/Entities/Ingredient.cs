namespace MyKitchen.Accessors.Entities
{
   using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Ingredient
   {
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       
       public int Id { get; set; }

       public int RecipeId { get; set; }

       public int FoodId { get; set; }

       public decimal Quantity { get; set; }

       public virtual Recipe Recipe { get; set; }

       public virtual Food Food { get; set; }
   }
}