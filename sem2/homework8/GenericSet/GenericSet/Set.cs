using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericSet
{
    /// <summary>
    /// Set to collect generic data
    /// </summary>
    /// <typeparam name="T"> type to collect </typeparam>
    public class Set<T> : ISet<T> where T : IComparable<T>
    {
        private Node root;
        private int count = 0;

        /// <summary>
        /// amount of elements in set
        /// </summary>
        public int Count => count;

        private class Node
        {
            /// <summary>
            /// constructor of node
            /// </summary>
            /// <param name="value"> value of new node </param>
            public Node(T value) => Value = value;

            /// <summary>
            /// value of node
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// left "child" of node
            /// </summary>
            public Node Left { get; set; }

            /// <summary>
            /// right "child" of node
            /// </summary>
            public Node Right { get; set; }
        }

        /// <summary>
        /// if set is read only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// adding new value to set
        /// </summary>
        /// <param name="item"> value to add </param>
        /// <returns> if adding was successful </returns>
        public bool Add(T item)
        {
            if (Contains(item))
            {
                return false;
            }
            ++count;
            var node = new Node(item);
            if (count == 1)
            {
                root = node;
                return true;
            }
            AddNode(root, item);
            return true;
        }

        private void AddNode(Node root, T item)
        {
            if (root.Value.CompareTo(item) > 0 && root.Left != null)
            {
                AddNode(root.Left, item);
            }
            else if (root.Value.CompareTo(item) < 0 && root.Right != null)
            {
                AddNode(root.Right, item);
            }
            else
            {
                if (root.Value.CompareTo(item) > 0)
                {
                    root.Left = new Node(item);
                }
                else
                {
                    root.Right = new Node(item);
                }
            }
        }

        /// <summary>
        /// makes set empty
        /// </summary>
        public void Clear()
        {
            root = null;
            count = 0;
        }

        /// <summary>
        /// finds value in set
        /// </summary>
        /// <param name="item"> value to seek </param>
        /// <returns> value exists </returns>
        public bool Contains(T item)
        {
            if (count == 0)
            {
                return false;
            }
            return ContainsNode(root, item);
        }

        private bool ContainsNode(Node root, T item)
        {
            while (true)
            {
                if (root.Value.CompareTo(item) > 0)
                {
                    if (root.Left != null)
                    {
                        root = root.Left;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (root.Value.CompareTo(item) < 0)
                {
                    if (root.Right != null)
                    {
                        root = root.Right;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// copies set to array
        /// </summary>
        /// <param name="array"> array to copy </param>
        /// <param name="arrayIndex"> start index of array to copy </param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var index = arrayIndex;
            foreach (var cell in this)
            {
                array[index] = cell;
                ++index;
            }
        }

        /// <summary>
        /// removes definite collection from set
        /// </summary>
        /// <param name="other"> collection to remove </param>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var otherCell in other)
            {
                Remove(otherCell);
            }
        }

        /// <summary>
        /// removes values which are not contained in definite set
        /// </summary>
        /// <param name="other"> set to intersect with </param>
        public void IntersectWith(IEnumerable<T> other)
        {
            foreach (var cell in this)
            {
                if (!other.Contains(cell))
                {
                    Remove(cell);
                }
            }
        }

        /// <summary>
        /// checks if set is a proper subset of other
        /// </summary>
        /// <param name="other"> other set to check </param>
        /// <returns> true, if this set is a proper subset </returns>
        public bool IsProperSubsetOf(IEnumerable<T> other) => FirstProperSubsetOfSecond(this, other);

        /// <summary>
        /// checks if set is a proper superset
        /// </summary>
        /// <param name="other"> other set that can be a subset </param>
        /// <returns> true, if set is a proper superset </returns>
        public bool IsProperSupersetOf(IEnumerable<T> other) => FirstProperSubsetOfSecond(other, this);

        private bool FirstProperSubsetOfSecond(IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first.Count() == 0 || second.Count() == 0)
            {
                return true;
            }
            if (((Set<T>)first).IsSubsetOf(second) && first.Count() < second.Count())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// if set is a subset
        /// </summary>
        /// <param name="other"> superset to check </param>
        /// <returns> true, if set is a superset </returns>
        public bool IsSubsetOf(IEnumerable<T> other) => FirstSubsetOfSecond(this, other);

        /// <summary>
        /// if set is a superset
        /// </summary>
        /// <param name="other"> subset to check </param>
        /// <returns> true, if set is a superset </returns>
        public bool IsSupersetOf(IEnumerable<T> other) => FirstSubsetOfSecond(other, this);

        private bool FirstSubsetOfSecond(IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first.Count() == 0)
            {
                return true;
            }
            foreach (var cell in this)
            {
                if (!second.Contains(cell))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// truth, if there are at least one common element
        /// </summary>
        /// <param name="other"> other set </param>
        /// <returns> true, if sets overlap</returns>
        public bool Overlaps(IEnumerable<T> other)
        {
            foreach (var cell in this)
            {
                if (other.Contains(cell))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// removes value from set
        /// </summary>
        /// <param name="item"> value to remove </param>
        /// <returns> success of removing </returns>
        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            --count;
            root = RemoveRecursion(root, item);
            return true;
        }

        private Node RemoveRecursion(Node temp, T item)
        {
            if (temp.Value.CompareTo(item) > 0)
            {
                temp.Left = RemoveRecursion(temp.Left, item);
            }
            else if (temp.Value.CompareTo(item) < 0)
            {
                temp.Right = RemoveRecursion(temp.Right, item);
            }
            else
            {
                if (temp.Left == null && temp.Right == null)
                {
                    return null;
                }
                else if (temp.Left == null && temp.Right != null)
                {
                    return temp.Right;
                }
                else if (temp.Left != null && temp.Right == null)
                {
                    return temp.Left;
                }
                else
                {
                    temp.Value = Maximum(temp.Left);
                    temp.Left = RemoveRecursion(temp.Left, temp.Value);
                }
            }
            return temp;
        }

        private T Maximum(Node root)
        {
            var temp = root;
            while (temp.Right != null)
            {
                temp = temp.Right;
            }
            return temp.Value;
        }

        /// <summary>
        /// checks if two sets are equal
        /// </summary>
        /// <param name="other"> other set </param>
        /// <returns> true, if sets are equal </returns>
        public bool SetEquals(IEnumerable<T> other)
        {
            foreach (var cell in this)
            {
                if (!other.Contains(cell))
                {
                    return false;
                }
            }
            foreach (var cell in other)
            {
                if (!Contains(cell))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// makes set of unrepeating elements in both sets
        /// </summary>
        /// <param name="other"> other set </param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            foreach (var cell in other)
            {
                if (Contains(cell))
                {
                    Remove(cell);
                }
                else
                {
                    Add(cell);
                }
            }
        }

        /// <summary>
        /// unites two sets
        /// </summary>
        /// <param name="other"> second set </param>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var cell in other)
            {
                Add(cell);
            }
        }

        void ICollection<T>.Add(T item) => Add(item);

        /// <summary>
        /// pre-order tree traversal
        /// </summary>
        /// <returns> enumerator object </returns>
        public IEnumerator<T> PreOrder()
        {
            if (root == null)
            {
                yield break;
            }
            var stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var temp = stack.Pop();
                yield return temp.Value;
                if (temp.Right != null)
                {
                    stack.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    stack.Push(temp.Left);
                }
            }
        }

        /// <summary>
        /// gets enumerator to traverse tree
        /// </summary>
        /// <returns> enumerator object </returns>
        public IEnumerator<T> GetEnumerator() => PreOrder();

        IEnumerator IEnumerable.GetEnumerator() => PreOrder();
    }
}

/*Создать генерик-класс, реализующий АТД "Множество". 
 * Множество должно реализовывать интерфейс System.Collections.Generic.ISet. 
 * Ожидается асимптотическая трудоёмкость основных операций не хуже логарифмической.*/

