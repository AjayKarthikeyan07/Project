//Program to check palindrome
using static System.Console;
Write ("Enter a string : ");
var word = (ReadLine () ?? "").ToLower ().Replace (" ", "");
if (word.Length != 0 && word.All (char.IsLetter)) {
   var result = "It is a Palindrome";
   for (int i = 0; i <= word.Length / 2 - 1; i++)
      if (word[i] != word[word.Length - 1 - i]) {
         result = "It is not a Palindrome";
         break;
      }
   WriteLine (result);
} else WriteLine ("Enter valid input");