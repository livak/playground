using DataStructures.Queues;
using DataStructures.Test.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Queues
{
    [TestClass]
    public class PriorityQueueLinkedListTests
    {
        [TestMethod]
        public void Test()
        {
            var queue = new PriorityQueueLinkedList<int>();

            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(5);
            Assert.AreEqual("531", queue.GetValues());

            queue.Enqueue(4);
            Assert.AreEqual("5431", queue.GetValues());

            Assert.AreEqual(5, queue.Dequeue());
            Assert.AreEqual("431", queue.GetValues());

            queue.Enqueue(0);
            Assert.AreEqual("4310", queue.GetValues());
        }
    }
}
