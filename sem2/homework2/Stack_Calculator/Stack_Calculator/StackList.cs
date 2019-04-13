using System;

namespace StackCalculator
{
    public class StackList : IStack
    {
        public int Size { get; set; } = 0;
        private Node head = null;
        public bool IsEmpty => Size == 0;

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node(int value)
            {
                Value = value;
            }
        }

        public int Pop()
        {
            if (!IsEmpty)
            {
                --Size;
                var value = head.Value;
                head = head.Next;
                return value;
            }
            return 0;
        }

        public bool Push(int symbol)
        {
            var data = new Node(symbol);
            data.Next = head;
            head = data;
            ++Size;
            return true;
        }

        public void Clear()
        {
            Size = 0;
            if (!IsEmpty)
            {
                head = null;
            }
        }
    }
}
