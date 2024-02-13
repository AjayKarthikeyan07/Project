// ----------------------------------------------------------------------------------------
// Program.cs
// Anagram
// To find anagrams from the given text file
// ----------------------------------------------------------------------------------------

using static System.Console;

internal class Program {
   private static void Main (string[] args) {
      using (var stream = new StreamWriter ("D:/work/Anagrams.txt"))
         // Sort each word in alphabetical order and group them
         File.ReadAllLines ("D:/work/words.txt")
             .GroupBy (word => string.Concat (word.OrderBy (ch => ch)))
             .Where (word => word.Count () > 1)
             .OrderByDescending (word => word.Count ())
             // Transform the word into required format
             .Select (word => $"{word.Count ()} {string.Join (", ", word)}")
             .ToList ()
             // Writing the output to console and file
             .ForEach (word => { WriteLine (word); stream.WriteLine (word); });
   }
}

