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

        private void ReadNumber(float number)
        {
            if (resultText.Text == "0")
            {
                resultText.Text = number.ToString();
                firstNumberText.Text = resultText.Text;
                return;
            }
            resultText.Text += number.ToString();
            //firstNumberText.Text += resultText.Text;
        }

        private void ScanNumber()
        {
            if ((!result.HasValue) || (operation == null))
            {
                result = int.Parse(resultText.Text);
                current = null;
                return;
            }
            current = int.Parse(resultText.Text);
        }

        private void ReadOperation(string operation)
        {
            ScanNumber();
            resultText.Text = "0";
            if (operation != null)
            {
                //firstNumberText.Text = firstNumberText.Text
            }
            this.operation = operation;
            firstNumberText.Text += operation;
        }

        private void ShowResult()
        {
            ScanNumber();
            if (result.HasValue && current.HasValue && operation != null)
            {
                result = counter.Count(result.Value, current.Value, operation);
                resultText.Text = result.ToString();
                firstNumberText.Text = resultText.Text;
                resultText.Visible = true;
                operation = null;
                current = null;
            }
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

        private void DrobClick(object sender, EventArgs e)
        {

        }

        private void DeleteCurrentNumberClick(object sender, EventArgs e) => resultText.Text = "0";

        private void ChangeSignClick(object sender, EventArgs e)
        {
            if (int.Parse(resultText.Text) < 0)
            {
                //resultText.Text = string.Copy(); //скопировать кусок строки с [1] до конца
                return;
            }
            resultText.Text += "-" + resultText.Text;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {

        }

        private void FirstNumberText_Click(object sender, EventArgs e)
        {

        }

        private void NumberEtempClick(object sender, EventArgs e)
        {

        }

        private void NumberPiClick(object sender, EventArgs e)
        {

        }
    }
}
