namespace MyKitchen.Accessors.Entities
{
   using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AcceptableUnit
   {
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
       
       public int Id { get; set; }

       public int UnitId { get; set; }

       public int FoodId { get; set; }

       public virtual Unit Unit { get; set; }

       public virtual Food Food { get; set; }
   }
}