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

        private float Power(float first, float second) => (float)Pow(first, second);

        private float Root(float first, float second) => (float)Pow(first, 1 / second);
        /*and so on..*///double??

        public float Count(float first, float second, string operation) =>
        operation switch
        {
            "+" => Add(first, second),
            "-" => Subtract(first, second),
            "/" => Divide(first, second),
            "*" => Multiplicate(first, second),
            "pow" => Power(first, second),
            "root" => Root(first, second),
            _ => throw new ArgumentException("Некорректная операция!")
        };
    }
}
