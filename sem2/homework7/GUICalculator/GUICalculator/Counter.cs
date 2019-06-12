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
        /// data in the textBox
        /// </summary>
        public string TextBox { get; private set; }

        /// <summary>
        /// temp expression near textBox
        /// </summary>
        public string TempExpression { get; private set; }

        private float? result;
        private float? current;
        private string operation;
        bool comma = false;

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

        /// <summary>
        /// Reads numbers from button
        /// </summary>
        /// <param name="number"> number to add in textbox </param>
        public void GetNumber(string number)
        {
            if (result.HasValue && float.IsNaN(result.Value) || TextBox == "0" || TextBox == "Error")
            {
                TextBox = "";
                TempExpression = "";
            }
            TextBox += number;
            TempExpression += number;
        }

        /// <summary>
        /// Reads operation from button
        /// </summary>
        /// <param name="operation"> operation to read </param>
        public void GetOperation(string operation)
        {
            GetResult();
            if ((TextBox != null) && (TextBox != ""))
            {
                if (float.TryParse(TextBox, out float temp))
                {
                    result = temp;
                    TextBox = "";
                    comma = false;
                }
            }
            if (result.HasValue && float.IsNaN(result.Value))
            {
                TempExpression = "";
            }
            if (TempExpression != "")
            {
                if (!char.IsDigit(TempExpression[TempExpression.Length - 1]))
                {
                    TempExpression = DeleteLastSymbol(TempExpression);
                }
                TempExpression += operation;
            }
            this.operation = operation;
        }

        /// <summary>
        /// gets result of expression
        /// </summary>
        public void GetResult()
        {
            if ((TextBox != null) && (TextBox != ""))
            {
                if (float.TryParse(TextBox, out float temp) && result.HasValue && operation != null)
                {
                    current = temp;
                    try
                    {
                        result = Count(result.Value, current.Value, operation);
                    }
                    catch (DivideByZeroException)
                    {
                        TextBox = "Error";
                        TempExpression = "";
                        operation = null;
                        result = null;
                        return;
                    }
                    if (!int.TryParse(result.ToString(), out int tempInt))
                    {
                        comma = true;
                    }
                    TextBox = result.ToString();
                    TempExpression = result.ToString();
                    operation = null;
                }
            }
        }
        
        /// <summary>
        /// places a comma
        /// </summary>
        public void Comma()
        {
            if ((TextBox != "") && (!comma))
            {
                TextBox += ',';
                TempExpression += ',';
                comma = true;
            }
        }

        /// <summary>
        /// changes sign of number
        /// </summary>
        public void ChangeSign()
        {
            float.TryParse(TextBox, out float temp);
            if (temp == 0)
            {
                return;
            }
            TempExpression = "";
            if (temp < 0)
            {
                TextBox = TextBox.Substring(1);
                TempExpression = TextBox;
                return;
            }
            TempExpression = "-" + TextBox;
            TextBox = "-" + TextBox;
        }

        /// <summary>
        /// deletes last symbol in expression
        /// </summary>
        public void DeleteOneSymbol()
        {
            TextBox = DeleteLastSymbol(TextBox);
            TempExpression = DeleteLastSymbol(TempExpression);
        }

        private string DeleteLastSymbol(string line)
        {
            if (line == "Error")
            {
                return "Error";
            }
            if (line.Length > 0)
            {
                return line.Substring(0, line.Length - 1);
            }
            return "";
        }

        /// <summary>
        /// deletes whole line
        /// </summary>
        public void DeleteLine()
        {
            if (result.HasValue)
            {
                if (operation == null)
                {
                    result = null;
                    TempExpression = "";
                    comma = false;
                }
                else
                {
                    float.TryParse(TextBox, out float temp);
                    result = temp;
                }
            }
            else
            {
                TempExpression = "";
            }
            TextBox = "";
        }

        /// <summary>
        /// deletes data from both fields
        /// </summary>
        public void DeleteAll()
        {
            result = null;
            TempExpression = "";
            TextBox = "";
            comma = false;
        }
    }
}
