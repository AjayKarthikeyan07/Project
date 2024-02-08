//This Program makes the computer guess what number we think.
using static System.Console;
ForegroundColor = ConsoleColor.Cyan;
int lowLimit = 0, highLimit = 100, baseLimit = (lowLimit + highLimit) / 2;
//Setting lowlimit,highlimit and mid range
WriteLine ("Heyy user think of a number between 1 to 100" + '\n' + "The computer will guess it ");
ResetColor ();
for (int tries = 1; tries <= 7; tries++) {
   Write ($"Is the number greater than {baseLimit} (Y)es / (N)o ?  ");
   switch (ReadKey ().Key) {
      case ConsoleKey.Y:
         lowLimit = baseLimit;
         break;
      case ConsoleKey.N:
         highLimit = baseLimit;
         break;
      default:
         WriteLine ("Enter valid number");
         break;
   }
   //Reducing range after each iteration
   baseLimit = (lowLimit + highLimit) / 2;
   WriteLine ();
}
//Printing the guess
WriteLine ();
ForegroundColor = ConsoleColor.Green;
WriteLine ($"The secret number is  {highLimit} ");
ResetColor ();