using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericSet
{
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
            public Node leftChild { get; set; }

            /// <summary>
            /// right "child" of node
            /// </summary>
            public Node rightChild { get; set; }
        }

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
            if (root.Value.CompareTo(item) > 0 && root.leftChild != null)
            {
                AddNode(root.leftChild, item);
            }
            else if (root.Value.CompareTo(item) < 0 && root.rightChild != null)
            {
                AddNode(root.rightChild, item);
            }
            else
            {
                if (root.Value.CompareTo(item) > 0)
                {
                    root.leftChild = new Node(item);
                }
                else
                {
                    root.rightChild = new Node(item);
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
                    if (root.leftChild != null)
                    {
                        root = root.leftChild;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (root.Value.CompareTo(item) < 0)
                {
                    if (root.rightChild != null)
                    {
                        root = root.rightChild;
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
                    RemoveRecursion(root, cell);
                }
            }
        }

        /// <summary>
        /// checks if set is a proper subset of other
        /// </summary>
        /// <param name="other"> other set to check </param>
        /// <returns> true, if this set is a proper subset </returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (Count == 0 || other.Count() == 0)
            {
                return true;
            }
            foreach (var cell in this)
            {
                if (other.Contains(cell))
                {
                    continue;
                }
                else
                {
                    return false; //???????
                }
            }
            foreach (var cell in other)
            {
                if (Contains(cell))
                {
                    continue;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// checks if set is a proper superset
        /// </summary>
        /// <param name="other"> other set that can be a subset </param>
        /// <returns> true, if set is a proper superset </returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (Count == 0 || other.Count() == 0)
            {
                return true;
            }
            if (Count < other.Count())
            {
                return false;
            }
            var thisEnum = GetEnumerator();
            var otherEnum = GetEnumerator();
            while (!Equals(thisEnum.Current, otherEnum.Current))
            {
                thisEnum.MoveNext();
            }
            while (otherEnum.MoveNext())
            {
                thisEnum.MoveNext();
                if (!Equals(thisEnum.Current, otherEnum))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// if set is a subset
        /// </summary>
        /// <param name="other"> superset to check </param>
        /// <returns> true, if set is a superset </returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (count == 0)
            {
                return true;
            }
            foreach (var cell in this)
            {
                if (!other.Contains(cell))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// if set is a superset
        /// </summary>
        /// <param name="other"> subset to check </param>
        /// <returns> true, if set is a superset </returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (Count < other.Count())
            {
                return false;
            }
            foreach (var otherCell in other)
            {
                if (!Contains(otherCell))
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
            RemoveRecursion(root, item);
            return true;
        }

        private void RemoveRecursion(Node root, T item)
        {
            if (root.Value.CompareTo(item) > 0)
            {
                RemoveRecursion(root.leftChild, item);
            }
            else if (root.Value.CompareTo(item) < 0)
            {
                RemoveRecursion(root.rightChild, item);
            }
            else
            {
                if (root.leftChild == null && root.rightChild == null)
                {
                    root = null;
                    return;
                }
                else if (root.leftChild == null && root.rightChild != null)
                {
                    var temp = root.rightChild;
                    root = temp;
                    //root.Value = root.rightChild.Value;
                    //root.rightChild = root.rightChild.rightChild;
                    //root.leftChild = root.rightChild.leftChild;
                    return;
                }
                else if (root.leftChild != null && root.rightChild == null)
                {
                    root = root.leftChild;
                    return;
                }
                else
                {
                    root.Value = Maximum(root);
                    RemoveRecursion(root.leftChild, root.Value);
                }
            }
        }

        private T Maximum(Node root)
        {
            var temp = root;
            while (temp != null)
            {
                temp = temp.rightChild;
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
                    RemoveRecursion(root, cell);
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
                if (temp.rightChild != null)
                {
                    stack.Push(temp.rightChild);
                }
                if (temp.leftChild != null)
                {
                    stack.Push(temp.leftChild);
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

