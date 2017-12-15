using DataStructures.Stacks;
using DataStructures.Test.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Stacks
{
    [TestClass]
    public class StackLinkedListTests
    {
        [TestMethod]
        public void PushPop()
        {
            var stack = new StackLinkedList<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual("321", stack.GetValues());

            stack.Pop();
            Assert.AreEqual("21", stack.GetValues());

            stack.Pop();
            Assert.AreEqual("1", stack.GetValues());
        }
    }
}
