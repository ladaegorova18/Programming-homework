using System;
using System.Windows.Forms;

namespace GUICalculator
{
    /// <summary>
    /// Counter for calculator
    /// </summary>
    public class Counter : Form
    {
        /// <summary>
        /// Counts result of operation with two numbers
        /// </summary>
        /// <param name="first"> first number </param>
        /// <param name="second"> second number </param>
        /// <param name="operation"> operation to do </param>
        /// <returns> result of expression </returns>
        public float Count(float first, float second, string operation)
        {
            switch (operation)
            {
                case "+":
                    {
                        return first + second;
                    }
                case "-":
                    {
                        return first - second;
                    }
                case "/":
                    {
                        return Dividing(first, second);
                    }
                case "*":
                    {
                        return first * second;
                    }
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
        }

        private float Dividing(float first, float second)
        {
            if (second != 0)
            {
                return first / second;
            }
            throw new DivideByZeroException();
        }
    }
}
