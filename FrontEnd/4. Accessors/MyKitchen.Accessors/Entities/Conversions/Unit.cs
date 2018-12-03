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
            DataContracts.UnitType unitType;
            var parsed = DataContracts.UnitType.TryParse(entity.Type.ToString(), out unitType);

            return new DataContracts.Unit
            {
                Id = entity.Id,
                Name = entity.Name,
                Abbreviation = entity.Abbreviation,
                Type = parsed ? unitType : (DataContracts.UnitType?)null
            };
        }

        public static explicit operator Unit(DataContracts.Unit entity)
        {
            if (entity == null)
            {
                return null;
            }

            UnitType unitType;
            var parsed = UnitType.TryParse(entity.Type.ToString(), out unitType);

            return new Unit
            {
                Id = entity.Id,
                Name = entity.Name,
                Abbreviation = entity.Abbreviation,
                Type = parsed ? unitType : (UnitType?)null
            };
        }
   }
}