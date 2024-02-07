//Program to check Isogram
using static System.Console;

Write ("Enter a String : ");
string letter = ReadLine () ?? "";
if (letter.Length >= 1 && letter.All (char.IsLetter))
   WriteLine ("It is " + (IsIsogram (letter) ? "" : "not ") + "an Isogram");
else WriteLine ("Enter Valid Input");

bool IsIsogram (string s) {
   WriteLine ("Method - 1");
   for (int ch = 0; ch < letter.Length - 1; ch++)
      for (int ch1 = ch + 1; ch1 < letter.Length; ch1++)
         if (letter[ch] == letter[ch1])
            return false;
   return true;
}

// Using LINQ operator
WriteLine ("Method - 2");
if (letter.Length >= 1 && letter.All (char.IsLetter)) {
   if (letter.GroupBy (c => c).Any (g => g.Count () > 1)) WriteLine ("It is not an Isogram");
   else WriteLine ("It is an Isogram");
} else WriteLine ("Invalid Input");