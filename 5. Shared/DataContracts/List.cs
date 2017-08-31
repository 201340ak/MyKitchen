using System.Collections.Generic;

namespace MyKitchen.DataContracts
{
    public class List
    {
        public int Id { get; set; }

        public virtual ICollection<Food> Foods { get; set;}
    }
}