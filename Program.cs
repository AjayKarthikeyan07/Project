using static System.Console;
var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   WriteLine ("Enter Two Non zero numbers : ");
   if (int.TryParse (ReadLine (), out int num1) && int.TryParse (ReadLine (), out int num2) && num1 != 0 && num2 != 0) {
      (num1, num2) = (Math.Abs (num1), Math.Abs (num2));
      Write ("Do you want to convert it into (L)CM or (G)CD ?  ");
      switch (ReadKey ().Key) {
         case ConsoleKey.L:
            WriteLine ();
            WriteLine ("LCM : " + Getlcm (num1, num2));
            break;
         case ConsoleKey.G:
            WriteLine ();
            WriteLine ("GCD : " + Getgcd (num1, num2));
            break;
         default:
            WriteLine ("Enter a valid key");
            break;
      }
      WriteLine ("Do you want to convert again (Y)es or (N)o ? ");
      key = ReadKey ().Key;
      WriteLine ();

   } else WriteLine ("Enter Valid Input (NON ZERO NUMBERS)");
}
int Getlcm (int num1, int num2) => ((num1 * num2) / Getgcd (num1, num2));
int Getgcd (int num1, int num2) {
   int gcd = 0;
   if (num1 > num2) {
      if (!(num1 % num2 == 0))
         (num1, num2) = (num2, num1 % num2);
      gcd = num2;
   } else {
      if (!(num2 % num1 == 0))
         (num2, num1) = (num1, num2 % num1);
      gcd = num1;
   }
   return gcd;
}