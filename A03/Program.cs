// -------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Trumpf Metamation India.
// -------------------------------------------------------------------------------------------------
// Program.cs
// Program to predict the possible spellbee words from the given letters
// -------------------------------------------------------------------------------------------------

using System.Globalization;

namespace A03;

class SpellBeePredictor {
   //struct Spellbee store the word, score and wheather it is a panagram
   struct SpellBeeWord {
      public string word;
      public int score;
      public bool panagram = false;
      public SpellBeeWord (string word, char[] letters) {
         this.word = word;
         this.score = word.Length > 4 ? word.Length : 1;
         if (IsPanagram (word, letters)) {
            panagram = true;
            score += 7;
         }
      }
      bool IsPanagram (string word, char[] letters) {
         foreach (var ch in letters) {
            if (!word.Contains (ch)) return false;
         }
         return true;
      }
   }
   static void Main (string[] args) {
      char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
      string[] words = File.ReadAllLines ("..\\..\\..\\words.txt");
      List<SpellBeeWord> eligibleWords = new List<SpellBeeWord> ();
      for (int i = 0; i < words.Length; i++) {
         words[i] = words[i].ToUpper ();
         if (IsValidSpellBeeWord (words[i], letters)) continue;
         eligibleWords.Add (new SpellBeeWord (words[i], letters));
      }
      eligibleWords = ArrangeWordByScore (eligibleWords);
      for (int i = 0; i < eligibleWords.Count; i++) {
         if (eligibleWords[i].panagram) Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine ($"{eligibleWords[i].score,2}. {eligibleWords[i].word}");
         Console.ResetColor ();
      }
   }

   //Check wheather the word is a valid spellbee word
   static bool IsValidSpellBeeWord (string word, char[] letters) => word.Length < 4 || !word.Contains (letters[0]) || !ContainsLetters (letters, word);

   //Arrange the spellbee word in descending order based on the score
   static List<SpellBeeWord> ArrangeWordByScore (List<SpellBeeWord> words) {
      for (int i = 0; i < words.Count; i++) {
         for (int j = i + 1; j < words.Count; j++) {
            if (words[i].score < words[j].score) {
               (words[i], words[j]) = (words[j], words[i]);
            }
            if (words[i].score == words[j].score) {
               if (words[i].word.CompareTo (words[j].word) > 0) {
                  (words[i], words[j]) = (words[j], words[i]);
               }
            }
         }
      }
      return words;
   }

   //Checks wheather the word contains only the allowed letters
   static bool ContainsLetters (char[] letters, string word) {
      foreach (var ch in word) {
         if (!letters.Contains (ch)) return false;
      }
      return true;
   }
}