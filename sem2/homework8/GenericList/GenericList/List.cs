using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    public class List<T> : IList<T>
    {
        public int Count => count;
        private int count = 0;
        private Node head;
        private Node tail;

        private class Node
        {
            public Node() { }

            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
        }

        public T this[int index] {

            get
            {
                var temp = head;
                for (var i = 0; i < index; ++i)
                {
                    temp = temp.Next;
                }
                return temp.Value;
            }
            set
            {
                var temp = head;
                for (var i = 0; i < index; ++i)
                {
                    temp = temp.Next;
                }
                temp.Value = value; //??
            }
        }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            var newNode = new Node(item);
            ++count;
            if (count == 1)
            {
                head = newNode;
                tail = newNode;
                return;
            }
            tail.Next = newNode;
            tail = newNode;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            var temp = head;
            while (temp != null)
            {
                if (Equals(temp.Value, item))
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var temp = head;
            while (temp != null)
            {
                array[arrayIndex] = temp.Value;
                temp = temp.Next;
                ++arrayIndex;
            }
        }

        public int IndexOf(T item)
        {
            if (!Contains(item))
            {
                return -1; //??
            }
            var temp = head;
            var index = 0;
            while (temp != null)
            {
                if (Equals(temp.Value, item))
                {
                    return index;
                }
                temp = temp.Next;
                ++index;
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            var newNode = new Node(item);
            if (count == 1)
            {
                head = newNode;
                tail = newNode;
                return;
            }
            if (!CorrectIndex(index))
            {
                return; // может, бросать исключение?
            }
            var temp = head;
            Node previous = null;
            for (var i = 0; i < index; ++i)
            {
                previous = temp;
                temp = temp.Next;
            }
            previous.Next = newNode;
            newNode.Next = temp;
        }

        private bool CorrectIndex(int index) => index > 0 && index <= count;

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }
            --count;
            if (Equals(head.Value, item))
            {
                head = head.Next;
                return true;
            }
            var temp = head;
            Node previous = null;
            while (temp != null)
            {
                previous = temp;
                temp = temp.Next;
                if (Equals(temp.Value, item))
                {
                    previous.Next = temp.Next;
                    return true;
                }
            }
            return true;
        }

        public void RemoveAt(int index)
        {
            --count;
            if (count == 1)
            {
                Clear();
                return;
            }
            var temp = head;
            Node previous = null;
            for (var position = 0; position < index; ++position)
            {
                previous = temp;
                temp = temp.Next;
            }
            previous.Next = temp.Next;
        }

        public ListEnum GetEnumerator() => new ListEnum(head);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        private class ListEnum : IEnumerator<T>
        {
            private Node temp = new Node();
            private Node head;  

            public ListEnum(Node head)
            {
                this.head = head;
                temp.Next = head;
            }

            public T Current => temp.Value;

            object IEnumerator.Current => temp;

            public void Dispose() { }

            public bool MoveNext()
            {
                temp = temp.Next;
                if (temp != null)
                {
                    return true;
                }
                return false;
            }

            void IEnumerator.Reset() => temp.Next = head;
        }
    }
}

/*Переделать список на генерики. Список должен реализовывать интерфейс 
 * System.Collections.Generic.IList, в том числе иметь энумератор, чтобы можно было 
 * по нему ходить foreach.*/