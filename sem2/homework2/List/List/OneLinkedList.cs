using System;

namespace List
{
    class OneLinkedList
    {
        static int size = 0;
        static Node head = null;
        static Node tail = null;
        internal OneLinkedList()
        {
        }

        class Node
        {
            internal int value = 0;
            internal Node next = null;
            internal Node(int value)
            {
                this.value = value;
            }
        }

        private bool IsWrongPosition(int position) => position < 0;

        internal int Count() => size;

        internal bool isEmpty() => size == 0;

        internal bool Add(int data, int position)
        {
            if (IsWrongPosition(position))
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
                newElement.next = head;
                head = newElement;
            }
            else if (position >= size)
            {
                tail.next = newElement;
                tail = newElement;
            }
            else
            {
                var temp = head;
                Node prev = null;
                for (int i = 0; i < position; ++i)
                {
                    prev = temp;
                    temp = temp.next;
                }
                prev.next = newElement;
                newElement.next = temp;
            }
            ++size;
            return true;
        }

        internal bool Remove(int position)
        {
            if (IsWrongPosition(position) || isEmpty() || position >= size)
            {
                return false;
            }
            --size;
            if (position == 0)
            {
                head = head.next;
                return true;
            }
            var temp = head;
            Node prev = null;
            for (int i = 0; i < position; ++i)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == tail)
            {
                prev.next = null;
                tail = prev;
                return true;
            }
            prev.next = temp.next;
            return true;
        }

        private Node GetNode(int position)
        {
            var temp = head;
            for (int i = 0; i < position; ++i)
            {
                temp = temp.next;
            }
            return temp;
        }

        internal bool SetValue(int value, int position)
        {
            if (IsWrongPosition(position))
            {
                return false;
            }
            var temp = GetNode(position);
            temp.value = value;
            return true;
        }

        internal int GetValue(int position)
        {
            if (IsWrongPosition(position))
            {
                return -1;
            }
            var temp = GetNode(position);
            return temp.value;
        }

        internal void DeleteList()
        {
            head = null;
            tail = null;
            size = 0;
        }
    }
}


