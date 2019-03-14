using System;

namespace Stack_Calculator
{
    public interface IStack
    {
        char Pop();

        bool Push(char symbol);

        bool IsEmpty();

        int Size();

        void Clear();
    }
}
