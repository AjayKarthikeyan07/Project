// Chess Board Program
using System.ComponentModel;
using System.Text;
using static System.Console;

OutputEncoding = new UnicodeEncoding ();

// Array containing White coins
string[] white = new[] { "\u2656", "\u2658", "\u2657", "\u2654",
                         "\u2655", "\u2657", "\u2658", "\u2656"};
// Array containing black coins
string[] black = new[] { "\u265C", "\u265E", "\u265D", "\u265B",
                         "\u265A", "\u265D", "\u265E", "\u265C"};
WriteLine ("\u250F" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u2533", 7)) +
                   "\u2501\u2501\u2501\u2501\u2501\u2513");
DrawLines ('V');
PrintCoins (white);
DrawLines ('H');
PrintPawns ('W');
for (int i = 0; i < 5; i++) {
   DrawLines ('V');
   DrawLines ('H');
   DrawLines ('V');
}
PrintPawns ('B');
DrawLines ('H');
DrawLines ('V');
PrintCoins (black);
WriteLine ("\u2517" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u253B", 7)) +
           "\u2501\u2501\u2501\u2501\u2501\u251B");

// Prints the main coins on the chess board
// "pieces" - Indicates the main coins
void PrintCoins (string[] pieces) {
   Write ("\u2503");
   foreach (var piece in pieces)
      Write ($"  {piece}  \u2503");
   WriteLine ();
}

// Prints the pawns on the chess board
// "colour" - Indicates the colour of coins
void PrintPawns (char colour) {
   Write ("\u2503");
   Write (String.Concat (Enumerable.Repeat ($"  {(colour == 'W' ? "\u2659" : "\u265F")}  \u2503", 8)));
   WriteLine ();
}

// Prints horizontal and vertical lines for grid
// "line" - horizontal (H) or vertical (v) Grid
void DrawLines (char line) => WriteLine (line == 'H'
                              ? "\u2523" + String.Concat (Enumerable.Repeat ("\u2501\u2501\u2501\u2501\u2501\u252b", 8))
                              : String.Concat (Enumerable.Repeat ("\u2503     ", 9)));