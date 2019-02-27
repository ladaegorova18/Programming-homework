using System;

namespace Stack_Calculator
{
    public class StackArray : IStackable
    {
        const int MAX = 100;
        static int size = 0;
        static char[] array = new char[MAX];

        public StackArray()
        {
        }

        public int Size() => size;

        public bool isEmpty() => size == 0;

        public void Pop()
        {
            if (!isEmpty())
            {
                array[size - 1] = '\0';
            }
            --size;
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
            if (isEmpty()) return ' ';
            return array[size - 1];
        }
    }
}
