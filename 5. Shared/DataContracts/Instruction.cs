using System.ComponentModel.DataAnnotations.Schema;

namespace MyKitchen.DataContracts
{
    public class Instruction 
    {        
       [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StepNumber { get; set; }

        public string InstructionDetails { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}