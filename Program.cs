// Sort and swap special character
// Given a character array A, along with special character S and sort order O (default order is Ascending),
// print the sorted array by keeping the elements matching S to the last of the array. 
// SAMPLE INPUT : ([a, b, c, a, c, b, d], a, “descending”)      SAMPLE OUTPUT : “d, c, c, b, b, a, a” 

using static System.Console;

Write ("Enter the character array : ");
var chArr = ReadLine ().ToCharArray () ;
Write ("Enter the Special Character : ");
var splCh = char.ToLower (ReadKey ().KeyChar);
Write ("\nEnter the order of sorting (D)escending or (O) for Optional Parameter (Ascending) : ");
var sortOrder = char.ToLower (ReadKey ().KeyChar);

if (chArr.Length > 0 && chArr.All (char.IsLetter) && char.IsLetter (splCh) && (sortOrder == 'd' || sortOrder == 'o')) {
   WriteLine ("\nThe Final Array is : ");
   var result = sortOrder == 'o' ? GetSortArray (chArr, splCh) : GetSortArray (chArr, splCh, sort: sortOrder);
   foreach (var ch in result) { Write (ch + " "); }
} else WriteLine ("\nEnter Valid Input");

/// <summary>GetSortArray : Given a character array A, along with special character S and sort order O (default order is Ascending)</summary>
/// <summary>Print the sorted array by keeping the elements matching S to the last of the array</summary>
/// <param name="charr">It is the character array</param>
/// <param name="splch">It is the spl character</param>
/// <param name="sort">It is the sorting order</param>

char[] GetSortArray (in char[] charr, char splch, char sort = 'a') {
   var SortArr = charr.Where (c => c != splch);
   SortArr = (sort == 'a') ? SortArr.Order () : SortArr.OrderDescending ();
   return charr.Any (x => x == splch) ? SortArr.Concat (charr.Where (c => c == splch)).ToArray () : SortArr.ToArray ();
}