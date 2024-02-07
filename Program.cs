// Program.cs
// Voting Contest
// Given a string of votes and find the winner based on highest number of votes
// Sample Input : aaABBcd Sample Output : a or A

using static System.Console;

Write ("Enter the Vote String without spaces: ");
string vote = ReadLine () ?? "".ToLower ();
if (vote != null && vote.Length > 0 && vote.All (char.IsLetter)) {
   var winner = GetWinner (vote);
   WriteLine ($"METHOD 1 - The winner is {winner.Letter} with {winner.LetterCount} votes");
   var winner2 = GetWinner2 (vote);
   WriteLine ($"METHOD 2 - The winner is {winner2.Letter} with {winner2.LetterCount} votes");
} else Write ("Enter Valid Input");

// Method - 1 (USING LINQ OPERATORS)

/// <summary>GetWinner : Returns the winner having highest number of votes 
/// If 2 contestant have same number of votes, First contestant who got vote is winner</summary>
/// <param name="vote">String of votes</param>
/// <return>Returns a tuple (multiple return Values) containg the highest occuring character and the number of occurences</return>

(char Letter, int LetterCount) GetWinner (string vote)
   => vote.GroupBy (x => x)
          .Select (x => (x.First (), x.Count ()))
          .OrderByDescending (x => x.Item2)
          .FirstOrDefault ();

// Method - 2 (USING DICTIONARY)

/// <summary>GetWinner2 : Returns the winner having highest number of votes 
/// If 2 contestant have same number of votes, First contestant who got vote is winner</summary>
/// <param name="vote">String of votes</param>
/// <return>Returns a tuple (multiple return Values) containg the highest occuring character and the number of occurences</return>

(char Letter, int LetterCount) GetWinner2 (string vote) {
   // Dictionary to store letters and their count

   List<ValueTuple<char, int>> list = new ();
   for (int i = 0; i < vote.Length; i++) {
      var index = list.FindIndex (x => x.Item1 == vote[i]);
      if (index == -1) list.Add ((vote[i], 1));
      else list[index] = (vote[index], list[index].Item2 + 1);
   }
   return list.OrderByDescending (x => x.Item2).FirstOrDefault ();
}