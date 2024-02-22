using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continuous, and the totals and other statistics could be summarised for example.
         */

        // A variable, holding an array of three dice, which are used in the game.
        // Since the number of dice is constant, the array can be made readonly.
        private readonly Die[] _dice = {
            new Die(),
            new Die(),
            new Die()
        };

        /// <summary>
        /// Rolls all the dice in the Game class.
        /// </summary>
        /// <returns>The results of all of the dice, rolled.</returns>
        public IEnumerable<int> RollAllDice() => 
            // Roll each of the dice in the class, concatenating their results into an enumerable.
            _dice.Select(dice => dice.Roll());

        /// <summary>
        /// Returns the total of all the current die values.
        /// </summary>
        /// <returns>The total sum of all current die values.</returns>
        public int SumAllDice() => _dice.Sum(die => die.CurrentValue);

        /// <summary>
        /// Prints dice roll results to the console.
        /// </summary>
        /// <param name="diceRolls">The current values of each dice being displayed.</param>
        private void ReportDiceRolls(IEnumerable<int> diceRolls)
        {
            /*
             * The parameter for ReportDiceRolls is the generic type IEnumerable.
             * To work with the data, it needs converting to an array.
             */
            var diceRollArray = diceRolls.ToArray();
            
            // An integer is defined to hold the sum of dice rolls in.
            // Note: the SumAllDice method is not used for interoperability reasons.
            var diceRollSum = 0;
            
            // Iterate through every dice roll in the array
            for (var diceIndex = 0; diceIndex < diceRollArray.Length; diceIndex++)
            {
                // Get the dice roll from the array
                var roll = diceRollArray[diceIndex];
                
                // Add the dice roll to the total sum
                diceRollSum += roll;
                
                // Print the dice roll to the console
                Console.WriteLine($"Dice roll {diceIndex + 1}: {roll}");
            }
            
            // Print a blank line to the console
            Console.WriteLine();
            
            // Print the sum of all rolls to the console
            Console.WriteLine($"Sum of dice rolls: {diceRollSum}");
        }

        /// <summary>
        /// Rolls all dice in the Game class and then outputs their new values to the console.
        /// </summary>
        public void RollDiceAndPrintValues()
        {
            // Roll all dice in the Game class, getting their new values
            var diceRolls = RollAllDice();
            
            // Output these new values to the console
            ReportDiceRolls(diceRolls);
        }

        /// <summary>
        /// Rolls all dice and prints their values until the user inputs anything but 'y'
        /// </summary>
        public void RollDiceContinuously()
        {
            // Until further notice,
            while (true)
            {
                // Roll all Dice in the game class and print their new values.
                RollDiceAndPrintValues();
                
                // Print a blank line, followed by a prompt on what to do next.
                Console.WriteLine();
                Console.WriteLine("Would you like to roll again?");
                Console.WriteLine("Press 'y' to roll again, or anything else to quit.");

                // Get the keypress from the end-user
                var keyPress = Console.ReadKey();
                
                // If the user inputs 'Y' (in case of Caps-Lock) or 'y', break out of the function.
                if(keyPress.KeyChar.ToString().ToLower() != "y") return;
                
                // Else, clear the console and repeat the loop.
                Console.Clear();
            }
        }
        
    }
}
