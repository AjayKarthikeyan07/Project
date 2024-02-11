// ----------------------------------------------------------------------------------------
// Double Ended Queue
// Implement a double ended queue with array as underlying structure
// ----------------------------------------------------------------------------------------

namespace Training {
   internal class Program {
      private static void Main (string[] args) {
      }
   }

   #region Class MyDeQueue ---------------------------------------------------------------------
   /// <summary>Represent a queue with insertion and deletion at both the ends</summary>
   public class MyDeQueue<T> {

      #region Constructor -------------------------------------------
      // Constructor for initializing the array and count
      public MyDeQueue () {
         mArray = new T[4];
         mRear = -1;
      }
      #endregion

      #region Properties --------------------------------------------
      /// <summary>Returns the capacity of the queue</summary>
      public int Capacity => mArray.Length;

      /// <summary>Returns the number of elements in the double ended queue</summary>
      public int Count => mCount;

      /// <summary>Returns true if the queue is empty else returns false</summary>
      bool IsEmpty => Count == 0;

      /// <summary>Returns true if the queue is full else returns false</summary>
      bool IsFull => Count == Capacity;
      #endregion

      #region Implementation ----------------------------------------
      /// <summary>Delete/Dequeue the element at the front end of the queue</summary>
      /// <returns>Returns the deleted element</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T FDequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         var deqEle = mArray[mFront];
         if (mFront == mRear && Count == 1) Reset ();
         else mFront = (mFront + 1) % Capacity;
         mCount--;
         return deqEle;
      }

      /// <summary>Add/Enqueue an element at the front end of the queue</summary>
      /// <param name="a">Element to be added</param>
      public void FEnqueue (T a) {
         if (IsFull) ResizeArray ();
         mFront = (mFront + Capacity - 1) % Capacity;
         mArray[mFront] = a;
         mCount++;
      }

      /// <summary>Returns the peek element at the front end of the queue</summary>
      /// <returns>Returns the first element at the front end of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T FPeek () {
         if (IsEmpty) throw new InvalidOperationException ();
         return mArray[mFront];
      }

      /// <summary>Delete/Dequeue the element at the rear end of the queue</summary>
      /// <returns>Returns the deleted element</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T RDequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         if (mRear == -1) mRear = Capacity - 1;
         var deqEle = mArray[mRear];
         if (mFront == mRear && Count == 1) Reset ();
         else mRear = (mRear + Capacity - 1) % Capacity;
         mCount--;
         return deqEle;
      }

      /// <summary>Add/Enqueue an element at the rear end of the queue</summary>
      /// <param name="a">Element to be added</param>
      public void REnqueue (T a) {
         if (IsFull) ResizeArray ();
         mRear = (mRear + 1) % Capacity;
         mArray[mRear] = a;
         mCount++;
      }

      /// <summary>Resets the front and rear</summary>
      void Reset () => (mRear, mFront) = (-1, 0);

      /// <summary>Resizes the array</summary>
      void ResizeArray () {
         T[] newArr = new T[Capacity];
         int j = 0;
         while (j < mCount) {
            newArr[j++] = mArray[mFront];
            mFront = (mFront + Capacity + 1) % Capacity;
         }
         Array.Resize (ref newArr, Capacity * 2);
         (mArray, mFront, mRear) = (newArr, 0, mCount - 1);
      }

      /// <summary>Returns the peek element at the rear end of the queue</summary>
      /// <returns>Returns the first element at the rear end of the queue</returns>
      /// <exception cref="InvalidOperationException"></exception>
      public T RPeek () {
         if (IsEmpty) throw new InvalidOperationException ();
         if (mRear == -1) mRear = Capacity - 1;
         return mArray[mRear];
      }
      #endregion

      #region Private Data ------------------------------------------
      // Private variable for initialising array,count,front and rear
      T[] mArray;
      int mCount, mFront, mRear;
      #endregion
   }
   #endregion
}