// Numbers to words or roman numbers

using static System.Console;

var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter a Number between 0 and 3999 : ");
if (!int.TryParse (ReadLine (), out int num) || num < 0 || num > 3999) {
   WriteLine ("Enter valid number");
   continue;
}
Write ("Do you want to convert it into (W)ords or (R)oman Numbers ?  ");
var choice = ReadKey ().Key;
WriteLine ();
if (choice == ConsoleKey.W) NumToWords (num);
else if (choice == ConsoleKey.R) NumToRomans (num);
else WriteLine ("Enter a valid key");
WriteLine ("\nDo you want to convert again (Y)es or (N)o ? ");
key = ReadKey ().Key;
WriteLine ();
}

// Method to convert numbers to words using dictionary
void NumToWords (int num) {
   Dictionary<int, string> words = new () {
      [1] = "One", [2] = "Two", [3] = "Three", [4] = "Four",
      [5] = "Five", [6] = "Six", [7] = "Seven", [8] = "Eight", [9] = "Nine", [10] = "Ten", [11] = "Eleven",
      [12] = "Twelve", [13] = "Thirteen", [14] = "Fourteen", [15] = "Fifteen", [16] = "Sixteen", [17] = "Seventeen",
      [18] = "Eighteen", [19] = "Nineteen", [20] = "Twenty", [30] = "Thirty", [40] = "Fourty", [50] = "Fifty",
      [60] = "Sixty", [70] = "Seventy", [80] = "Eighty", [90] = "Ninety", [300] = " Hundred ", [4000] = " Thousand "
   };
   string result = "";
   if (num == 0) {
      WriteLine ("Zero");
      return;
   }
   while (num != 0) {
      int len = num.ToString ().Length;
      int divisor;
      if (len == 1 || (len == 2 && num <= 20)) {
         result += words[num];
         break;
      } else if (len == 2 && num > 20) divisor = 1;
      else divisor = (int)Math.Pow (10, len - 1);
      int quo = num / divisor;
      var unitDigit = quo % 10;
      var formattedQuo = quo.ToString ().Length == 2 && quo > 20 ? words[quo - unitDigit] + " " + words[unitDigit] : words[quo];
      var placeValue = len >= 3 ? words[len * ((int)Math.Pow (10, len - 1))] : "";
      var connector = len == 3 && num % 100 != 0 ? "and " : "";
      result += formattedQuo + placeValue + connector;
      num %= divisor;
   }
   Write ($"{result}");
}

// Method to convert numbers to roman numbers using dictionary
void NumToRomans (int num) {
   string[] romans = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
   int[] numbers = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
   string result = "";
   if (num == 0) {
      WriteLine ("No Roman Number representation for 0");
      return;
   }
   while (num > 0) {
      for (int i = numbers.Length - 1; i >= 0; i--)
         if (num >= numbers[i]) {
            result += romans[i];
            num -= numbers[i];
            i++;
         }
   }
   Write (result);
}