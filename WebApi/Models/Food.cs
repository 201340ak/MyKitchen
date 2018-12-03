using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyKitchen.Models
{
    public class Food
    {
        public int Id {get; set;}

        public string Name {get; set;}

        public virtual ICollection<FoodUnit> AvailableFoodUnits {get;set;}
    }
}