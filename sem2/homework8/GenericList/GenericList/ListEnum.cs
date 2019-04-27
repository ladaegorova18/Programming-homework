using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class ListEnum : IEnumerator<T>
    {
        private Node temp = new Node();
        private int position = -1;
        private List<object> list;

        public ListEnum(List<object> list)
        {
            this.list = list;
        }

        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
           
        bool IEnumerator.MoveNext()
        {
            ++position;
            temp = temp.Next;
            return (position < count);
        }

        void IEnumerator.Reset() => temp.Next = head;
    }
}
