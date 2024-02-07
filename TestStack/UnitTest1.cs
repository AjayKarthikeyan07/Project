using Training;

namespace TestCustomStack {
   [TestClass]
   public class TestCustomStack {
      MyStack<int> mStack = new ();

      [TestMethod]
      public void TestPush () {
         mStack.Push (1);
         mStack.Push (2);
         mStack.Push (3);
         mStack.Push (4);
         Assert.AreEqual (4, mStack.Count);
         mStack.Push (5);
         Assert.AreEqual (5, mStack.Count);
         Assert.AreEqual (8, mStack.Capacity);
      }

      [TestMethod]
      public void TestPop () {
         Assert.IsTrue (mStack.IsEmpty);
         Assert.ThrowsException<InvalidOperationException> (() => mStack.Pop ());
         mStack.Push (1);
         mStack.Push (2);
         mStack.Push (3);
         mStack.Push (4);
         mStack.Push (5);
         Assert.AreEqual (5, mStack.Pop ());
         Assert.AreEqual (4, mStack.Count);
      }

      [TestMethod]
      public void TestPeek () {
         Assert.IsTrue (mStack.IsEmpty);
         Assert.ThrowsException<InvalidOperationException> (() => mStack.Peek ());
         mStack.Push (1);
         mStack.Push (2);
         mStack.Push (3);
         mStack.Push (4);
         mStack.Push (5);
         Assert.AreEqual (5, mStack.Peek ());
         Assert.AreEqual (5, mStack.Count);
      }

      [TestMethod]
      public void TestDisplay () {
         mStack.Push (1);
         mStack.Push (2);
         mStack.Push (3);
         mStack.Push (4);
         mStack.Push (5);
         mStack.Display ();
      }
   }
}