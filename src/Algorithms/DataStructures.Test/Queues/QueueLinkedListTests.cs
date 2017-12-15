using DataStructures.Queues;
using DataStructures.Test.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Queues
{
    [TestClass]
    public class QueueLinkedListTests
    {
        [TestMethod]
        public void Test()
        {
            var queue = new QueueLinkedList<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual("123", queue.GetValues());

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual("23", queue.GetValues());
        }
    }
}
