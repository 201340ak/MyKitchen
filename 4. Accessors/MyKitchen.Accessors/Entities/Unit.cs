using System.ComponentModel.DataAnnotations.Schema;

namespace MyKitchen.Accessors.Entities
{
    public partial class Unit
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}