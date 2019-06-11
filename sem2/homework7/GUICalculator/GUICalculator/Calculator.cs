using System;
using System.Windows.Forms;

namespace GUICalculator
{
    /// <summary>
    /// Simple WinForms calculator
    /// </summary>
    public partial class Calculator : Form
    {
        private readonly Counter counter = new Counter();

        /// <summary>
        /// Constuctor of calculator
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            tempExpression.Text = counter.TempExpression;
            textBox.Text = counter.TextBox;
        }

        /// <summary>
        /// Reads numbers from button
        /// </summary>
        /// <param name="number"> number to add in textbox </param>
        public void ReadNumber(string number)
        {
            counter.GetNumber(number);
            RefreshData();
        }

        /// <summary>
        /// Reads operation from button
        /// </summary>
        /// <param name="operation"> operation to read </param>
        public void ReadOperation(string operation)
        {
            counter.GetOperation(operation);
            RefreshData();
        }

        private void ShowResult()
        {
            counter.GetResult();
            RefreshData();
        }

        //numbers
        private void NumberClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            counter.GetNumber(button.Text);
            RefreshData();
        }

        // operations
        private void OperationClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            counter.GetOperation(button.Text);
            RefreshData();
        }

        private void EqualSignClick(object sender, EventArgs e) => ShowResult();

        private void CommaClick(object sender, EventArgs e)
        {
            counter.Comma();
            RefreshData();
        }

        private void ChangeSignClick(object sender, EventArgs e)
        {
            counter.ChangeSign();
            RefreshData();
        }

        private void DeleteLineClick(object sender, EventArgs e)
        {
            counter.DeleteLine();
            RefreshData();
        }

        private void DeleteAllClick(object sender, EventArgs e)
        {
            counter.DeleteAll();
            RefreshData();
        }

        private void DeleteOneSymbolButtonClick(object sender, EventArgs e) => counter.DeleteOneSymbol();

        /// <summary>
        /// gets key from keyboard
        /// </summary>
        public void CalculatorKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                ReadNumber(e.KeyChar.ToString());
            }
            else if (IsOperation(e.KeyChar))
            {
                ReadOperation(e.KeyChar.ToString());
            }
            else if (e.KeyChar == '=')
            {
                ShowResult();
            }
            else if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                CommaClick(sender, e);
            }
        }

        private static bool IsOperation(char operation) => operation == '/' || operation == '*'
            || operation == '-' || operation == '+';
    }
} 