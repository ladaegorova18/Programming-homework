using System;

namespace Stack_Calculator
{
    public class StackList : IStackable
    {
        static int size = 0;
        static Node head = null;
        public StackList()
        {
        }

        public int Size() => size;

        public bool isEmpty() => size == 0;

        public void Pop()
        {
            if (isEmpty()) return;
            head = head.next;
            --size;
        }

        public bool Push(char symbol)
        {
            var data = new Node(symbol);
            data.next = head;
            head = data;
            ++size;
            return true;
        }

        public char Top()
        {
            if (!isEmpty()) return head.value;
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
