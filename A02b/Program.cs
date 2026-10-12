// -------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Trumpf Metamation India.
// -------------------------------------------------------------------------------------------------
// Program.cs
// Program to play guessing game with the user. Try to find the number guess by the user
// -------------------------------------------------------------------------------------------------

namespace A02b;

class GuessGame {
   enum Response { Yes, No }
   static void Main (string[] args) {
      Play ();
   }

   // Play Function executes the Guess Game
   static void Play () {
      Console.WriteLine ("Think an number between 1 and 127\nI will try to guess it!!!");
      Console.WriteLine ("Provide (Y)es or (N)o for the following questions");
      int guessNum = 0;
      for (int position = 0, divisor = 2; divisor <= 128; position++, divisor *= 2) {
         Console.Write ($"Is your number divided by {divisor} gives remainder {guessNum}? ");
         if (UserResponse () is Response.No)
            guessNum |= (1 << position);
      }
      Console.WriteLine ($"Your Guess is {guessNum}");
   }

   // UserResponse Function used to get Yes/No input from user
   static Response UserResponse () {
      for (; ; ) {
         switch (Console.ReadKey (true).Key) {
            case ConsoleKey.Y: Console.WriteLine ("Yes"); return Response.Yes;
            case ConsoleKey.N: Console.WriteLine ("No"); return Response.No;
         }
      }
   }
}
