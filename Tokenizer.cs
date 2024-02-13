namespace Eval;
class Tokenizer {
   public Tokenizer (Evaluator eval, string text) {
      mText = text; mN = 0; mEval = eval;
   }
   readonly Evaluator mEval;  // The evaluator that owns this 
   readonly string mText;     // The input text we're parsing through
   int mN;                    // Position within the text
   public Token Next () {
      while (mN < mText.Length) {
         char ch = char.ToLower (mText[mN++]);
         switch (ch) {
            case ' ' or '\t': continue;
            case (>= '0' and <= '9') or '.': return GetNumber ();
            case '(' or ')': return new TPunctuation (ch);
            case '+' or '-' or '*' or '/' or '^' or '=': return GetOperator ();
            case >= 'a' and <= 'z': return GetIdentifier ();
            default: return new TError ($"Unknown symbol: {ch}");
         }
      }
      return new TEnd ();
   }
   Token GetIdentifier () {
      int start = mN - 1;
      while (mN < mText.Length) {
         mN--; break;
      }
      string sub = mText[start..mN];
      if (mFuncs.Contains (sub)) return new TOpFunction (sub);
      else return new TVariable (mEval, sub);
   }
   readonly string[] mFuncs = { "sin", "cos", "tan", "sqrt", "log", "exp", "asin", "acos", "atan" };

   Token GetOperator () {
      int start = mN - 1;
      var ch = mText[start];
      if (ch is '+' or '-' && (start is 0 || mText[start - 1] is '+' or '-' or '*' or '^' or '/' or '(' or '=' or ' ')) return new TOpUnary (ch);
      return new TOpArithmetic (ch);
   }

   Token GetNumber () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= '0' and <= '9') or '.') continue;
         mN--; break;
      }
      // mN points to the first character of mText that is not part of the number
      string sub = mText[start..mN];
      if (double.TryParse (sub, out double f)) return new TLiteral (f);
      return new TError ($"Invalid number: {sub}");
   }
}