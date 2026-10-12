//// ----------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Trumpf Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Number-guessing game where the user tries to guess the program's number within 7 attempts
// ------------------------------------------------------------------------------------------------

using static System.Console;

namespace A02;

class GuessingGame {
   static void Main (string[] args) {
      Play ();
   }

   // Starts a number-guessing game and checks the user's guesses against the target number.
   static void Play () {
      PrintMsg ("Let's play\n" +
               "I will think of a number between 1 and 100, guess it within 7 guesses\n",
               ConsoleColor.Cyan);
      int rndNum = new Random ().Next (1, 101);
      for (int i = 0; i < 7; i++) {
         Write ("Enter your guess: ");
         if (!int.TryParse (Console.ReadLine (), out int guessNum) || guessNum is < 1 or > 100) {
            PrintMsg ("Invalid Input\n", ConsoleColor.Yellow);
            continue;
         }
         if (guessNum == rndNum) {
            PrintMsg ("You Guessed it right!!!", ConsoleColor.Green);
            return;
         }
         PrintMsg ($"Your Guess is too {(guessNum > rndNum ? "high" : "low")}\n",
                  ConsoleColor.Blue);
      }
      PrintMsg ("Game Over!!!", ConsoleColor.Red);

      // Display a message in custom console color.
      static void PrintMsg (string prompt, ConsoleColor consoleColor = ConsoleColor.Gray) {
         ForegroundColor = consoleColor;
         WriteLine (prompt);
         ResetColor ();
      }
   }
}
