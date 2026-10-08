namespace A02;

class Program {
   static void Main (string[] args) {
      Console.WriteLine ("Lets Play\nI will think an number between 1 and 100 Try to find it");
      StartGame ();
   }
   static void StartGame () {
      int val = new Random ().Next (1, 101);
      int guess = new ();
      for (; ; )
      {
         Console.Write ("Enter your guess: ");
         if (!ParseValue (Console.ReadLine ()!, out guess))
            continue;
         if (guess < val)
            Console.WriteLine ("Your Guess is too low");
         else if (guess > val)
            Console.WriteLine ("Your Guess is too high");
         else {
            Console.WriteLine ("You Guessed it right");
            break;
         }
      }
   }
   static bool ParseValue (string s, out int guess) {
      if (!int.TryParse (s, out guess)) {
         Console.WriteLine ("Invalid input");
         return false;
      }
      if (guess < 1) {
         Console.WriteLine ("Your guess is less than 1 provide an valid guess");
         return false;
      } else if (guess > 100) {
         Console.WriteLine ("Your guess is more than 100 provide an valid guess");
         return false;
      }
      return true;
   }
}
