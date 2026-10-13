// -------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Trumpf Metamation India.
// -------------------------------------------------------------------------------------------------
// Program.cs
// Program to predict the possible spellbee words from the given letters
// -------------------------------------------------------------------------------------------------
using static System.Console;

namespace A03;

class Program {

   // Identifies valid words, calculates scores, highlights pangrams,
   // and displays the results sorted by score.
   static void Main (string[] args) {
      char[] letters = ['U', 'X', 'A', 'L', 'T', 'N', 'E'];
      var words = File.ReadAllLines ("words.txt");
      List<(string Word, int Score, bool Panagram)> eligibleWords = [];
      foreach (var word in words) {
         if (!IsValidWord (word, letters)) continue;
         var IsPangram = letters.All (word.Contains);
         eligibleWords.Add ((word, GetScore (word, IsPangram), IsPangram));
      }
      foreach (var (word, score, pangram) in eligibleWords.OrderByDescending (a => a.Score)) {
         if (pangram) ForegroundColor = ConsoleColor.Green;
         WriteLine ($"{score,2}. {word}");
         ResetColor ();
      }
      WriteLine ($"---\n{eligibleWords.Sum (x => x.Score)} total");
   }

   // Checks whether a word meets all game rules.
   // Must be 4+ letters, include the first letter, and use only allowed letters.
   static bool IsValidWord (string word, char[] letters) =>
      word.Length >= 4 && word.Contains (letters[0]) && word.All (letters.Contains);

   // Calculates the word score based on its length.
   // Four-letter words score 1 point; longer words score their length, with a 7-point pangram bonus.
   static int GetScore (string word, bool IsPangram) =>
      word.Length > 4 ? word.Length + (IsPangram ? 7 : 0) : 1;
}