using System;

namespace Stack_Calculator
{
    public class StackArray : IStack
    {
        public int Size() => size;

        public bool IsEmpty() => size == 0;

        public char Pop()
        {
            if (!IsEmpty())
            {
                --size;
                return array[size];
            }
            return '\0';
        }

        public bool Push(char symbol)
        {
            if (size >= MAX)
            {
                return false;
            }
            array[size] = symbol;
            ++size;
            return true;
        }

        public char Top()
        {
            if (IsEmpty()) return ' ';
            return array[size - 1];
        }

        public void Clear()
        {
            size = 0;
        }

        private const int MAX = 100;
        private int size = 0;
        private char[] array = new char[MAX];
    }
}
