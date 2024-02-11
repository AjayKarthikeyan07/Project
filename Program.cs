// ----------------------------------------------------------------------------------------
// File Parser
// Implement a file parser using state machine
// ----------------------------------------------------------------------------------------

using static State;
using static System.Console;

#region Program ----------------------------------------------------------------------------------------
internal class Program {
   private static void Main (string[] args) {
      (string, string, string, string) Null = (null, null, null, null);
      Dictionary<string, (string, string, string, string)> ftest = new () {
         ["C:/Users/Username/Documents/file.txt"] = ("C", "USERS/USERNAME/DOCUMENTS", "FILE", "TXT"),
         ["D:/home/user/data/document.pdf"] = ("D", "HOME/USER/DATA", "DOCUMENT", "PDF"),
         ["D:/Projects/images/photo.jpg"] = ("D", "PROJECTS/IMAGES", "PHOTO", "JPG"),
         ["E:/ProgramFiles/Application/app.exe"] = ("E", "PROGRAMFILES/APPLICATION", "APP", "EXE"),
         ["C:/readme.txt"] = ("C", "", "README", "TXT"), ["C:Program/Data/Readme"] = Null,
         ["C:/"] = Null, ["D:/program/Readme,txt"] = Null, ["C:/Words.txt"] = ("C", "", "WORDS", "TXT"),
         ["C/Words.txt"] = Null
      };
      foreach (var (file, res) in ftest) {
         (string, string, string, string) result = MyFile.Parser (file.ToUpper ());
         bool same = res == result;
         if (!same) ForegroundColor = ConsoleColor.DarkRed;
         WriteLine ($"{file} \nExpected : {res} \nActual : {result}\n");
         ResetColor ();
      }
   }
}
#endregion

#region Class MyFile ---------------------------------------------------------------------
class MyFile {

   /// <summary>Parse a file using mealy state machine</summary>
   /// <param name="fileName">Input file name</param>
   /// <returns>Returns a tuple of drive,folders,file name and extension of the given file</returns>
   /// <exception cref="Exception">Throws an exception if the file name is not in correct format</exception>
   public static (string drive, string folder, string file, string extn) Parser (string fileName) {
      Action todo, none = () => { };
      string drive = "", folders = "", fname = "", extn = "";
      int sIndex;
      State s = A;
      foreach (var part in fileName + "~") {
         (s, todo) = (s, part) switch {
            (A, >= 'A' and <= 'Z') => (B, () => drive += part),
            (B, ':') => (C, none),
            (E or C, '/') => (D, () => folders += "/"),
            (D or E, >= 'A' and <= 'Z') => (E, () => folders += part),
            (E, '.') => (F, () => {
               sIndex = folders.LastIndexOf ("/");
               fname = folders[(sIndex + 1)..];
               folders = folders[..sIndex];
            }
            ),
            (F or G, >= 'A' and <= 'Z') => (G, () => extn += part),
            (G, '~') => (I, none),
            _ => (Z, none)
         };
         todo ();
      }
      folders = folders == "" ? folders : folders[1..];
      if (s == I) return (drive, folders, fname, extn);
      return (null, null, null, null);
   }
}
#endregion

enum State { A, B, C, D, E, F, G, I, Z };