//Program to Get Factorial of a Given Number
using static System.Console;

WriteLine ("Enter the number to calculate factorial : ");
if (ulong.TryParse (ReadLine () ?? "", out ulong num))
   WriteLine ($"The Factorial of {num} is : " + GetFactorial (num));
else WriteLine ("Enter Valid Number");

ulong GetFactorial (ulong n) {
   if (n == 0) return 1;
   if (n <= 2) return n;
   return n * GetFactorial (n - 1);
}