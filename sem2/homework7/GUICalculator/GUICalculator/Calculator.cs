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

        private void ReadOperation(string operation)
        {
            result = float.Parse(textBox.Text);
            this.operation = operation;
            tempExpression.Text += operation;
            textBox.Text = null;
        }

        private void ShowResult()
        {
            current = float.Parse(textBox.Text);
            result = counter.Count(result.Value, current.Value, operation);
            textBox.Text = result.ToString();
            tempExpression.Text = result.ToString();
        }

        private void Number1Click(object sender, EventArgs e) => ReadNumber(1);

        private void Number2Click(object sender, EventArgs e) => ReadNumber(2);

        private void Number3Click(object sender, EventArgs e) => ReadNumber(3);

        private void Number4Click(object sender, EventArgs e) => ReadNumber(4);

        private void Number5Click(object sender, EventArgs e) => ReadNumber(5);

        private void Number6Click(object sender, EventArgs e) => ReadNumber(6);

        private void Number7Click(object sender, EventArgs e) => ReadNumber(7);

        private void Number8Click(object sender, EventArgs e) => ReadNumber(8);

        private void Number9Click(object sender, EventArgs e) => ReadNumber(9);

        private void Number0Click(object sender, EventArgs e) => ReadNumber(0);

        private void AdditionClick(object sender, EventArgs e) => ReadOperation("+");

        private void DivisionClick(object sender, EventArgs e) => ReadOperation("/");

        private void MultiplicationClick(object sender, EventArgs e) => ReadOperation("*");

        private void SubtractionClick(object sender, EventArgs e) => ReadOperation("-");

        private void RootClick(object sender, EventArgs e) => ReadOperation("root");

        private void PowerClick(object sender, EventArgs e) => ReadOperation("pow");

        private void EqualSignClick(object sender, EventArgs e) => ShowResult();

        private void CommaClick(object sender, EventArgs e)
        {
            textBox.Text += ',';
            tempExpression.Text += ',';
        }

        private void DeleteCurrentNumberClick(object sender, EventArgs e)
        {
            result = float.Parse(textBox.Text);
            textBox.Text = "0";
        }

        private void ChangeSignClick(object sender, EventArgs e)
        {
            if (int.Parse(textBox.Text) < 0)
            {
                //resultText.Text = string.Copy(); //скопировать кусок строки с [1] до конца
                return;
            }
            textBox.Text += "-" + textBox.Text;
        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteAllClick(object sender, EventArgs e)
        {
            result = 0;
            tempExpression.Text = null;
            textBox.Text = null;
        }

        private void FirstNumberText_Click(object sender, EventArgs e)
        {

        }

        private void EulersNumberClick(object sender, EventArgs e)
        {
            textBox.Text = "e";
        }

        private void NumberPiClick(object sender, EventArgs e)
        {
            textBox.Text = "pi";
        }
    }
}
