using System;

namespace StackCalculator
{
    public class Calculator
    {
        private bool IsOperator(char symbol) => symbol == '/' || symbol == '*' || symbol == '-' || symbol == '+';

        public int Count(string input, IStack stack)
        {
            foreach (char symbol in input)
            {
                if (Char.IsDigit(symbol))
                {
                    stack.Push(symbol - '0');
                }
                else if (IsOperator(symbol) && stack.Size >= 2)
                {
                    var secondNumber = stack.Pop();
                    var firstNumber = stack.Pop();
                    if ((firstNumber < secondNumber) && (symbol == '/' || symbol == '-'))
                    {
                        return -2;
                    }
                    stack.Push(Operation(firstNumber, secondNumber, symbol));
                }
            }
            if ((stack.IsEmpty || stack.Size > 1))
            {
                return -1;
            }
            return stack.Pop();
        }

        private int Operation(int firstNumber, int secondNumber, char symbol)
        {
            switch (symbol)
            {
                case '+':
                    {
                        return firstNumber + secondNumber;
                    }
                case '-':
                    {
                        return firstNumber - secondNumber;
                    }
                case '*':
                    {
                        return firstNumber * secondNumber;
                    }
                case '/':
                    {
                        return firstNumber / secondNumber;
                    }
                default:
                    {
                        return ' ';
                    }
            }
        }
    }
}
