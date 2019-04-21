/* The Recursive Staircase Problem
 * 
 * This is problem is a common coding interview question. The goal is the find the total amount of
 * routes a person can take up a staircase. For example, let's say we have a staircase with 3 steps,
 * and you're only allowed to either take 1 or 2 steps at a time. There are three solutions here.
 * 1. Only using 1 step. 1 + 1 + 1 = 3.
 * 2. Start with 2 step. 2 + 1 = 3.
 * 3. End with 2 step. 1 + 2 = 3.
 * There is no other distinct combination that reaches the third step.
 * My algorithm uses recursion to find all possible routes. You can theoretically give it any number 
 * of steps and allowed step sizes, but the numbers will quickly get too large for an average computer to compute. 
*/

using System;

namespace StaircaseProblem
{
    class Program
    {
        // This will equal the total amount of solutions when the program has finished running
        long solutions = 0;

        // Total amount of steps in staircase
        int stairCaseSize = 3;

        // Each step can be as large as any of the numbers in this array
        int[] stepSizes = new int[] { 1, 2 };

        static void Main(string[] args)
        {
            // Initialisation
            Program program = new Program();

            // Start the problem
            program.StartProblem(program.stairCaseSize, program.stepSizes);

            // Print result
            Console.WriteLine("Total steps: " + program.stairCaseSize);
            Console.WriteLine("Allowed step sizes: " + program.GenerateStepSizesString());
            Console.WriteLine("Solutions found: " + program.solutions);
            Console.ReadLine();
        }

        // This function will start the computation. It takes in the total amount of steps in the staircase, and
        // an integer array for how large each step can be. The function will run DoStep() using each stepsize. 
        void StartProblem(int steps, int[] stepSizes)
        {
            foreach (int i in stepSizes)
            {
               DoStep(steps, i, 0, stepSizes);
            }
        }

        // DoStep() is the main recursive algorithm. It takes in the total amount of steps in the staircase, one step size,
        // a position (which step this branch of the recursive algorithm is on) and all the other stepSizes.
        void DoStep(int steps, int stepSize, int position, int[] stepSizes)
        {
            // It begins by adding a step to it's position.
            position += stepSize;
            // If the position is exactly equal to the total amount of steps in the staircase, we have found a solution.
            if(position == steps)
            {
                solutions++;
                return;
            }
            // If the position is above the top step, end the recursion.
            if(position > steps)
            {
                return;
            }
            // Recursively run this function from this position using all the different step sizes. Each of those
            // will again run every step size from their position. This is how we cover every single route possible.
            foreach (int i in stepSizes)
            {
                DoStep(steps, i, position, stepSizes);
            }
        }

        // This function is only used to display which step sizes were used in the algorithm. It's 
        // not a part of the solution.
        string GenerateStepSizesString()
        {
            string stepSizesString = "";

            for (int i = 0; i < stepSizes.Length; i++)
            {
                if (i == 0) { stepSizesString += stepSizes[i]; }
                else if (i == stepSizes.Length - 1) { stepSizesString += " and " + stepSizes[i]; }
                else { stepSizesString += ", " + stepSizes[i]; }
            }

            return stepSizesString;
        }

    }
}
