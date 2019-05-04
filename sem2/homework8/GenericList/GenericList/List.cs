using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericList
{
    /// <summary>
    /// generic list: list that can contain various types
    /// </summary>
    /// <typeparam name="T"> type of data in list </typeparam>
    public class List<T> : IList<T>
    {
        /// <summary>
        /// amount of elements in list
        /// </summary>
        public int Count => count;

        private int count = 0;
        private Node head;
        private Node tail;

        /// <summary>
        /// node - element in list
        /// </summary>
        private class Node
        {
            /// <summary>
            /// empty constructor of node
            /// </summary>
            public Node() { }

            /// <summary>
            /// constructor that gives node a definite value
            /// </summary>
            /// <param name="value"> value to create node </param>
            public Node(T value)
            {
                Value = value;
            }

            /// <summary>
            /// data in node 
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// next node
            /// </summary>
            public Node Next { get; set; }
        }

        /// <summary>
        /// current node in list
        /// </summary>
        /// <param name="index"> index to find node </param>
        /// <returns> T value of node </returns>
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
                temp.Value = value;
            }
        }

        /// <summary>
        /// if list is read only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// adds value to list
        /// </summary>
        /// <param name="item"> value to add </param>
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

        /// <summary>
        /// makes list empty
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// finds definite value in list
        /// </summary>
        /// <param name="item"> value to seek </param>
        /// <returns> is value in list </returns>
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

        /// <summary>
        /// copies list to array
        /// </summary>
        /// <param name="array"> array to copy in </param>
        /// <param name="arrayIndex"> start index of array to copy in </param>
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

        /// <summary>
        /// finds index of definite value in list
        /// </summary>
        /// <param name="item"> value to seek </param>
        /// <returns> index of value </returns>
        public int IndexOf(T item)
        {
            if (!Contains(item))
            {
                throw new ArgumentException("Значения нет в списке!");
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

        /// <summary>
        /// inserts value to definite place in list
        /// </summary>
        /// <param name="index"> index to insert </param>
        /// <param name="item"> value to add </param>
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
                return;
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

        /// <summary>
        /// removes value from list
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

        /// <summary>
        /// removes value from definite place
        /// </summary>
        /// <param name="index"> index of node to remove </param>
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

        /// <summary>
        /// IEnumerator - a rule to go through list
        /// </summary>
        public IEnumerator<T> GetEnumerator() => GetEnum();

        IEnumerator IEnumerable.GetEnumerator() => GetEnum();

        /// <summary>
        /// creates ListEnum - object of user enumerator class 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnum() => new ListEnum(head);

        /// <summary>
        /// user enumerator class to go through list
        /// </summary>
        private class ListEnum : IEnumerator<T>
        {
            private Node temp = new Node();
            private Node head;

            /// <summary>
            /// constructor of ListEnum - gives head of list to enumerator class
            /// </summary>
            /// <param name="head"> head of list </param>
            public ListEnum(Node head)
            {
                this.head = head;
                temp.Next = head;
            }

            /// <summary>
            /// value of current node
            /// </summary>
            public T Current => temp.Value;

            object IEnumerator.Current => temp;

            /// <summary>
            /// disposes node
            /// </summary>
            public void Dispose() { }

            /// <summary>
            /// returns next node
            /// </summary>
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