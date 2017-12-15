using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queues
{
    public class QueueLinkedList<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> linkedList = new LinkedList<T>();

        public void Enqueue(T item)
        {
            linkedList.AddLast(item);
        }

        public T Dequeue()
        {
            var item = Peek();
            linkedList.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (linkedList.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return linkedList.First.Value;
        }

        public int Count()
        {
            return linkedList.Count;
        }

        public void Clear()
        {
            linkedList.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
