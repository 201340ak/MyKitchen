using System.ComponentModel.DataAnnotations.Schema;

namespace MyKitchen.Accessors.Entities
{
    public partial class Instruction 
    {        
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StepNumber { get; set; }

        public string InstructionDetails { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}