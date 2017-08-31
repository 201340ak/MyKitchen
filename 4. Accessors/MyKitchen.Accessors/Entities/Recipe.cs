namespace MyKitchen.Accessors.Entities
{
   using System;
   using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Recipe
   {
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }

       public string Name { get; set; }

       public string Description { get; set; }

       public int PreparationTime { get; set; }

       public int CookTime { get; set; }

       public int Servings { get; set; }

       public bool Deleted { get; set; }

       public virtual ICollection<Ingredient> Ingredients { get; set; }

       public virtual ICollection<Instruction> Instructions { get; set; }
   }
}