using System;

namespace Stack_Calculator
{
    public interface IStackable
    {
        void Pop();

        bool Push(char symbol);

        char Top();

        bool isEmpty();

        int Size();
    }
}
