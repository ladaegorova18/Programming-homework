using System;

namespace StackCalculator
{
    public interface IStack
    {
        int Pop();

        bool Push(int symbol);

        bool IsEmpty { get; }

        void Clear();

        int Size { get; set; }
    }
}
