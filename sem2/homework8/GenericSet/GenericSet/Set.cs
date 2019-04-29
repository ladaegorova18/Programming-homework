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

        private class Node
        {
            public Node(T value) => Value = value;
            public T Value { get; private set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public bool Add(T item)
        {
            var newNode = new Node(item);
            ++count;
            if (count == 1)
            {
                root = newNode;
                return true;
            }
            if (Contains(item))
            {
                return false;
            }
            AddData(root, item);
            return true;
        }

        private void AddData(Node root, T item)
        {
            if (root.leftChild == null)
            {
                AddData(root.leftChild, item);
            }
            else
            {
                AddData(root.rightChild, item);
            }
            root = new Node(item);
        }

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
            throw new NotImplementedException();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        private SetEnum GetEnumer() => new SetEnum();

        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)GetEnumer();

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
            throw new NotImplementedException();
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

        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumer();
    }
}

/*Создать генерик-класс, реализующий АТД "Множество". 
 * Множество должно реализовывать интерфейс System.Collections.Generic.ISet. 
 * Ожидается асимптотическая трудоёмкость основных операций не хуже логарифмической.*/

