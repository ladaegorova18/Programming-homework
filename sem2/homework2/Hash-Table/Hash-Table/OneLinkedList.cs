using System;

namespace Hash_Table
{
    class OneLinkedList
    {
        class Node
        {
            public string Value { get; set; } = "";
            public Node Next { get; set; }
            public Node(string value)
            {
                Value = value;
            }
        }

        private bool IsWrongPosition(int position, int size) => position < 0 || position > size;

        public int Count() => size;

        public bool isEmpty() => size == 0;

        public bool Add(string data)
        {
            var newElement = new Node(data);
            if (isEmpty())
            {
                head = newElement;
                tail = newElement;
            }
            else
            {
                tail.Next = newElement;
                tail = newElement;
            }
            ++size;
            return true;
        }

        public bool Remove(string data)
        {
            --size;
            if (data == head.Value && size == 0)
            {
                head = null;
                tail = null;
            }
            else
            {
                var temp = head;
                Node prev = null;
                while (temp.Value != data || temp.Next != null)
                {
                    prev = temp;
                    temp = temp.Next;
                }
                if (temp == tail)
                {
                    if (temp.Value != data)
                    {
                        return false;
                    }
                    prev.Next = null;
                    tail = prev;
                    return true;
                }
                prev.Next = temp.Next;
            }
            return true;
        }

        public bool Find(string data)
        {
            if (size == 0)
            {
                return false;
            }
            var temp = head;
            while (temp.Value != data)
            {
                if (temp.Next != null)
                {
                    temp = temp.Next;
                }
                else
                {
                    break;
                }
            }
            if (temp.Value != data)
            {
                return false;
            }
            return true;
        }

        public void ClearList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        private int size = 0;
        private Node head = null;
        private Node tail = null;
    }
}


