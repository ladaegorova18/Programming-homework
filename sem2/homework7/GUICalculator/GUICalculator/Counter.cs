using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator
{
    public class Counter
    {
        private float Add(float first, float second) => first + second;

        private float Divide(float first, float second) => first / second;

        private float Subtract(float first, float second) => first - second;

        private float Multiplicate(float first, float second) => first * second;
        /*and so on..*/

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
