using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stacks
{
    public class StackArray<T> : IEnumerable<T>
    {
        private T[] array = new T[2];
        int index = -1;

        public void Push(T item)
        {
            ExtendIfNeeded();
            array[++index] = item;
        }

        private void ExtendIfNeeded()
        {
            if (Count() >= array.Length)
            {
                var longer = new T[array.Length * 2];
                Array.Copy(array, longer, array.Length);
                array = longer;
            }
        }

        public T Pop()
        {
            AssertNotEmpty();
            return array[index--];
        }

        private void AssertNotEmpty()
        {
            if (index < 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
        }

        public T Peek()
        {
            AssertNotEmpty();
            return array[index];
        }

        public int Count()
        {
            return index + 1;
        }

        public void Clear()
        {
            index = -1;
        }

        /// <summary>
        /// In LIFO order.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            AssertNotEmpty();
            for (int i = index; i >= 0; i--)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
