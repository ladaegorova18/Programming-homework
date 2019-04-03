using System;

namespace StackCalculator
{
    public class StackArray : IStack
    {
        private const int MAX = 100;
        public int Size { get; set; } = 0;
        private int[] array = new int[MAX];
        public bool IsEmpty => Size == 0;

        public void Clear() => Size = 0;

        public int Pop()
        {
            if (!IsEmpty)
            {
                --Size;
                return array[Size];
            }
            return 0;
        }

        public bool Push(int symbol)
        {
            if (Size >= MAX)
            {
                return false;
            }
            array[Size] = symbol;
            ++Size;
            return true;
        }
    }
}
