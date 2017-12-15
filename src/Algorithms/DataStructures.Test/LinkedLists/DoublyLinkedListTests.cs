using DataStructures.LinkedLists;
using DataStructures.Test.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataStructures.Test.LinkedLists
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        public void Add()
        {
#pragma warning disable IDE0028 // Simplify collection initialization
            var list = new DoublyLinkedList<int>();
#pragma warning restore IDE0028 // Simplify collection initialization
            list.Add(3);
            list.Add(5);
            list.Add(7);

            Assert.AreEqual("357", list.GetValues());
        }

        [TestMethod]
        public void RemoveLast()
        {
            var list = new DoublyLinkedList<int>() { 3, 5, 7 };
            Assert.AreEqual("357", list.GetValues());

            list.RemoveLast();
            Assert.AreEqual("35", list.GetValues());

            list.RemoveLast();
            Assert.AreEqual("3", list.GetValues());

            list.RemoveLast();
            Assert.AreEqual("", list.GetValues());

            list.RemoveLast();
            Assert.AreEqual("", list.GetValues());
        }

        [TestMethod]
        public void RemoveFirst()
        {
            var list = new DoublyLinkedList<int>() { 3, 5, 7 };
            Assert.AreEqual("357", list.GetValues());

            list.RemoveFirst();
            Assert.AreEqual("57", list.GetValues());

            list.RemoveFirst();
            Assert.AreEqual("7", list.GetValues());

            list.RemoveFirst();
            Assert.AreEqual("", list.GetValues());

            list.RemoveFirst();
            Assert.AreEqual("", list.GetValues());
        }

        [TestMethod]
        public void Remove()
        {
            var list = new DoublyLinkedList<int>() { 1, 3, 5, 7, 9 };
            Assert.AreEqual("13579", list.GetValues());

            list.Remove(9); // last
            Assert.AreEqual("1357", list.GetValues());

            list.Remove(1); // first
            Assert.AreEqual("357", list.GetValues());

            list.Remove(5); // middle
            Assert.AreEqual("37", list.GetValues());

            list.Remove(7);  // one before last
            Assert.AreEqual("3", list.GetValues());

            list.Remove(44); // not exist
            Assert.AreEqual("3", list.GetValues());

            list.Remove(3); // last
            Assert.AreEqual("", list.GetValues());
        }


    }

}
