// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2026.
// Copyright (c) Trumpf Metamation India.
// ------------------------------------------------------------------------------------------------
// Program.cs
// Reads the word file and create a frequency table of the characters
// ------------------------------------------------------------------------------------------------

using static System.Console;

namespace A04;

class Program {
   static void Main (string[] args) {
      var words = File.ReadAllLines ("words.txt");
      var freqTable = words.SelectMany (word => word).GroupBy (x => x)
         .ToDictionary (g => g.Key, g => g.Count ());
      foreach (var (letter, count) in freqTable.OrderByDescending (x => x.Value).Take (7)) {
         WriteLine ($"{letter} : {count}");
      }
   }
}
