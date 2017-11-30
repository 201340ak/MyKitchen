namespace MyKitchen.Accessors.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Food
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UnitId { get; set; }

        public string Name { get; set; }

        public decimal ServingSize { get; set; }

        public int Calories { get; set; }

        public decimal Price { get; set; }

        public decimal UnitQuantityForPrice { get; set; }

        public virtual ICollection<Unit> Units { get; set; }

       public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}