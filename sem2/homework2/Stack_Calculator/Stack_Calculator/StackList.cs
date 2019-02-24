using System;

namespace Stack_Calculator
{
    class StackList : Calculator , IStackable
    {
        private static int size = 0;
        private static Node head = null;
        private static Node tail = null;
        public StackList()
        {
        }

        public int Size() => size;

        public bool isEmpty() => size == 0;

        public void Pop()
        {
            if (isEmpty()) return;
            var temp = head;
            Node prev = null;
            for (int i = 1; i < size; ++i)
            {
                prev = temp;
                temp = temp.next;
            }
            temp = null;
            tail = prev;
            --size;
        }

        public bool Push(char symbol)
        {
            var data = new Node(symbol);
            if (size == 0)
            {
                head = data;
                tail = data;
            }
            else
            {
                tail.next = data;
                tail = data;
            }
            ++size;
            return true;
        }

        public char Top()
        {
            if (!isEmpty()) return tail.value;
            return ' ';
        }

        class Node
        {
            public char value = ' ';
            public Node next = null;
            public Node(char value)
            {
                this.value = value;
            }
        }
    }
}
