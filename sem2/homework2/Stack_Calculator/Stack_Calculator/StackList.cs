using System;

namespace Stack_Calculator
{
    public class StackList : IStack
    {
        static int size = 0;
        static Node head = null;
        public StackList()
        {
        }

        public int Size() => size;

        public bool IsEmpty() => size == 0;

        public char Pop()
        {
            if (!IsEmpty())
            {
                --size;
                var value = head.value;
                head = head.next;
                return value;
            }
            return '\0';
        }

        public bool Push(char symbol)
        {
            var data = new Node(symbol);
            data.next = head;
            head = data;
            ++size;
            return true;
        }

        public void Clear()
        {
            size = 0;
            if (!IsEmpty()) head = null;
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
