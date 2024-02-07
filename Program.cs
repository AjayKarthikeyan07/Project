// Program for checking Valid Password 
using static System.Console;
Write ("Enter your Password : ");
string pass = ReadLine () ?? "";
WriteLine (IsValid (pass));
string IsValid (string s) {
   string result = "";
   string spl = "!@#$%^&*()-+";
   if (s.Length >= 6) {
      var res = "Password should contain atleast 1 ";
      if (!s.Any (char.IsDigit)) result += res + "Numerical \n";
      if (!s.Any (char.IsUpper)) result += res + "Upper case \n";
      if (!s.Any (char.IsLower)) result += res + "Lower case \n";
      if (!s.Any (spl.Contains)) result += res + "Special character " + spl;
   } else result = "Password should contain atleast 6 characters";
   if (result == "") result = "Your Password is Strong";
   return result;
}