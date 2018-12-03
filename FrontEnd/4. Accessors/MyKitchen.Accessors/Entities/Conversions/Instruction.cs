namespace MyKitchen.Accessors.Entities
{
    public partial class Instruction
    {
        public static explicit operator DataContracts.Instruction(Instruction entity)
        {
            if(entity == null)
            {
                return null;
            }

            if(entity.Recipe?.Ingredients != null)
            {
                entity.Recipe.Ingredients = null;
            }

            return new DataContracts.Instruction
            {
                Id = entity.Id,
                RecipeId = entity.RecipeId,
                Recipe = (DataContracts.Recipe)entity.Recipe,
                StepNumber = entity.StepNumber,
                InstructionDetails = entity.InstructionDetails
            };
        }

        public static explicit operator Instruction(DataContracts.Instruction entity)
        {
            if(entity == null)
            {
                return null;
            }

            if(entity.Recipe?.Ingredients != null)
            {
                entity.Recipe.Ingredients = null;
            }

            return new Instruction
            {
                Id = entity.Id,
                RecipeId = entity.RecipeId,
                Recipe = (Recipe)entity.Recipe,
                StepNumber = entity.StepNumber,
                InstructionDetails = entity.InstructionDetails
            };
        }
    }
}