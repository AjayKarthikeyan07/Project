//Program to get Nth Armstrong Number
using Microsoft.VisualBasic;
using System.Threading.Channels;
using System;
using static System.Console;
internal class Program {
   private static void Main (string[] args) {
      if (args.Length == 1 && int.TryParse (args[0], out int index) && 0 < index && index <= 25)
         WriteLine (PrintNthArmstrong (index));
      else WriteLine ("Enter a Valid Index between 1 and 25 ");
   }

   static string PrintNthArmstrong (int index) {
      int count = 0, num = 0;
      int res = 0;
      if (0 < index && index < 10)
         return $"The {index}th Armstrong Number : {index}";
      while (count < index) {
         res = 0;
         int check = num;
         int exp = num.ToString ().Length;
         while (0 < check) {
            int power = 1;
            for (int i = 0; i < exp; i++)
               power *= check % 10;
            res += power;
            check /= 10;
         }
         if (res == num) count++;
      }
      return $" Armstrong Number {index} is : {res}";
   }
}