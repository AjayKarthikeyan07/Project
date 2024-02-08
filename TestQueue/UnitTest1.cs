using System.Collections.Generic;
using Training;
namespace TestQueue {
   [TestClass]
   public class TestQueue {

      [TestMethod]
      public void TestEnqueue () {
         mTestQueue.Enqueue (1);
         mTestQueue.Enqueue (2);
         mTestQueue.Enqueue (3);
         mTestQueue.Enqueue (4);
         mOrigQueue.Enqueue (1);
         mOrigQueue.Enqueue (2);
         mOrigQueue.Enqueue (3);
         mOrigQueue.Enqueue (4);
         Assert.AreEqual (mOrigQueue.Count, mTestQueue.Count);
         Assert.AreEqual (4, mTestQueue.Count);
         Assert.AreEqual (4, mTestQueue.Capacity);
         mTestQueue.Enqueue (5);
         Assert.AreEqual (5, mTestQueue.Count);
         Assert.AreEqual (8, mTestQueue.Capacity);
      }

      [TestMethod]
      public void TestDequeue () {
         Assert.IsTrue (mTestQueue.IsEmpty);
         Assert.ThrowsException<InvalidOperationException> (() => mTestQueue.Dequeue ());
         mTestQueue.Enqueue (1);
         mTestQueue.Enqueue (2);
         mTestQueue.Enqueue (3);
         mTestQueue.Enqueue (4);
         mOrigQueue.Enqueue (1);
         mOrigQueue.Enqueue (2);
         mOrigQueue.Enqueue (3);
         mOrigQueue.Enqueue (4);
         Assert.AreEqual (mOrigQueue.Dequeue (), mTestQueue.Dequeue ());
         Assert.AreEqual (2, mTestQueue.Dequeue ());
         mTestQueue.Dequeue ();
         mTestQueue.Dequeue ();
         mOrigQueue.Dequeue ();
         mOrigQueue.Dequeue ();
         mOrigQueue.Dequeue ();
         Assert.AreEqual (0, mTestQueue.Count);
         Assert.AreEqual (0, mOrigQueue.Count);

      }

      [TestMethod]
      public void TestPeek () {
         Assert.IsTrue (mTestQueue.IsEmpty);
         Assert.ThrowsException<InvalidOperationException> (() => mTestQueue.Peek ());
         mTestQueue.Enqueue (1);
         mTestQueue.Enqueue (2);
         mTestQueue.Enqueue (3);
         mTestQueue.Enqueue (4);
         mOrigQueue.Enqueue (1);
         mOrigQueue.Enqueue (2);
         mOrigQueue.Enqueue (3);
         mOrigQueue.Enqueue (4);
         Assert.AreEqual (mOrigQueue.Peek (), mTestQueue.Peek ());
      }

      [TestMethod]
      public void TestDisplay () {
         mTestQueue.Display ();
         mTestQueue.Enqueue (1);
         mTestQueue.Enqueue (2);
         mTestQueue.Enqueue (3);
         mTestQueue.Enqueue (4);
         mTestQueue.Display ();
      }
      TQueue<int> mTestQueue = new ();
      Queue<int> mOrigQueue = new ();

   }
}