using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSet
{
    public class Set<T> : ISet<T>
    {
        private Node root;
        private int count = 0;

        private class Node : IComparable<T>
        {
            public Node(T value) => Value = value;
            public T Value { get; private set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }

            public int CompareTo(T other) => CompareTo(other);
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public bool Add(T item)
        {
            var node = new Node(item);
            ++count;
            if (count == 1)
            {
                root = node;
                return true;
            }
            var current = root;
            Node parent = null;
            while (current != null)
            {
                parent = current;
                if (CompareTo(current.Value))
            }
            return true;
        }

        //if (Contains(item))
        //{
        //    return false;
        //}


        public void Clear()
        {
            root = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            if (Equals(root.Value, item))
            {
                return true;
            }
            return ContainsNode(root, item);
        }

        private bool ContainsNode(Node root, T item)
        {
            if (root.leftChild != null)
            {
                if (Equals(root.leftChild.Value, item))
                {
                    return true;
                }
                return ContainsNode(root.leftChild, item);
            }
            if (root.rightChild != null)
            {
                if (Equals(root.rightChild.Value, item))
                {
                    return true;
                }
                return ContainsNode(root.rightChild, item);
            }
            return false;
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

        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }

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

