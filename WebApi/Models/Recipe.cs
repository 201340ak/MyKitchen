using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace MyKitchen.Models
{
    public class Recipe
    {
        public int Id {get;set;}

        public string Name {get;set;}

        public int UserId {get;set;}

        public virtual User User {get;set;}

        [NotMapped] // For Now
        public List<string> MediaContent {get;set;} // Will be videos and images

        public virtual ICollection<Ingredient> Ingredients {get;set;}
    }
}