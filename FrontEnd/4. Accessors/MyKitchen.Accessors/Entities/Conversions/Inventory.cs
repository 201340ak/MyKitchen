using System.Linq;

namespace MyKitchen.Accessors.Entities
{
    public partial class Inventory : List
    {
        public static explicit operator DataContracts.Inventory(Inventory entity)
        {
            if(entity == null)
            {
                return null;
            }

            return new DataContracts.Inventory
            {
                Id = entity.Id,
                Foods = entity.Foods?
                    .Select(r => (DataContracts.Food)r)
                    .ToList()
            };
        }

        public static explicit operator Inventory(DataContracts.Inventory entity)
        {
            if(entity == null)
            {
                return null;
            }

            return new Inventory
            {
                Id = entity.Id,
                Foods = entity.Foods?
                    .Select(r => (Food)r)
                    .ToList()
            };
        }
    }
}