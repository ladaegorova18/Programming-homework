using System;

namespace Stack_Calculator
{
    public class StackList : IStack
    {
        public int Size() => size;

        public bool IsEmpty() => size == 0;

        public char Pop()
        {
            if (!IsEmpty())
            {
                --size;
                var value = head.Value;
                head = head.Next;
                return value;
            }
            return '\0';
        }

        public bool Push(char symbol)
        {
            var data = new Node(symbol);
            data.Next = head;
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
            public char Value { get; set; }
            public Node Next { get; set; }
            public Node(char value)
            {
                Value = value;
            }
        }

        private int size = 0;
        private Node head = null;
    }
}
