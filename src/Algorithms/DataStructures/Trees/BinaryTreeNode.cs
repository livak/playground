using System;
using System.Diagnostics;

namespace DataStructures.Trees
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class BinaryTreeNode<T> : IComparable<T>
        where T : IComparable<T>
    {
        public T Value { get; private set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay =>
            $"{Value} (left: {(Left == null ? "null" : Left.Value.ToString())}, right: {(Right == null ? "null" : Right.Value.ToString())})";
    }
}
