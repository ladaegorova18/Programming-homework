using System;
using System.Collections.Generic;
using System.Collections;

namespace GenericList
{
    public class ListEnum<T> : IEnumerator<T>
    {
        private List<T>.Node temp = new List<T>.Node();
        private List<T>.Node head;

        public ListEnum(List<T>.Node head)
        {
            this.head = head;
            temp.Next = head;
        }

        public T Current => temp.Value;

        object IEnumerator.Current => temp;

        public void Dispose(){ }

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
