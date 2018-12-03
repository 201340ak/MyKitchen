using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyKitchen.Models
{
    public class User {
        public int Id {get;set;}

        public string Email {get; set;}

        public string DisplayName {get; set;}

        public string Password {get;set;}

        public virtual ICollection<InventoryEntry> Inventory {get; set;}

        public virtual ICollection<Recipe> Recipes {get;set;}
    }
}