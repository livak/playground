using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queues
{
    public class PriorityQueueLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly LinkedList<T> linkedList = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if (linkedList.Count == 0)
            {
                linkedList.AddLast(item);
            }
            else
            {
                var current = linkedList.First; // first has biggest priority
                // while current priority is bigger take next (example: 3.CompareTo(2) = 1)
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    linkedList.AddLast(item);
                }
                else
                {
                    linkedList.AddBefore(current, item);
                }
            }
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
