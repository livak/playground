using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedLists
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddLast(item);
        }

        private void AddFirst(T item)
        {
            var node = new LinkedListNode<T>(item);

            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }

            Count++;
        }

        private void AddLast(T item)
        {
            var node = new LinkedListNode<T>(item);
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            Count++;
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Remove first occurance of item in list. (From Head to Tail)
        /// </summary>
        /// <param name="item"></param>
        public bool Remove(T item)
        {
            if (Count == 0) return false;

            if (Head.Value.Equals(item)) // first or only one
            {
                RemoveFirst();
                return true;
            }

            var previous = Head;
            var current = Head.Next;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    previous.Next = current.Next; // skip current

                    if (previous.Next == null) // set tail if was end
                    {
                        Tail = previous;
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public void RemoveLast()
        {
            if (Count == 0) return;
            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                var current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }

                current.Next = null;
                Tail = current;
            }

            Count--;
        }

        public void RemoveFirst()
        {
            if (Count == 0) return;
            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Head = Head.Next;
            }

            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
