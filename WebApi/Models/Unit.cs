namespace MyKitchen.Models
{
    using System.Collections.Generic;
    
    public class Unit
    {
        public int Id {get;set;}

        public string SingularName {get;set;}

        public string PluralName {get;set;}

        public string Abbreviation {get;set;}

        public virtual ICollection<FoodUnit> FoodUnits {get;set;}
    }
}