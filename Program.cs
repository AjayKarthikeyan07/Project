using static System.Console;

var key = ConsoleKey.Y;
while (key == ConsoleKey.Y) {
   Write ("Enter a Number : ");
   if (int.TryParse (Console.ReadLine (), out int num)) {
      Write ("Do you want to convert it into (B)inary or (H)exadecimal ?  ");
      switch (Console.ReadKey ().Key) {
         case ConsoleKey.B:
            WriteLine ();
            WriteLine ($"The Right Answer is : {Convert.ToString (num, 2)}");
            Getbinary (num);
            break;
         case ConsoleKey.H:
            WriteLine ();
            WriteLine ($"The Right Answer is : {num:X}");
            Gethexadecimal (num);
            break;
         default:
            WriteLine ("Enter a valid key");
            break;
      }
      WriteLine ("Do you want to convert again (Y)es or (N)o ? ");
      key = ReadKey ().Key;
      WriteLine ();
   }
}

void Getbinary (int num) {
   string result = "";
   while (num != 0) {
      result += (num % 2).ToString ();
      num = num / 2;
   }
   WriteLine ("The Binary number Obtained is : " + String.Join ("", result.Reverse ()));
}

void Gethexadecimal (int num) {
   string[] hexa = { "A", "B", "C", "D", "E", "F" };
   string result = "";
   while (num != 0) {
      if (num % 16 < 10) {
         result += (num % 16).ToString ();
         num = num / 16;
      }
      if (num % 16 >= 10 && num % 16 <= 16) {
         result += (hexa[(num % 16) % 10]).ToString ();
         num = num / 16;
      }
   }
   WriteLine ("The Hexadecimal number Obtained is : " + String.Join ("", result.Reverse ()));
}