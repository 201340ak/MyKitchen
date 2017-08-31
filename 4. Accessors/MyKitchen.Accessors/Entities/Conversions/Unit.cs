namespace MyKitchen.Accessors.Entities
{
   using System;

   public partial class Unit
   {       
        public static explicit operator DataContracts.Unit(Unit entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new DataContracts.Unit
            {
                Name = entity.Name
            };
        }

        public static explicit operator Unit(DataContracts.Unit entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Unit
            {
                Name = entity.Name
            };
        }
   }
}