using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable<T>
    {
        BinaryTreeNode<T> head;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (head == null)
            {
                head = new BinaryTreeNode<T>(item);
            }
            else
            {
                AddToRecursive(item, head);
            }

            Count++;
        }

        private static void AddTo(T item, BinaryTreeNode<T> node)
        {
            while (true)
            {
                if (node.Value.CompareTo(item) > 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new BinaryTreeNode<T>(item);
                        return;
                    }
                    else
                    {
                        node = node.Left;
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTreeNode<T>(item);
                        return;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }
            }
        }

        private static void AddToRecursive(T item, BinaryTreeNode<T> node)
        {
            BinaryTreeNode<T> next = null;

            if (node.Value.CompareTo(item) > 0)
            {
                next = node.Left;
                if (next == null)
                {
                    node.Left = new BinaryTreeNode<T>(item);
                    return;
                }
            }
            else
            {
                next = node.Right;
                if (next == null)
                {
                    node.Right = new BinaryTreeNode<T>(item);
                    return;
                }
            }

            AddToRecursive(item, next);
        }

        public void Clear()
        {
            Count = 0;
            head = null;
        }

        public bool Contains(T item)
        {
            return FindWithParent(item, out BinaryTreeNode<T> parent) != null;
        }

        public BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            parent = null;
            var current = head;
            while (current != null)
            {
                int result = current.Value.CompareTo(value);
                if (result == 0)
                {
                    return current;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    parent = current;
                    current = current.Right;
                }
            }

            return null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return InOrderRecursive(head).GetEnumerator();

            return InOrderTraversal().GetEnumerator();

            //var l = new List<T>();
            //DoInOrderRecursive(head, (a) => { l.Add(a); });
            //return l.GetEnumerator();
        }

        public void DoInOrderRecursive(BinaryTreeNode<T> node, Action<T> a)
        {
            if (node != null)
            {
                DoInOrderRecursive(node.Left, a);
                a(node.Value);
                DoInOrderRecursive(node.Right, a);
            }
        }

        private IEnumerable<T> InOrderTraversal()
        {
            var stack = new Stack<BinaryTreeNode<T>>();
            var current = head;

            if (head != null)
            {
                var goLeft = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeft == true)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeft = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeft = false;
                    }

                }
            }
        }

        public IEnumerable<T> InOrderRecursive(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                foreach (var i in InOrderRecursive(node.Left))
                {
                    yield return i;
                }

                yield return node.Value;

                foreach (var i in InOrderRecursive(node.Right))
                {
                    yield return i;
                }
            }
        }

        public bool Remove(T item)
        {
            var nodeToRemove = FindWithParent(item, out BinaryTreeNode<T> parent);

            // (1) not exist
            if (nodeToRemove == null)
            {
                return false;
            }

            Count--;
            var rightChild = nodeToRemove.Right;
            var leftChild = nodeToRemove.Left;
            BinaryTreeNode<T> toPromote = null;

            // (2) terminal node (leaf) - just remove
            if (rightChild == null && leftChild == null) 
            {
                ReplaceNodeOnParent(parent, nodeToRemove, toAdd: null);
            }
            // (3) not terminal nodes
            // (3.1) no right child (left replaces node - promote left)
            else if (rightChild == null)
            {
                toPromote = leftChild;
                ReplaceNodeOnParent(parent, nodeToRemove, toPromote);
            }
            // (3.2) right child doesn't have left child  (right replaces node - promote right)
            else if (rightChild.Left == null)
            {
                toPromote = rightChild;
                ReplaceNodeOnParent(parent, nodeToRemove, toPromote);
                rightChild.Left = leftChild; // connect left child
            }
            // (3.3) right child has left child (promote most left child from right child)
            else
            {
                var leftMost = rightChild.Left;
                var leftMostParent = rightChild;
                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                toPromote = leftMost;
                ReplaceNodeOnParent(parent, nodeToRemove, toPromote);

                // connect leftMost right node to parent
                leftMostParent.Left = leftMost.Right;

                // connect left and right to promoted node (get children from removed node)
                toPromote.Left = nodeToRemove.Left;
                toPromote.Right = nodeToRemove.Right;
            }

            return true;
        }

        private void ReplaceNodeOnParent(BinaryTreeNode<T> parent, BinaryTreeNode<T> toRemove, BinaryTreeNode<T> toAdd)
        {
            if (parent == null)
            {
                head = toAdd;
            }
            else
            {
                if (parent.Left == toRemove)
                {
                    parent.Left = toAdd;
                }
                else
                {
                    parent.Right = toAdd;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
