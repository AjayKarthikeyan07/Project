//Pascal's Triangle
using static System.Console;
Write ("Enter number of rows : ");
if (int.TryParse (ReadLine () ?? "", out int row)) {
   int val = 1;
   WriteLine ("Pascal's triangle");
   for (int i = 0; i < row; i++) {
      for (int blank = 1; blank <= row - i; blank++)
         Write (" ");
      for (int j = 0; j <= i; j++) {
         if (j == 0 || i == 0 || j == i)
            val = 1;
         else
            val = val * (i - j + 1) / j;
         Write (val + " ");
      }
      WriteLine ();
   }
} else WriteLine ("Enter Valid Number");