namespace Eval;
class EvalException : Exception {
   public EvalException (string message) : base (message) { }
}
class Evaluator {
   public double Evaluate (string text) {
      List<Token> tokens = new ();
      var tokenizer = new Tokenizer (this, text);
      for (; ; ) {
         var token = tokenizer.Next ();
         if (token is TEnd) break;
         if (token is TError err) throw new EvalException (err.Message);
         tokens.Add (token);
      }
      // Check if this is a variable assignment
      TVariable? tVariable = null;
      if (tokens.Count > 2 && tokens[0] is TVariable tvar && tokens[1] is TOpArithmetic { Op: '=' }) {
         tVariable = tvar;
         tokens.RemoveRange (0, 2);
      }
      for (int i = 0; i < tokens.Count; i++) {
         if (i != tokens.Count - 1 && tokens[i] is TOpArithmetic binary && binary.Op is '+' or '-' && tokens[i + 1] is TOpUnary unary) {
            binary.Op = binary.Op == unary.Uop ? '+' : '-';
            tokens.Remove (unary);
         }
         Process (tokens[i]);
      }
      while (mOperators.Count > 0) ApplyOperator ();
      if (mBasePriority != 0) Error ("Too many Punctuations");
      if (mOperators.Count > 0) Error ("Too many operators");
      if (mOperands.Count != 1) Error ("Too many operands");
      double f = mOperands.Pop ();
      if (tVariable != null) mVars[tVariable.Name] = f;
      return f;
   }
   public double GetVariable (string name) {
      if (mVars.TryGetValue (name, out double f)) return f;
      throw new EvalException ($"Unknown variable: {name}");
   }
   readonly Dictionary<string, double> mVars = new ();
   void Process (Token token) {
      switch (token) {
         case TNumber num:
            mOperands.Push (num.Value);
            break;
         case TOperator op:
            op.FinalPriority = mBasePriority + op.Priority;
            while (mOperators.Count > 0 && mOperators.Peek ().FinalPriority > op.FinalPriority)
               ApplyOperator ();
            mOperators.Push (op);
            break;
         case TPunctuation p:
            mBasePriority += p.Punct == '(' ? 10 : -10;
            break;
         default:
            Error ($"Unknown token: {token}");
            return;
      }
   }

   void ApplyOperator () {
      var op = mOperators.Pop ();
      if (op is TOpArithmetic arith) {
         if (mOperands.Count < 2) Error ("Too few operands");
         double f1 = mOperands.Pop (), f2 = mOperands.Pop ();
         mOperands.Push (arith.Evaluate (f2, f1));
      }
      if (op is TOpUnary unary) {
         if (mOperands.Count < 1) Error ("Too few operands");
         double f = mOperands.Pop ();
         mOperands.Push (unary.Apply (f));
      }
      if (op is TOpFunction func) {
         if (mOperands.Count < 1) Error ("Too few operands");
         double f = mOperands.Pop ();
         mOperands.Push (func.Evaluate (f));
      }
   }
   void Error (string msg) {
      throw new EvalException (msg);
   }

   int mBasePriority;
   readonly Stack<double> mOperands = new ();
   readonly Stack<TOperator> mOperators = new ();
}