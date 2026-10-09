// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026. 
// Copyright (c) Metamation India. 
// -------------------------------------------------------------------------------------------------
// Program.cs 
// Program to find anagrams of all words in words.txt and store them in a file in a given format.

namespace A02;

class Program {
   static void Main (string[] args) {
      Console.WriteLine ("Lets Play\nI will think a number between 1 and 100, try to find within 7 guesses"); 
      Play ();
   }

   // Starts the game where it will guess an number between 1 and 100 and checks with users guess
   static void Play () {
      int val = new Random ().Next (1, 101), guess;

      for (int i = 0; i < 7; i++) {
         Console.Write ("Enter your guess: ");
         if(!int.TryParse(Console.ReadLine()!, out guess)) {
            Console.WriteLine ("Invalid Input");
            continue;
         }
         if (guess == val) {
            Console.WriteLine ("You Guessed it right!!!");
            return;
         }
         Console.WriteLine(guess > val ? "Your Guess is too high" : "Your Guess is too low");
      }
      Console.WriteLine ("Game Over!!!");
   }
}
