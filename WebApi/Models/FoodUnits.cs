using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyKitchen.Models
{
    public class FoodUnit
    {

        public int Id {get;set;}

        public int FoodID { get; set; }

        public int UnitID { get; set; }

        public virtual Food Food { get; set; }

        public virtual Unit Unit { get; set; }
    }
}