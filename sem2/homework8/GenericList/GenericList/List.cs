using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    public class List<T> : IList<T>
    {
        public int Count => count;
        private int count = 0;
        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public class Node
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
                var temp = Head;
                for (var i = 0; i < index; ++i)
                {
                    temp = temp.Next;
                }
                return temp.Value;
            }
            set
            {
                var temp = Head;
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
                Head = newNode;
                Tail = newNode;
                return;
            }
            Tail.Next = newNode;
            Tail = newNode;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var temp = Head;
            while (temp != null)
            {
                array[arrayIndex] = temp.Value;
                temp = temp.Next;
                ++arrayIndex;
            }
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            var newNode = new Node(item);
            if (count == 1)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            if (!CorrectIndex(index))
            {
                return; // может, бросать исключение?
            }
            var temp = Head;
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
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            if (count == 1)
            {
                Clear();
                return;
            }
            var temp = Head;
            Node previous = null;
            for (var position = 0; position < index; ++position)
            {
                previous = temp;
                temp = temp.Next;
            }
            previous.Next = temp.Next;
        }

        public ListEnum<T> GetEnumerator() => new ListEnum<T>(Head);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>)GetEnumerator();
    }
}
/*Переделать список на генерики. Список должен реализовывать интерфейс 
 * System.Collections.Generic.IList, в том числе иметь энумератор, чтобы можно было 
 * по нему ходить foreach.*/