using System;

namespace Hash_Table
{
    class OneLinkedList
    {
        int size = 0;
        Node head = null;
        Node tail = null;
        public OneLinkedList()
        {
        }

        class Node
        {
            public string value = "";
            public Node next = null;
            public Node(string value)
            {
                this.value = value;
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
                tail.next = newElement;
                tail = newElement;
            }
            ++size;
            return true;
        }

        public bool Remove(string data)
        {
            --size;
            if (data == head.value && size == 0)
            {
                head = null;
                tail = null;
            }
            else
            {
                var temp = head;
                Node prev = null;
                while (temp.value != data || temp.next != null)
                {
                    prev = temp;
                    temp = temp.next;
                }
                if (temp == tail)
                {
                    if (temp.value != data)
                    {
                        return false;
                    }
                    prev.next = null;
                    tail = prev;
                    return true;
                }
                prev.next = temp.next;
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
            while (temp.value != data)
            {
                if (temp.next != null)
                {
                    temp = temp.next;
                }
                else
                {
                    break;
                }
            }
            if (temp.value != data)
            {
                return false;
            }
            return true;
        }

        public void DeleteList()
        {
            head = null;
            tail = null;
            size = 0;
        }
    }
}


