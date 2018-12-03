namespace MyKitchen.Models
{
    public class Ingredient
    {
        public int Id {get;set;}

        public int FoodId {get;set;}

        public virtual Food Food { get; set; }

        public decimal Quantity {get;set;}

        public int SelectedUnitId {get;set;}

        public virtual Unit SelectedUnit {get;set;}

        public int RecipeId {get;set;}

        public virtual Recipe Recipe {get;set;}
    }
}