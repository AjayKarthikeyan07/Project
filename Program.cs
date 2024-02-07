// ----------------------------------------------------------------------------------------
// MyStack<T>
// Create a stack (MyStack<T>) with underlying structure as array using property,methods and private variables
// ----------------------------------------------------------------------------------------

namespace Training {
   using static System.Console;

   #region Program ----------------------------------------------------------------------
   internal class Program {
      static void Main (string[] args) {
      }
   }
   #endregion

   #region Class MyStack ---------------------------------------------------------------------
   /// <summary>Represents a last in first out principle (LIFO) collection of instances of same specified type</summary>
   public class MyStack<T> {

      #region Properties --------------------------------------------
      /// <summary>Returns the capacity of the stack</summary>
      public int Capacity => mArrayStack.Length;

      /// <summary>Returns the number of elements in the stack</summary>
      public int Count => mCount;

      /// <summary>Returns true or false after checking the list is empty or not</summary>
      public bool IsEmpty => mCount == 0;
      #endregion

      #region Implementation ----------------------------------------
      /// <summary>Push elements into the stack </summary>
      /// <param name="a">Element to be pushed into the stack</param>
      public void Push (T a) {
         if (mCount == Capacity) Array.Resize (ref mArrayStack, Capacity * 2);
         mArrayStack[mCount++] = a;
      }

      /// <summary>Pop the last inserted element in the stack</summary>
      /// <returns>Returns the popped element</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Pop () {
         if (IsEmpty) throw new InvalidOperationException ();
         var poppedItem = mArrayStack[mCount - 1];
         mArrayStack[mCount - 1] = default;
         Array.Clear (mArrayStack, mCount - 1, 1);
         mCount--;
         return poppedItem;
      }

      /// <summary>Returns the element at the top of the stack withour removing it</summary>
      /// <returns>Returns the top element in the stack</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T Peek () {
         if (IsEmpty) throw new InvalidOperationException ();
         return mArrayStack[mCount - 1];
      }

      /// <summary>Print the stack</summary>
      public void Display () {
         Write ("Stack : ");
         for (int i = 0; i < mCount; i++) Write (mArrayStack[i] + " ");
         WriteLine ();
      }
      #endregion

      #region Private Data ------------------------------------------
      // Private variable for creating array and for getting count of elements
      T[] mArrayStack = new T[4];
      int mCount = 0;
      #endregion
   }
   #endregion
}