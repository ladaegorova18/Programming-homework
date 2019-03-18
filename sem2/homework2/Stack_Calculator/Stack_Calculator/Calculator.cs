using System;

namespace Stack_Calculator
{
    public class Calculator
    {
        private bool IsOperator(char symbol)
        {
            return symbol == '/' || symbol == '*' || symbol == '-' || symbol == '+';
        }

        public int Count(string input, IStack stack)
        {
            foreach(char symbol in input)
            {
                if (Char.IsDigit(symbol))
                {
                    stack.Push(symbol);
                }
                else if (IsOperator(symbol) && stack.Size() >= 2)
                {
                    var secondNumber = (int)stack.Pop() - '0';
                    var firstNumber = (int)stack.Pop() - '0';
                    if (firstNumber < secondNumber && (symbol == '/' || symbol == '-'))
                        return -2;
                    stack.Push(Operation(firstNumber, secondNumber, symbol));
                }
            }
            if ((stack.IsEmpty() || stack.Size() > 1)) return -1;
            return stack.Pop() - '0';
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
