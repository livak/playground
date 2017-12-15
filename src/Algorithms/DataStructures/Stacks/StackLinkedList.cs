using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Stacks
{
    public class StackLinkedList<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> linkedList = new LinkedList<T>();

        public void Push(T item)
        {
            linkedList.AddFirst(item);
        }

        public T Pop()
        {
            var ret = Peek();
            linkedList.RemoveFirst();
            return ret;
        }

        public T Peek()
        {
            if (linkedList.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
            var ret = linkedList.First.Value;
            return ret;
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
