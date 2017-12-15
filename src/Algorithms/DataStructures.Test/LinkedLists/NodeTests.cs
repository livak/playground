using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.LinkedLists;

namespace DataStructures.Test.LinkedLists
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void NodeChain()
        {
            var first  = new Node() { Value = 3 };
            var middle = new Node() { Value = 5 };
            var last   = new Node() { Value = 7 };

            first.Next = middle;
            middle.Next = last;

            Assert.AreEqual("357", GetValues(first));
        }

        private string GetValues(Node node)
        {
            var s = "";
            while (node != null)
            {
                s += node.Value;
                node = node.Next;
            }

            return s;
        }
    }
}
