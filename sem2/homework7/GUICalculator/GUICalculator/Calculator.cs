using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICalculator
{
    public partial class Calculator : Form
    {
        private Counter counter;
        private float? result;
        private float? current;
        private string operation;
        public Calculator()
        {
            counter = new Counter();
            InitializeComponent();
        }

        private void ReadNumber(int number)
        {
            if (!result.HasValue)
            {
                result = number;
                firstNumberText.Visible = false;
                nextNumberText.Visible = true;
            }
            else if (operation != null)
            {
                current = number;
                result = counter.Count(result.Value, current.Value, operation);
                ShowResult(result.Value);
                operation = null;
            }
            else
            {
                result = number;
            }
        }

        private void ShowResult(float result)
        {
            resultText.Text = result.ToString();
            resultText.Visible = true;
        }

        private void Button1Click(object sender, EventArgs e) => ReadNumber(1);

        private void Number2Click(object sender, EventArgs e) => ReadNumber(2);

        private void Number3Click(object sender, EventArgs e) => ReadNumber(3);

        private void Number4Click(object sender, EventArgs e) => ReadNumber(4);

        private void Number5Click(object sender, EventArgs e) => ReadNumber(5);

        private void Number6Click(object sender, EventArgs e) => ReadNumber(6);

        private void Number7Click(object sender, EventArgs e) => ReadNumber(7);

        private void Number8Click(object sender, EventArgs e) => ReadNumber(8);

        private void Number9Click(object sender, EventArgs e) => ReadNumber(9);

        private void Number0Click(object sender, EventArgs e) => ReadNumber(0);

        private void AdditionClick(object sender, EventArgs e) => operation = "+";

        private void DivisionClick(object sender, EventArgs e) => operation = "/";

        private void MultiplicationClick(object sender, EventArgs e) => operation = "*";

        private void SubtractionClick(object sender, EventArgs e) => operation = "-";

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AskToInputOperation(object sender, EventArgs e)
        {
            if ((result.HasValue) && (operation == null))
            {
                nextNumberText.Visible = false;
                Visible = true;
            }
        }

        private void AskToInputNextNumber(object sender, EventArgs e)
        {
            if ((result.HasValue) && (operation != null))
            {
                operationText.Visible = false;
                Visible = true;
            }
        }

        private void AskToInputFirstNumber(object sender, EventArgs e)
        {
            if (result.HasValue)
            {
                Visible = false;
            }
        }
    }
}
