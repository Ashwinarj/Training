// -------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Trumpf Metamation India.
// -------------------------------------------------------------------------------------------------
// Program.cs
// Program to play guessing game with the user. Program thinks of an number user need to find it in 7 tries
// -------------------------------------------------------------------------------------------------

namespace A02;

class GuessingGame {
   static void Main (string[] args) {
      Play ();
   }

   // Starts the game where it will guess an number between 1 and 100 and checks with users guess
   static void Play () {
      Console.WriteLine ("Lets play\nI will think a number between 1 and 100, try to find within 7 guesses");
      int rndNum = new Random ().Next (1, 101);
      for (int i = 0; i < 7; i++) {
         Console.Write ("Enter your guess: ");
         if (!int.TryParse (Console.ReadLine ()!, out int guessNum) || guessNum is < 1 or > 100) {
            Console.WriteLine ("Invalid Input");
            continue;
         }
         if (guessNum == rndNum) {
            Console.WriteLine ("You Guessed it right!!!");
            return;
         }
         Console.WriteLine ($"Your Guess is too {(guessNum > rndNum ? "high" : "low")}");
      }
      Console.WriteLine ("Game Over!!!");
   }
}
