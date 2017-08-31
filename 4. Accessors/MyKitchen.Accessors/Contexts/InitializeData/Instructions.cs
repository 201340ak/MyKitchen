using System.Collections.Generic;
using MyKitchen.Accessors.Entities;

namespace MyKitchen.Accessors.Contexts.InitializeData
{
    public static class Instructions
    {
        public static List<Instruction> All
        {
            get
            {
                var instructions = new List<Instruction>();
                instructions.AddRange(RunzaInstructions);
                return instructions;
            }
        }

        private static List<Instruction> RunzaInstructions
        {
            get
            {
                return new List<Instruction>{
                    new Instruction
                    {
                        RecipeId = 1, // Runza
                        StepNumber = 1,
                        InstructionDetails = "Ground and brown hamburger in a skillet."
                    },
                    new Instruction
                    {
                        RecipeId = 1, // Runza
                        StepNumber = 2,
                        InstructionDetails = "Mix in BBQ and chopped onion."
                    },
                    new Instruction
                    {
                        RecipeId = 1, // Runza
                        StepNumber = 3,
                        InstructionDetails = "Roll out/flatten dough in sections."
                    },
                    new Instruction
                    {
                        RecipeId = 1, // Runza
                        StepNumber = 4,
                        InstructionDetails = "Put hamburger mixture onto dough in every other section."
                    },
                    new Instruction
                    {
                        RecipeId = 1, // Runza
                        StepNumber = 5,
                        InstructionDetails = "Take unused sections and cover the ones with the hamburger mix."
                    },
                    new Instruction
                    {
                        RecipeId = 1, // Runza
                        StepNumber = 6,
                        InstructionDetails = "Cook for x amount of time at y amount of degrees."
                    },
                    new Instruction
                    {
                        RecipeId = 1, // Runza
                        StepNumber = 2,
                        InstructionDetails = "Enjoy!"
                    }
                };
            }
        }
    }
}