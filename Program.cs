using static System.Console;
Write ("Enter a number : ");
int count = 0;
if (int.TryParse (ReadLine (), out int num)) {
   if (num == 1) WriteLine ("1 is neither prime nor composite");
   else {
      for (int i = 2; i <= num / 2; i++)
         if (num % i == 0) {
            count++;
            break;
         }
      WriteLine ("It is a " + (count == 0 ? "Prime Number" : "not a Prime Number"));
   }
} else WriteLine ("Enter Valid Number");