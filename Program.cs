using static System.Console;
var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter number of terms for fibonacci series : ");
   if (int.TryParse (ReadLine (), out int limit) && limit > 0)
      Getfibonacci (limit);
   else if (limit == 0 || limit < 0) WriteLine ("Insufficient terms for fibinocci series");
   Write ("Do you want to get Fibonacci for Another Number (Y)es or (N)o : ");
   key = ReadKey ().Key;
   WriteLine ();
}
void Getfibonacci (int limit) {
   int num1 = 0, num2 = 1, next, count = 2;
   if (limit == 1) Write ($"{num1}");
   else Write ($"{num1} {num2} ");
   while (count < limit) {
      next = num1 + num2;
      (num1, num2) = (num2, next);
      Write ($"{next} ");
      count++;
   }
   WriteLine ();
}