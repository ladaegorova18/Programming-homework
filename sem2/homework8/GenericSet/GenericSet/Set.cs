using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var node = new Node(item);
            ++count;
            if (count == 1)
            {
                root = node;
                return true;
            }
            if (Contains(item))
            {
                return false;
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

        public void Clear()
        {
            root = null;
            count = 0;
        }

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

        public void CopyTo(T[] array, int arrayIndex)
        {
            var temp = root;
            var index = arrayIndex;

        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
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
                    root = root.rightChild;
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

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnum() => new SetEnum(root);

        public IEnumerator<T> GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class SetEnum : IEnumerator<T>
        {
            private Node root;
            private Node temp;

            public SetEnum(Node root)
            {
                this.root = root;
                temp = root;
            }

            public T Current => temp.Value;

            object IEnumerator.Current => temp;

            public void Dispose() { }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                temp.leftChild = root;
            }
        }
    }
}

/*Создать генерик-класс, реализующий АТД "Множество". 
 * Множество должно реализовывать интерфейс System.Collections.Generic.ISet. 
 * Ожидается асимптотическая трудоёмкость основных операций не хуже логарифмической.*/

