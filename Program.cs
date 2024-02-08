// ----------------------------------------------------------------------------------------
// Eight Queens
// To print all valid solutions or 12 unique solutions of eight queens problem
// ----------------------------------------------------------------------------------------

using System.Text;
using static System.Console;

#region Program ----------------------------------------------------------------------------------------
internal class Program {
   public static void Main (string[] args) {
      Console.WriteLine (" Print \n 1. All Solutions \n 2. Unique Solutions");
      var choice = ReadKey ().Key;
      if (choice == ConsoleKey.D1) {
         EightQueens (0);
         PrintSolution ();
      } else if (choice == ConsoleKey.D2) {
         EightQueens (0, true);
         PrintSolution ();
      } else
         WriteLine ("Enter valid input");
   }

   #region Private data ------------------------------------------
   //Array to store the position of Queens
   static int[] sPosition = new int[8];
   //List to store the possible solutions 
   static List<int[]> sSolutions = new ();
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>Get all valid solutions of eight queens using backtracking</summary>
   /// <param name="r">Row of the chess board where queen is to placed</param>
   /// <param name="unique">To store the choice of required type of solution</param>
   static void EightQueens (int r, bool unique = false) {
      for (sPosition[r] = 0; sPosition[r] < 8; sPosition[r]++) {
         if (!IsSafe (r)) continue;
         if (r == 7) {
            if (unique && IsUniqueSolution (sPosition.ToArray ())) return;
            sSolutions.Add (sPosition.ToArray ());
         } else EightQueens (r + 1, unique);
      }
   }

   /// <summary>Checks if placing a queen at a particular position in row r in a chessboard is safe</summary>
   /// <param name="r">Row of the chess board</param>
   /// <returns>Return true if safe and false if not safe</returns>
   static bool IsSafe (int r) {
      for (int i = 0; i < r; i++) {
         int x = r - i, y = Math.Abs (sPosition[r] - sPosition[i]);
         //To check if 2 queens are not in same column or diagnol 
         if (y == 0 || x - y == 0) return false;
      }
      return true;
   }

   /// <summary>Check whether the solution obtained is unique</summary>
   /// <param name="position">The array to be checked</param>
   /// <returns>Returns true if the solution is not unique and false if unique</returns>
   static bool IsUniqueSolution (int[] position) {
      for (int i = 0; i < 4; i++) {
         position = Rotate (position);
         //Checks if the rotated or mirrored solution already exist in the list 
         if (sSolutions.Any (s => s.SequenceEqual (position) || s.SequenceEqual (Mirror (position)))) return true;
      }
      return false;
   }

   /// <summary>Rotate the cells of the chessboard by 90 degree</summary>
   /// <param name="position">The cell to be rotated</param>
   /// <returns>Returns the rotated solution</returns>
   static int[] Rotate (int[] position) {
      int[] rotated = new int[8];
      for (int i = 0; i < 8; i++)
         rotated[position[i]] = 7 - i;
      return rotated;
   }

   /// <summary>Mirror the cell along vertical axis</summary>
   /// <param name="position">The cell to be mirrored</param>
   /// <returns>Returns the mirrored solution</returns>
   static int[] Mirror (int[] position) => position.Select (p => 7 - p).ToArray ();

   /// <summary>Print the solutions</summary>
   static void PrintSolution () {
      OutputEncoding = new UnicodeEncoding ();
      for (int i = 0; i < sSolutions.Count; i++) {
         WriteLine ($"\nSolution {i + 1} :");
         WriteLine ("┏" + String.Concat (Enumerable.Repeat ("━━━┳", 7)) + "━━━┓");
         for (int r = 0; r < 8; r++) {
            for (int c = 0; c <= 8; c++)
               Write ($"{(sSolutions[i][r] == c ? "┃ ♕ " : "┃   ")}");
            WriteLine ("\n" + (r < 7 ? ("┣" + String.Concat (Enumerable.Repeat ("━━━┫", 8)))
                                     : ("┗" + String.Concat (Enumerable.Repeat ("━━━┻", 7)) + "━━━┛")));
         }
      }
   }
}
#endregion
#endregion