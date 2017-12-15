using DataStructures.Test.Infrastructure.Extensions;
using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DataStructures.Test.Trees
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void Test()
        {
            var tree = new BinaryTree<int> { 4, 2, 1, 6, 4, 7 };
            Assert.AreEqual("124467", tree.GetValues());
        }

        [TestMethod]
        public void TestContains()
        {
            var tree = new BinaryTree<int> { 4, 2, 1, 6, 4, 7 };
            Assert.IsTrue(tree.Contains(7));
        }

        [TestMethod]
        public void TestRemove()
        {
            var tree = GetExampleTree();

            // (1) not exist
            tree.Remove(800);
            Assert.AreEqual("123456789", tree.GetValues());

            // (2) remove terminal nodes
            tree.Remove(3);
            Assert.AreEqual("12456789", tree.GetValues());

            tree.Remove(1);
            Assert.AreEqual("2456789", tree.GetValues());

            tree.Remove(8);
            Assert.AreEqual("245679", tree.GetValues());

            tree.Remove(7);
            Assert.AreEqual("24569", tree.GetValues());

            tree.Remove(5);
            Assert.AreEqual("2469", tree.GetValues());

            tree.Remove(6);
            Assert.AreEqual("249", tree.GetValues());

            tree.Remove(2);
            Assert.AreEqual("49", tree.GetValues());

            tree.Remove(9);
            Assert.AreEqual("4", tree.GetValues());

            tree.Remove(4);
            Assert.AreEqual("", tree.GetValues());

            // (3) Remove not terminal nodes

            // (3.1) no right child (left replaces node - promote  left)
            tree = GetExampleTree();
            tree.Remove(9);
            Assert.AreEqual("12345678", tree.GetValues());

            // (3.2) right child doesn't have left child  (right replaces node - promote right)
            tree = GetExampleTree();
            tree.Remove(6);
            Assert.AreEqual("12345789", tree.GetValues());

            // (3.3) right child has left child (promote left child from right child)
            tree = GetExampleTree();
            tree.Remove(4);
            Assert.AreEqual("12356789", tree.GetValues());

        }

        [TestMethod]
        public void TestRemoveRandom()
        {
            var rnd = new Random();
            rnd.Next(1000);

            var list = new List<int>();
            var tree = new BinaryTree<int>();
            foreach (var item in Enumerable.Range(0, 1000))
            {
                var num = rnd.Next(1000);
                list.Add(num);
                tree.Add(num);
            }

            foreach (var item in Enumerable.Range(0, 1000))
            {
                Assert.AreEqual(list.OrderBy(x => x).GetValues(), tree.GetValues());
                var removeIndex = rnd.Next(list.Count - 1);
                var toRemove = list[removeIndex];
                list.RemoveAt(removeIndex);
                tree.Remove(toRemove);
            }
        }

        private BinaryTree<int> GetExampleTree()
        {
            /*
                        ( 4 )
                      /       \
                   (2)         (9)
                  /   \        / 
                (1)  (3)     (6) 
                             / \ 
                           (5)(7) 
                                 \
                                 (8)
              
             */

            return new BinaryTree<int> { 4, 9, 2, 6, 7, 5, 3, 1, 8 };
        }
    }
}
