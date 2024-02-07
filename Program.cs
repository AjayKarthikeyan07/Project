// Integral and Fractional Part

using static System.Console;

var integralList = new List<int> ();
var fractionalList = new List<int> ();
Write ("Enter a Number : ");
string decimalNum = ReadLine () ?? "";
if (decimal.TryParse (decimalNum, out decimal Num)) {
   string[] decimalArr = decimalNum.Split ('.');
   Write ("The Integral part is : ");
   PrintIntListFromInt (decimalArr[0]);
   if (decimalNum.Contains ('.')) {
      Write ("The Fractional part is : ");
      PrintFracListFromFrac (decimalArr[1]);
   } else WriteLine ("No Fractional Part");
} else WriteLine ("Enter Valid Number");

void PrintIntListFromInt (string integer) {
   int.TryParse (integer, out int integralNum);
   if (integralNum == 0) foreach (var ch in integer) Write (ch + " ");
   while (integralNum != 0) {
      integralList.Add (integralNum % 10);
      integralNum /= 10;
   }
   integralList.Reverse ();
   integralList.ForEach (x => Write (x + " "));
   WriteLine ();
}
void PrintFracListFromFrac (string fraction) {
   int.TryParse (fraction, out int fractionalNum);
   while (fractionalNum != 0) {
      fractionalList.Add (fractionalNum % 10);
      fractionalNum /= 10;
   }
   var diff = fraction.Length - fractionalList.Count;
   if (diff > 0)
      for (int i = 0; i < diff; i++)
         fractionalList.Add (0);
   fractionalList.Reverse ();
   fractionalList.ForEach (x => Write (x + " "));
}