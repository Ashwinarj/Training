// -------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Trumpf Metamation India.
// -------------------------------------------------------------------------------------------------
// Program.cs
// Program to play guessing game with the user. Try to find the number guess by the user
// -------------------------------------------------------------------------------------------------

using static System.Console;

namespace A02._1;

class Program {
   static void Main (string[] args) => Play ();

   // Play Function executes the Guess Game
   static void Play () {
      WriteLine ("Think an number between 1 and 127\nI will try to guess it!!!");
      WriteLine ("Provide (Y)es or (N)o for the following questions");
      int guessNum = 0;
      for (int position = 0, divisor = 2; divisor <= 128; position++, divisor *= 2) {
         if (!UserResponse ($"Is your number divided by {divisor} gives remainder {guessNum}? "))
            guessNum |= (1 << position);
      }
      WriteLine ($"Your Guess is {guessNum}");
   }

   // UserResponse Function used to get Yes/No input from user
   static bool UserResponse (string prompt) {
      for (; ; ) {
         Write (prompt);
         switch (Console.ReadKey (true).Key) {
            case ConsoleKey.Y: WriteLine ("Yes"); return true;
            case ConsoleKey.N: WriteLine ("No"); return false;
            default: WriteLine ("Invalid input! Press Y for Yes and N for No"); break;
         }
      }
   }
}
