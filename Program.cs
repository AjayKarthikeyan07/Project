//Program to get all possible permutations of a string
using static System.Console;

string answer = "";
Write ("Enter the string : ");
int count = 0;
string word = ReadLine () ?? "";
List<string> permuteWords = new List<string> ();
if (word.Length > 0 && word.All (char.IsLetter)) {
   PrintPermute (word, answer);
   Write ($"\nTotal Possible Permutations are {count} : \n");
   foreach (var permute in permuteWords)
      WriteLine (permute);
} else WriteLine ("Enter Valid Input");

void PrintPermute (string word, string answer) {
   if (word.Length == 0) {
      count++;
      permuteWords.Add (answer);
      return;
   }
   for (int i = 0; i < word.Length; i++)
      PrintPermute (word[..i] + word[(i + 1)..], answer + word[i]);
}