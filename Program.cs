//Diamond Pattern
using static System.Console;
Write ("Enter the height of the pattern : ");
if (int.TryParse (Console.ReadLine () ?? "", out int height)) {
   for (int i = 0; i <= height; i++) {
      for (int blank = 0; blank < height - i; blank++)
         Write (" ");
      for (int j = 1; j <= (2 * i) - 1; j++)
         Write ("*");
      WriteLine ();
   }
   for (int i = height - 1; i > 0; i--) {
      for (int blank = 0; blank < height - i; blank++)
         Write (" ");
      for (int j = 1; j <= (2 * i) - 1; j++)
         Write ("*");
      WriteLine ();
   }
} else WriteLine ("Enter valid Number");