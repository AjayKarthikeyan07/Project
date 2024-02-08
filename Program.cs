//This program is spelling bee game
using static System.Console;
//Importing the words.txt file  
string filepath = "C:/etc/words.txt";
if (File.Exists (filepath)) {
   string[] words = File.ReadAllLines (filepath);
   char[] letters = new[] { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
   int total = 0;
   // USing LINQ operators to filter and order the words 
   foreach (var data in words.Where (IsValid)
                            .Select (GetScore)
                            .OrderByDescending (a => a.score)
                            .ThenBy (a => a.word)) {
      if (data.pangram) ForegroundColor = ConsoleColor.Green;
      WriteLine ($"{data.score,4} {data.word}");
      ResetColor ();
      total += data.score;
   }
   WriteLine ("-----");
   WriteLine ($"{total,4}    Total");

   //Method to chgeck if the word is valid
   bool IsValid (string word) => word.Length >= 4 && word.Contains (letters[0]) && word.All (letters.Contains);

   //Method for checking pangram and get score
   (string word, int score, bool pangram) GetScore (String word) {
      bool pangram = letters.All (word.Contains);
      int score = (word.Length > 4 ? word.Length : 1) + (pangram ? 7 : 0);
      return (word, score, pangram);
   }
} else WriteLine ("File does not exist in the specified location");