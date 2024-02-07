//Program to Swap 2 Numbers
using static System.Console;

WriteLine ("Enter the 2 numbers");
if (!int.TryParse (ReadLine (), out int num1) || !int.TryParse (ReadLine (), out int num2))
   WriteLine ("Enter Valid Number");
else {
   WriteLine ($"Original Numbers : num1 = {num1} num2 = {num2}");
   PrintSwap (num1, num2);
}

void PrintSwap (int a, int b) {
   (a, b) = (b, a);
   WriteLine ($"Swapped Numbers  : num1 = {a} num2 = {b}");
}