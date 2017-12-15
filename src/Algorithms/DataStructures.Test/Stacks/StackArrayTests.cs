using DataStructures.Stacks;
using DataStructures.Test.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Stacks
{
    [TestClass]
    public class StackArrayTests
    {
        [TestMethod]
        public void PushPop()
        {
            var stack = new StackArray<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            Assert.AreEqual("54321", stack.GetValues());

            stack.Pop();
            Assert.AreEqual("4321", stack.GetValues());

            stack.Pop();
            Assert.AreEqual("321", stack.GetValues());
        }
    }
}
