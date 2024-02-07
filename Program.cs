// ABECEDARIAN WORD
using static System.Console;

WriteLine ("Enter how many words do you want to give");
if (int.TryParse (ReadLine (), out int size) && size > 0)
   GetAbecedarian (size);
else WriteLine ("Enter Valid Input");

void GetAbecedarian (int size) {
   var words = new string[size];
   for (int index = 0; index < words.Length; index++) {
      WriteLine ($"Enter Word {index + 1} : ");
      words[index] = ReadLine () ?? "";
      if (words[index].Length < 1 || !words[index].All (char.IsLetter)) {
         WriteLine ("Invalid Input");
         index--;
      }
   }
   WriteLine ($"The Longest ABECEDARIAN Word is : {words.Where (word => word == string.Join ("", word.OrderBy (c => c)))
                                                        .OrderByDescending (x => x.Length).FirstOrDefault () ?? ""}");
}