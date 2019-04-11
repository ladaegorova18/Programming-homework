using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUICalculator
{
    public partial class Calculator : Form
    {
        private Counter counter;
        private float? result;
        private float? current;
        private string operation;
        private Color oldColor;
        private Color color;
        bool isComma = false;

        public Calculator()
        {
            counter = new Counter();
            InitializeComponent();
        }

        /// <summary>
        /// Reads numbers from button
        /// </summary>
        /// <param name="number"> number to add in textbox </param>
        public void ReadNumber(char number)
        {
            if (textBox.Text == "0")
            {
                textBox.Text = null;
            }
            if (tempExpression.Text == "0")
            {
                tempExpression.Text = null;
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
            if ((textBox.Text != "") && (textBox.Text != null))
            {
                if (float.TryParse(textBox.Text, out float temp))
                {
                    result = temp;
                    textBox.Text = null;
                    if (!Char.IsDigit(tempExpression.Text[tempExpression.Text.Length - 1]))
                    {
                        tempExpression.Text = DeleteLastSymbol(tempExpression.Text);
                    }
                    tempExpression.Text += operation;
                    isComma = false;
                }
                else
                {
                    tempExpression.Text = null;
                }
            }
            this.operation = operation;
        }

        private void ShowResult()
        {
            if ((textBox.Text != null) && (textBox.Text != ""))
            {
                if (float.TryParse(textBox.Text, out float temp) && (result.HasValue) && operation != null)
                {
                    current = temp;
                    result = counter.Count(result.Value, current.Value, operation);
                    if (!int.TryParse(result.ToString(), out int tempInt))
                    {
                        isComma = true;
                    }
                    textBox.Text = result.ToString();
                    tempExpression.Text = result.ToString();
                    operation = null; // выглядит грустно
                }
            }
        } // отдельный класс для GUI

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

        private void PowerClick(object sender, EventArgs e) => ReadOperation("^");

        private void EqualSignClick(object sender, EventArgs e) => ShowResult();

        private void CommaClick(object sender, EventArgs e)
        {
            if ((textBox.Text != "") && (!isComma))
            {
                textBox.Text += ',';
                tempExpression.Text += ',';
                isComma = true;
            }
        }

        private void ChangeSignClick(object sender, EventArgs e)
        {
            float.TryParse(textBox.Text, out float temp);
            if (temp < 0)
            {
                textBox.Text = textBox.Text.Substring(1);
                tempExpression.Text = textBox.Text.Substring(0, textBox.Text.Length - textBox.Text.Length);
                tempExpression.Text = tempExpression.Text + textBox.Text;
                return;
            }
            if (temp == 0)
            {
                return;
            }
            tempExpression.Text = textBox.Text.Substring(0, textBox.Text.Length - textBox.Text.Length);
            tempExpression.Text = tempExpression.Text + "-" + textBox.Text;
            textBox.Text = "-" + textBox.Text;
        }

        private void DeleteLineClick(object sender, EventArgs e)
        {
            if (result.HasValue)
            {
                if (operation == null)
                {
                    result = null;
                    tempExpression.Text = null;
                    isComma = false;
                }
                else
                {
                    float.TryParse(textBox.Text, out float temp);
                    result = temp;
                }
            }
            else
            {
                tempExpression.Text = null;
            }
            textBox.Text = "0";
        }

        private void DeleteAllClick(object sender, EventArgs e)
        {
            result = null;
            tempExpression.Text = null;
            textBox.Text = null;
            isComma = false;
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

        private void DeleteAllButtonMouseMove(object sender, MouseEventArgs e) => ChangeColorMouseEnter(deleteAllButton);

        private void DeleteAllButtonMouseLeave(object sender, EventArgs e) => ChangeColorMouseLeave(deleteAllButton);

        private void ChangeColorMouseEnter(Button temp)
        {
            oldColor = temp.BackColor;
            temp.BackColor = Color.Ivory;
        }

        private void ChangeColorMouseLeave(Button temp) => temp.BackColor = oldColor;

    }
} // долгая обработка исключений
