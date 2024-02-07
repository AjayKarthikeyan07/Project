//Program to remove Adjacent duplicate character
using static System.Console;
Write ("Enter a String : ");
string letter = ReadLine () ?? "";
for (int ch = 0; ch < letter.Length - 1; ch++)
   for (int ch1 = ch + 1; ch1 < letter.Length;) {
      if (letter[ch] == letter[ch1])
         letter = letter.Remove (ch, 2);
      else break;
   }
WriteLine ($"Modified String : {letter} ");