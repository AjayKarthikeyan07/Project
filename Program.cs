// ----------------------------------------------------------------------------------------
// Double.Parse
// Create a class MyDouble and implement MyDouble.Parse method 
// ----------------------------------------------------------------------------------------

namespace Training {
   using static System.Console;

   #region Program ----------------------------------------------------------------------------------------
   internal class Program {
      static void Main (string[] args) {
            // Dictionary containing different possibile representation of double precision floating point number
            const double NaN = double.NaN;
            Dictionary<string, double> dnumbers = new () {
               ["-12"] = -12, ["+12"] = 12, ["12"] = 12, ["-+12"] = NaN, ["*12"] = NaN,
               ["12.3"] = 12.3, ["12.34"] = 12.34, ["12.-3"] = NaN, [".14"] = 0.14, ["12."] = 12, ["12~"] = NaN, ["a12"] = NaN,
               ["12b"] = NaN, ["12..3"] = NaN, ["12e3"] = 12000, ["12.34e3"] = 12340, ["12.34E-2"] = 0.1234, ["12.3e"] = NaN,
               ["12.3e-+"] = NaN, ["12.3e-+3"] = NaN, ["12.34e5."] = NaN, [".e3"] = NaN, ["e4"] = NaN, ["12e"] = NaN,
               ["12.34"] = 12.34, ["0.12"] = 0.12, ["12.0"] = 12, ["12e0"] = 12, ["0e0"] = 0, ["12.0e0"] = 12, ["+e3"] = NaN,
               ["123.456"] = 123.456
            };

            foreach (var number in dnumbers) {
               bool same = Same (Math.Round (MyDouble.Parse (number.Key), 8), number.Value);
               if (!same) ForegroundColor = ConsoleColor.DarkRed;
               WriteLine ($"{number.Key} \nExpected : {number.Value} \nActual : {MyDouble.Parse (number.Key)}");
               ResetColor ();
               bool Same (double a, double b) {
                  if (double.IsNaN (a)) return double.IsNaN (b);
                  return Math.Abs (a - b) < 1e-6;
               }
            }
         }
      }
      #endregion

      #region Class MyDouble ---------------------------------------------------------------------
      /// <summary>Class mDouble - Represents a double precision floating point number</summary>
      public class MyDouble {
         static char[] sChars = { '+', '-', 'e' };

         #region Implementation ----------------------------------------
         /// <summary>Parse a given valid string into double precision floating point number</summary>
         /// <param name="number">The string to be parsed into double</param>
         /// <returns>Returns a double precision floating point number</returns>
         /// <exception cref="FormatException">Throws exception if the string provided is not in correct format</exception>
         public static double Parse (string number) {
            number = number.Trim ().ToLower ();
            double result = 0, exp = 0, factor = 0.1, sign = 1, eSign = 1;
            int process = 1;
            int eindex = number.IndexOf ('e');

            // Checks if the string is in incorrect format and throws exception
            if (string.IsNullOrWhiteSpace (number) || sChars.Any (number.EndsWith) || number.StartsWith ('e'))
               return double.NaN;
            for (int i = 0; i < number.Length; i++) {
               char ch = number[i];
               // To get sign of the number 
               if (process == 1 && (ch is '+' or '-' or '.' || char.IsDigit (ch))) {
                  if (ch is '+' or '-') {
                     sign = ch == '-' ? -1 : 1;
                     process = 2;
                  } else if (char.IsDigit (ch)) {
                     i--; process = 2;
                  } else if (ch == '.') process = 3;
               }
               // To evaluate the integral part of the number
               else if (process == 2) {
                  if (char.IsDigit (ch)) result = result * 10 + (ch - '0');
                  else if (ch == '.') process = 3;
                  else if (ch == 'e' && char.IsDigit (number[i - 1])) process = 4;
                  else return double.NaN;
               }
               // To evaluate the fraction part of the number
               else if (process == 3) {
                  if (char.IsDigit (ch)) {
                     result += factor * (ch - '0');
                     factor /= 10;
                  } else if (char.IsDigit (number[i - 1]) && ch == 'e') process = 4;
                  else return double.NaN;
               }
               // To get the sign of exponent and evaluate the exponential part of the number
               else {
                  if (ch is '+' or '-' && char.IsDigit (number[i + 1]))
                     eSign = number[eindex + 1] == '-' ? -1 : 1;
                  else if (char.IsDigit (ch)) exp = exp * 10 + (ch - '0');
                  else return double.NaN;
               }
            }
            result = sign * ((result) * (exp == 0 ? 1 : Math.Pow (10, exp * eSign)));
            return result;
         }
         #endregion
      }
      #endregion
   }