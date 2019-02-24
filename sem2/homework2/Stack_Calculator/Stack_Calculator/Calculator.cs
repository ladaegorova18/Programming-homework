using System;

namespace Stack_Calculator
{
    class Calculator
    {
        private bool IsOperator(char symbol)
        {
            return symbol == '/' || symbol == '*' || symbol == '-' || symbol == '+';
        }

        private Calculator CreateStack(char key)
        {
            if (key == '1')
            {
                var stack = new StackArray();
                return stack;
            }
            else
            {
                var stack = new StackList();
                return stack;
            }
        }
        public int Count(string input, char key)
        {
            var stack = CreateStack(key);

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
