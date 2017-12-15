using DataStructures.Queues;
using DataStructures.Test.Infrastructure.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Test.Queues
{
    [TestClass]
    public class QueueArrayTests
    {
        [TestMethod]
        public void Test()
        {
            var queue = new QueueArray<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual("12345", queue.GetValues());

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual("2345", queue.GetValues());

            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual("345", queue.GetValues());

            queue.Enqueue(6);
            Assert.AreEqual("3456", queue.GetValues());

            queue.Enqueue(7);
            Assert.AreEqual("34567", queue.GetValues());

            queue.Enqueue(8);
            Assert.AreEqual("345678", queue.GetValues());

            queue.Enqueue(9);
            Assert.AreEqual("3456789", queue.GetValues());

            queue.Enqueue(1);
            Assert.AreEqual("34567891", queue.GetValues());

            queue.Enqueue(2);
            Assert.AreEqual("345678912", queue.GetValues());
        }
    }
}
