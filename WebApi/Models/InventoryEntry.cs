using System.ComponentModel.DataAnnotations.Schema;
namespace MyKitchen.Models
{
    public class InventoryEntry
    {
        public int Id {get; set;}

        public int UserId {get;set;}

        public int FoodId {get;set;}

        public virtual User User {get;set;}

        public virtual Food Food { get; set; }

        public decimal Quantity {get; set;}

        public int SelectedUnitId {get;set;}

        public virtual Unit SelectedUnit {get; set;}
    }
}