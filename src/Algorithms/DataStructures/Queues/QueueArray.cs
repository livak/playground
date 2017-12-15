using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Queues
{
    public class QueueArray<T> : IEnumerable<T>
    {
        private T[] array = new T[0];

        int count = 0;
        public int head = 0;
        public int tail = -1;

        public void Enqueue(T item)
        {
            ExtendIfNeeded();
            count++;
            tail = (tail + 1) % array.Length;
            array[tail] = item;
        }

        public void ExtendIfNeeded()
        {
            if (array.Length == 0)
            {
                array = new T[2];
            }
            else if (count >= array.Length)
            {
                var a = new T[array.Length * 2];

                var current = head;
                for (int i = 0; i < count; i++)
                {
                    a[i] = array[(current + i) % count];
                }

                // This can be used but for loop is more readable
                //Array.Copy(array, head, a, 0, array.Length - head);
                //Array.Copy(array, 0, a, array.Length - head, head);

                head = 0;
                tail = array.Length - 1;
                array = a;
            }
        }

        public T Dequeue()
        {
            var item = Peek();
            head = (head + 1) % array.Length;
            count--;
            return item;
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return array[head];
        }

        public int Count()
        {
            return count;
        }

        public void Clear()
        {
            count = 0;
            head = 0;
            tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var start = head;
            for (int i = 0; i < count; i++)
            {
                yield return array[(start + i) % array.Length];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
