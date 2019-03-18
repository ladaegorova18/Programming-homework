using System;

namespace List
{
    public class OneLinkedList
    { 
        class Node
        {
            public string Value { get; set; } = "";
            public Node Next { get; set; }
            public Node (string value)
            {
                Value = value;
            }
        }

        private bool IsWrongPosition(int position, int size) => position < 0 || position > size;

        public int Count() => size;

        public bool IsEmpty() => size == 0;

        public bool Add(string data, int position)
        {
            if (IsWrongPosition(position, size))
            {
                return false;
            }
            var newElement = new Node(data);
            if (size == 0)
            {
                head = newElement;
                tail = newElement;
            }
            else if (position == 0)
            {
                newElement.Next = head;
                head = newElement;
            }
            else if (position == size)
            {
                tail.Next = newElement;
                tail = newElement;
            }
            else
            {
                var temp = head;
                Node prev = null;
                for (int i = 0; i < position; ++i)
                {
                    prev = temp;
                    temp = temp.Next;
                }
                prev.Next = newElement;
                newElement.Next = temp;
            }
            ++size;
            return true;
        }

        public bool Remove(int position)
        {
            if (IsWrongPosition(position, size) || IsEmpty() || position == size)
            {
                return false;
            }
            --size;
            if (position == 0)
            {
                head = head.Next;
                return true;
            }
            var temp = head;
            Node prev = null;
            for (int i = 0; i < position; ++i)
            {
                prev = temp;
                temp = temp.Next;
            }
            if (temp == tail)
            {
                prev.Next = null;
                tail = prev;
                return true;
            }
            prev.Next = temp.Next;
            return true;
        }

        private Node GetNode(int position)
        {
            var temp = head;
            for (int i = 0; i < position; ++i)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public bool SetValue(string value, int position)
        {
            if (IsWrongPosition(position, size))
            {
                return false;
            }
            var temp = GetNode(position);
            temp.Value = value;
            return true;
        }

        public string GetValue(int position)
        {
            if (IsWrongPosition(position, size))
            {
                return "";
            }
            var temp = GetNode(position);
            return temp.Value;
        }

        public void Clear()
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


