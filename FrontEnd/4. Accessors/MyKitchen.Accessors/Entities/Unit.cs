using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MyKitchen.Accessors.Entities
{
    public partial class Unit
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public UnitType? Type { get; set; }

        public virtual ICollection<AcceptableUnit> Foods { get; set; }
    }
}