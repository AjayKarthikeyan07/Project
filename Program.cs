//Reverse num and check for pallindrome
using static System.Console;

Write ("Enter a Number : ");
if (int.TryParse (ReadLine (), out int num)) {
   int orig = num;
   int rev = 0;
   while (num != 0) {
      rev = (rev * 10) + num % 10;
      num = num / 10;
   }
   WriteLine ("It is " + (orig == rev ? "a Palindrome" : "not a Palindrome"));
} else WriteLine ("Enter valid Number");