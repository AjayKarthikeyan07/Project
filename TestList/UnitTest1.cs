using Training;

namespace Testlist {
   [TestClass]
   // Created a TestCustomList class for testing the custom created list
   public class TestCustomList {
      MyList<int> mTestList = new ();
      List<int> mOrigList = new ();

      /// <summary>A test method to test the add method of the list</summary>
      [TestMethod]
      public void TestAdd () {
         mTestList.Add (1);
         mTestList.Add (2);
         mTestList.Add (3);
         mTestList.Add (4);
         mTestList[3] = 6;
         mTestList.Add (5);
         mOrigList.Add (1);
         mOrigList.Add (2);
         mOrigList.Add (3);
         mOrigList.Add (4);
         mOrigList.Add (5);
         Assert.AreEqual (6, mTestList[3]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => mTestList[-1]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => mTestList[-2] = 8);
         Assert.AreEqual (mOrigList[0], mTestList[0]);
         Assert.AreEqual (mOrigList[1], mTestList[1]);
         Assert.AreEqual (mOrigList[2], mTestList[2]);
         Assert.AreEqual (1, mTestList[0]);
         Assert.AreEqual (5, mTestList.Count);
         Assert.AreEqual (8, mTestList.Capacity);
      }

      /// <summary>A test method to test the insert method of the list</summary>
      [TestMethod]
      public void TestInsert () {
         mTestList.Add (1);
         mTestList.Add (2);
         mTestList.Add (3);
         mTestList.Add (4);
         mTestList.Insert (1, 5);
         Assert.AreEqual (5, mTestList[1]);
         Assert.AreEqual (2, mTestList[2]);
         Assert.AreEqual (8, mTestList.Capacity);
         Assert.ThrowsException<IndexOutOfRangeException> (() => mTestList.Insert (8, 5));
      }

      /// <summary>A test method to test the remove method of the list</summary>
      [TestMethod]
      public void TestRemove () {
         mTestList.Add (1);
         mTestList.Add (2);
         mTestList.Add (3);
         mTestList.Add (4);
         Assert.AreEqual (4, mTestList.Count);
         Assert.IsFalse (mTestList.Remove (7));
         Assert.IsTrue (mTestList.Remove (1));
         Assert.AreEqual (3, mTestList.Count);
         Assert.AreEqual (2, mTestList[0]);
      }

      /// <summary>A test method to test the removeat method of the list</summary>
      [TestMethod]
      public void TestRemoveAt () {
         mTestList.Add (1);
         mTestList.Add (2);
         mTestList.Add (3);
         mTestList.Add (4);
         Assert.AreEqual (4, mTestList.Count);
         Assert.ThrowsException<IndexOutOfRangeException> (() => mTestList.RemoveAt (7));
         mTestList.RemoveAt (1);
         Assert.AreEqual (3, mTestList.Count);
         Assert.AreEqual (3, mTestList[1]);
      }

      /// <summary>A test method to test the clear method of the list</summary>
      [TestMethod]
      public void Testclear () {
         mTestList.Add (1);
         mTestList.Add (2);
         mTestList.Add (3);
         mTestList.Add (4);
         mTestList.Clear ();
         Assert.AreEqual (0, mTestList.Count);
         Assert.ThrowsException<InvalidOperationException> (() => mTestList.Clear ());
      }

      [TestMethod]
      public void TestPrintList () {
         mTestList.Add (1);
         mTestList.Add (2);
         mTestList.Add (3);
         mTestList.Add (4);
         mTestList.PrintList ();
      }
   }
}