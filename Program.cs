//Digital root
using static System.Console;
Write ("Enter a Number : ");
if (int.TryParse (ReadLine (), out int num) && num >= 0) {
   while (num.ToString ().Length != 1) {
      var digroot = num;
      num = 0;
      foreach (var ch in digroot.ToString ())
         num += int.Parse (ch.ToString ());
   }
   WriteLine ($"Digital root : {num}");
} else WriteLine ("Enter Valid Input");