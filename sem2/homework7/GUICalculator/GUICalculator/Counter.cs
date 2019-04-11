using System;
using static System.Math;

namespace GUICalculator
{
    public class Counter
    {
        private float Add(float first, float second) => first + second;

        private float Divide(float first, float second) => first / second;

        private float Subtract(float first, float second) => first - second;

        private float Multiplicate(float first, float second) => first * second;

        
        /// <summary>
        /// Counts result of operation with two numbers
        /// </summary>
        /// <param name="first"> first number </param>
        /// <param name="second"> second number </param>
        /// <param name="operation"> operation to do </param>
        /// <returns> result of expression </returns>
        public float Count(float first, float second, string operation) =>
        operation switch
        {
            "+" => Add(first, second),
            "-" => Subtract(first, second),
            "/" => Divide(first, second),
            "*" => Multiplicate(first, second),
            _ => throw new ArgumentException("Некорректная операция!")
        };
    }
}
