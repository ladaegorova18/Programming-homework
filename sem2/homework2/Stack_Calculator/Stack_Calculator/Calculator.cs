using System;

namespace Stack_Calculator
{
    class Calculator
    {
        Stack stack = new Stack();
        char key = ' ';
        public Calculator(char key)
        {
            this.key = key;
        }

        private bool IsOperator(char symbol)
        {
            return symbol == '/' || symbol == '*' || symbol == '-' || symbol == '+';
        }

        public int Count(string input, IStackable stack)
        {
            foreach(char symbol in input)
            {
                if (Char.IsDigit(symbol))
                {
                    stack.Push(symbol);
                }
                else if (IsOperator(symbol) && stack.Size() >= 2)
                {
                    int secondNumber = (int)stack.Top() - '0';
                    stack.Pop();
                    int firstNumber = (int)stack.Top() - '0';
                    stack.Pop();
                    stack.Push(Operation(firstNumber, secondNumber, symbol));
                }
            }
            return stack.Top() - '0';
        }

        private char Operation(int firstNumber, int secondNumber, char symbol)
        {
            switch(symbol)
            {
                case '+':
                    {
                        return (char)(firstNumber + secondNumber + '0');
                    }
                case '-':
                    {
                        return (char)(firstNumber - secondNumber + '0');
                    }
                case '*':
                    {
                        return (char)(firstNumber * secondNumber + '0');
                    }
                case '/':
                    {
                        return (char)(firstNumber / secondNumber + '0');
                    }
                default:
                    {
                        return ' ';
                    }
            }
        }
    }
}
