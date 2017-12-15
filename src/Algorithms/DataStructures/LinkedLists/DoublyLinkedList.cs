using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedLists
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddLast(item);
        }

        private void AddFirst(T item)
        {
            var node = new DoublyLinkedListNode<T>(item);

            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }

            Count++;
        }

        private void AddLast(T item)
        {
            var node = new DoublyLinkedListNode<T>(item);
            if (Count == 0)
            {
                Head = Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
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

            var current = Head.Next;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    //skip current (foward)
                    current.Previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        Tail = current.Previous; // set tail if was end
                    }
                    else
                    {
                        //skip current (backward)
                        current.Next.Previous = current.Previous;
                    }
                    Count--;
                    return true;
                }

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
                Tail = Tail.Previous;
                Tail.Next = null;
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
                Head.Previous = null;
            }

            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
