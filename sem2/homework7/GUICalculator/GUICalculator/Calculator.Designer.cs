namespace GUICalculator
{
    partial class Calculator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.number0 = new System.Windows.Forms.Button();
            this.division = new System.Windows.Forms.Button();
            this.still = new System.Windows.Forms.Button();
            this.multiplication = new System.Windows.Forms.Button();
            this.number9 = new System.Windows.Forms.Button();
            this.subtraction = new System.Windows.Forms.Button();
            this.number8 = new System.Windows.Forms.Button();
            this.number7 = new System.Windows.Forms.Button();
            this.number6 = new System.Windows.Forms.Button();
            this.number5 = new System.Windows.Forms.Button();
            this.number4 = new System.Windows.Forms.Button();
            this.number3 = new System.Windows.Forms.Button();
            this.number2 = new System.Windows.Forms.Button();
            this.number1 = new System.Windows.Forms.Button();
            this.addition = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.firstNumberText = new System.Windows.Forms.Label();
            this.nextNumberText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.Label();
            this.operationText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Controls.Add(this.number0, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.division, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.still, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.multiplication, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.number9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.subtraction, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.number8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.number7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.number6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.number5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.number4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.number3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.number2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.number1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addition, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(224, 235);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.87719F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.12281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(308, 203);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // number0
            // 
            this.number0.Location = new System.Drawing.Point(79, 157);
            this.number0.Name = "number0";
            this.number0.Size = new System.Drawing.Size(70, 43);
            this.number0.TabIndex = 10;
            this.number0.Text = "0";
            this.number0.UseVisualStyleBackColor = true;
            this.number0.Click += new System.EventHandler(this.Number0Click);
            // 
            // division
            // 
            this.division.Location = new System.Drawing.Point(234, 108);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(71, 43);
            this.division.TabIndex = 3;
            this.division.Text = "/";
            this.division.UseVisualStyleBackColor = true;
            this.division.Click += new System.EventHandler(this.DivisionClick);
            // 
            // still
            // 
            this.still.Location = new System.Drawing.Point(3, 157);
            this.still.Name = "still";
            this.still.Size = new System.Drawing.Size(70, 43);
            this.still.TabIndex = 9;
            this.still.Text = "button10";
            this.still.UseVisualStyleBackColor = true;
            // 
            // multiplication
            // 
            this.multiplication.Location = new System.Drawing.Point(234, 56);
            this.multiplication.Name = "multiplication";
            this.multiplication.Size = new System.Drawing.Size(71, 46);
            this.multiplication.TabIndex = 2;
            this.multiplication.Text = "*";
            this.multiplication.UseVisualStyleBackColor = true;
            this.multiplication.Click += new System.EventHandler(this.MultiplicationClick);
            // 
            // number9
            // 
            this.number9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number9.Location = new System.Drawing.Point(155, 108);
            this.number9.Name = "number9";
            this.number9.Size = new System.Drawing.Size(71, 43);
            this.number9.TabIndex = 8;
            this.number9.Text = "9";
            this.number9.UseVisualStyleBackColor = true;
            this.number9.Click += new System.EventHandler(this.Number9Click);
            // 
            // subtraction
            // 
            this.subtraction.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.subtraction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.subtraction.Location = new System.Drawing.Point(234, 3);
            this.subtraction.Name = "subtraction";
            this.subtraction.Size = new System.Drawing.Size(68, 47);
            this.subtraction.TabIndex = 1;
            this.subtraction.Text = "-";
            this.subtraction.UseVisualStyleBackColor = false;
            this.subtraction.Click += new System.EventHandler(this.SubtractionClick);
            // 
            // number8
            // 
            this.number8.Location = new System.Drawing.Point(79, 108);
            this.number8.Name = "number8";
            this.number8.Size = new System.Drawing.Size(70, 43);
            this.number8.TabIndex = 7;
            this.number8.Text = "8";
            this.number8.UseVisualStyleBackColor = true;
            this.number8.Click += new System.EventHandler(this.Number8Click);
            // 
            // number7
            // 
            this.number7.Location = new System.Drawing.Point(3, 108);
            this.number7.Name = "number7";
            this.number7.Size = new System.Drawing.Size(70, 43);
            this.number7.TabIndex = 6;
            this.number7.Text = "7";
            this.number7.UseVisualStyleBackColor = true;
            this.number7.Click += new System.EventHandler(this.Number7Click);
            // 
            // number6
            // 
            this.number6.Location = new System.Drawing.Point(155, 56);
            this.number6.Name = "number6";
            this.number6.Size = new System.Drawing.Size(71, 46);
            this.number6.TabIndex = 5;
            this.number6.Text = "6";
            this.number6.UseVisualStyleBackColor = true;
            this.number6.Click += new System.EventHandler(this.Number6Click);
            // 
            // number5
            // 
            this.number5.Location = new System.Drawing.Point(79, 56);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(70, 46);
            this.number5.TabIndex = 4;
            this.number5.Text = "5";
            this.number5.UseVisualStyleBackColor = true;
            this.number5.Click += new System.EventHandler(this.Number5Click);
            // 
            // number4
            // 
            this.number4.Location = new System.Drawing.Point(3, 56);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(70, 46);
            this.number4.TabIndex = 3;
            this.number4.Text = "4";
            this.number4.UseVisualStyleBackColor = true;
            this.number4.Click += new System.EventHandler(this.Number4Click);
            // 
            // number3
            // 
            this.number3.Location = new System.Drawing.Point(155, 3);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(71, 47);
            this.number3.TabIndex = 2;
            this.number3.Text = "3";
            this.number3.UseVisualStyleBackColor = true;
            this.number3.Click += new System.EventHandler(this.Number3Click);
            // 
            // number2
            // 
            this.number2.Location = new System.Drawing.Point(79, 3);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(70, 47);
            this.number2.TabIndex = 1;
            this.number2.Text = "2";
            this.number2.UseVisualStyleBackColor = true;
            this.number2.Click += new System.EventHandler(this.MultiplicationClick);
            // 
            // number1
            // 
            this.number1.Location = new System.Drawing.Point(3, 3);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(70, 47);
            this.number1.TabIndex = 0;
            this.number1.Text = "1";
            this.number1.UseVisualStyleBackColor = true;
            this.number1.Click += new System.EventHandler(this.Button1Click);
            // 
            // addition
            // 
            this.addition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addition.Location = new System.Drawing.Point(234, 157);
            this.addition.Name = "addition";
            this.addition.Size = new System.Drawing.Size(71, 43);
            this.addition.TabIndex = 11;
            this.addition.Text = "+";
            this.addition.UseVisualStyleBackColor = true;
            this.addition.Click += new System.EventHandler(this.AdditionClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(224, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(308, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // firstNumberText
            // 
            this.firstNumberText.AutoSize = true;
            this.firstNumberText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstNumberText.Location = new System.Drawing.Point(220, 73);
            this.firstNumberText.Name = "firstNumberText";
            this.firstNumberText.Size = new System.Drawing.Size(187, 20);
            this.firstNumberText.TabIndex = 2;
            this.firstNumberText.Text = "Введите первое число:";
            this.firstNumberText.VisibleChanged += new System.EventHandler(this.AskToInputFirstNumber);
            // 
            // nextNumberText
            // 
            this.nextNumberText.AutoSize = true;
            this.nextNumberText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextNumberText.Location = new System.Drawing.Point(358, 53);
            this.nextNumberText.Name = "nextNumberText";
            this.nextNumberText.Size = new System.Drawing.Size(221, 20);
            this.nextNumberText.TabIndex = 3;
            this.nextNumberText.Text = "Введите следующее число:";
            this.nextNumberText.Visible = false;
            this.nextNumberText.VisibleChanged += new System.EventHandler(this.AskToInputNextNumber);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(223, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Результат:";
            // 
            // resultText
            // 
            this.resultText.AutoSize = true;
            this.resultText.Location = new System.Drawing.Point(371, 150);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(35, 13);
            this.resultText.TabIndex = 5;
            this.resultText.Text = "label4";
            this.resultText.Visible = false;
            // 
            // operationText
            // 
            this.operationText.AutoSize = true;
            this.operationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationText.Location = new System.Drawing.Point(45, 143);
            this.operationText.Name = "operationText";
            this.operationText.Size = new System.Drawing.Size(159, 20);
            this.operationText.TabIndex = 6;
            this.operationText.Text = "Введите операцию:";
            this.operationText.Visible = false;
            this.operationText.VisibleChanged += new System.EventHandler(this.AskToInputOperation);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.operationText);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nextNumberText);
            this.Controls.Add(this.firstNumberText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button number0;
        private System.Windows.Forms.Button still;
        private System.Windows.Forms.Button number9;
        private System.Windows.Forms.Button number8;
        private System.Windows.Forms.Button number7;
        private System.Windows.Forms.Button number6;
        private System.Windows.Forms.Button number5;
        private System.Windows.Forms.Button number4;
        private System.Windows.Forms.Button number3;
        private System.Windows.Forms.Button number2;
        private System.Windows.Forms.Button number1;
        private System.Windows.Forms.Button subtraction;
        private System.Windows.Forms.Button multiplication;
        private System.Windows.Forms.Button division;
        private System.Windows.Forms.Button addition;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label firstNumberText;
        private System.Windows.Forms.Label nextNumberText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label resultText;
        private System.Windows.Forms.Label operationText;
    }
}

