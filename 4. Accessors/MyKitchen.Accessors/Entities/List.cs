using System.Collections.Generic;

namespace MyKitchen.Accessors.Entities
{
    public abstract class List
    {
        public int Id { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}