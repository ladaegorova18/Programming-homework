using System;
using System.Windows.Forms;

namespace GUICalculator
{
    public partial class Calculator : Form
    {
        private Counter counter = new Counter();
        private float? result;
        private float? current;
        private string operation;
        bool comma = false;

        /// <summary>
        /// Constuctor of calculator
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reads numbers from button
        /// </summary>
        /// <param name="number"> number to add in textbox </param>
        public void ReadNumber(char number)
        {
            if (result.HasValue && float.IsNaN(result.Value) || textBox.Text == "0")
            {
                textBox.Text = "";
                tempExpression.Text = "";
            }
            textBox.Text += number;
            tempExpression.Text += number;
        }

        /// <summary>
        /// Reads operation from button
        /// </summary>
        /// <param name="operation"> operation to read </param>
        public void ReadOperation(string operation)
        {
            ShowResult();
            if ((textBox.Text != null) && (textBox.Text != ""))
            {
                if (float.TryParse(textBox.Text, out float temp))
                {
                    result = temp;
                    textBox.Text = "";
                    comma = false;
                }
            }
            if (result.HasValue && float.IsNaN(result.Value))
            {
                tempExpression.Text = "";
            }
            if (tempExpression.Text != "")
            {
                if (!char.IsDigit(tempExpression.Text[tempExpression.Text.Length - 1])
                        && tempExpression.Text[tempExpression.Text.Length - 1] != '∞')
                {
                    tempExpression.Text = DeleteLastSymbol(tempExpression.Text);
                }
                tempExpression.Text += operation;
            }
            this.operation = operation;
        }

        private void ShowResult()
        {
            if ((textBox.Text != null) && (textBox.Text != ""))
            {
                if (float.TryParse(textBox.Text, out float temp) && result.HasValue && operation != null)
                {
                    current = temp;
                    result = counter.Count(result.Value, current.Value, operation);
                    if (!int.TryParse(result.ToString(), out int tempInt))
                    {
                        comma = true;
                    }
                    textBox.Text = result.ToString();
                    tempExpression.Text = result.ToString();
                    operation = null;
                }
            }
        }

        //numbers
        private void Number1Click(object sender, EventArgs e) => ReadNumber('1');

        private void Number2Click(object sender, EventArgs e) => ReadNumber('2');

        private void Number3Click(object sender, EventArgs e) => ReadNumber('3');

        private void Number4Click(object sender, EventArgs e) => ReadNumber('4');

        private void Number5Click(object sender, EventArgs e) => ReadNumber('5');

        private void Number6Click(object sender, EventArgs e) => ReadNumber('6');

        private void Number7Click(object sender, EventArgs e) => ReadNumber('7');

        private void Number8Click(object sender, EventArgs e) => ReadNumber('8');

        private void Number9Click(object sender, EventArgs e) => ReadNumber('9');

        private void Number0Click(object sender, EventArgs e) => ReadNumber('0');

        // operations
        public void AdditionClick(object sender, EventArgs e) => ReadOperation("+");

        private void DivisionClick(object sender, EventArgs e) => ReadOperation("/");

        private void MultiplicationClick(object sender, EventArgs e) => ReadOperation("*");

        private void SubtractionClick(object sender, EventArgs e) => ReadOperation("-");

        private void EqualSignClick(object sender, EventArgs e) => ShowResult();

        private void CommaClick(object sender, EventArgs e)
        {
            if ((textBox.Text != "") && (!comma))
            {
                textBox.Text += ',';
                tempExpression.Text += ',';
                comma = true;
            }
        }

        private void ChangeSignClick(object sender, EventArgs e)
        {
            float.TryParse(textBox.Text, out float temp);
            if (temp == 0)
            {
                return;
            }
            tempExpression.Text = "";
            if (temp < 0)
            {
                textBox.Text = textBox.Text.Substring(1);
                tempExpression.Text = textBox.Text;
                return;
            }
            tempExpression.Text = "-" + textBox.Text;
            textBox.Text = "-" + textBox.Text;
        }

        private void DeleteLineClick(object sender, EventArgs e)
        {
            if (result.HasValue)
            {
                if (operation == null)
                {
                    result = null;
                    tempExpression.Text = "";
                    comma = false;
                }
                else
                {
                    float.TryParse(textBox.Text, out float temp);
                    result = temp;
                }
            }
            else
            {
                tempExpression.Text = "";
            }
            textBox.Text = "";
        }

        private void DeleteAllClick(object sender, EventArgs e)
        {
            result = null;
            tempExpression.Text = "";
            textBox.Text = "";
            comma = false;
        }

        private void DeleteOneSymbolButtonClick(object sender, EventArgs e)
        {
            textBox.Text = DeleteLastSymbol(textBox.Text);
            tempExpression.Text = DeleteLastSymbol(tempExpression.Text);
        }

        private string DeleteLastSymbol(string line)
        {
            if (line.Length > 0)
            {
                return line.Substring(0, line.Length - 1);
            }
            return "";
        }
    }
} 