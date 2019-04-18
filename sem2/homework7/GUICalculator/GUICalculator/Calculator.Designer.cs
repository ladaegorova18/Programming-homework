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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.number0 = new System.Windows.Forms.Button();
            this.number9 = new System.Windows.Forms.Button();
            this.number8 = new System.Windows.Forms.Button();
            this.number7 = new System.Windows.Forms.Button();
            this.number6 = new System.Windows.Forms.Button();
            this.number5 = new System.Windows.Forms.Button();
            this.number4 = new System.Windows.Forms.Button();
            this.number3 = new System.Windows.Forms.Button();
            this.number2 = new System.Windows.Forms.Button();
            this.number1 = new System.Windows.Forms.Button();
            this.subtraction = new System.Windows.Forms.Button();
            this.multiplication = new System.Windows.Forms.Button();
            this.division = new System.Windows.Forms.Button();
            this.addition = new System.Windows.Forms.Button();
            this.equalSign = new System.Windows.Forms.Button();
            this.comma = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.deleteLineButton = new System.Windows.Forms.Button();
            this.deleteOneSymbolButton = new System.Windows.Forms.Button();
            this.tempExpression = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.number0, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.number9, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.number8, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.number7, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.number6, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.number5, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.number4, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.number3, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.number2, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.number1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.subtraction, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.multiplication, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.division, 4, 2);
            this.tableLayoutPanel.Controls.Add(this.addition, 4, 3);
            this.tableLayoutPanel.Controls.Add(this.equalSign, 4, 4);
            this.tableLayoutPanel.Controls.Add(this.comma, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.button1, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.deleteAllButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.deleteLineButton, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.deleteOneSymbolButton, 3, 0);
            this.tableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 115);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(317, 272);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // number0
            // 
            this.number0.AutoSize = true;
            this.number0.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number0.Cursor = System.Windows.Forms.Cursors.Default;
            this.number0.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number0.Location = new System.Drawing.Point(85, 221);
            this.number0.Name = "number0";
            this.number0.Size = new System.Drawing.Size(70, 46);
            this.number0.TabIndex = 10;
            this.number0.Text = "0";
            this.number0.UseVisualStyleBackColor = false;
            this.number0.Click += new System.EventHandler(this.Number0Click);
            // 
            // number9
            // 
            this.number9.AutoSize = true;
            this.number9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number9.Cursor = System.Windows.Forms.Cursors.Default;
            this.number9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number9.Location = new System.Drawing.Point(163, 167);
            this.number9.Name = "number9";
            this.number9.Size = new System.Drawing.Size(70, 46);
            this.number9.TabIndex = 8;
            this.number9.Text = "9";
            this.number9.UseVisualStyleBackColor = false;
            this.number9.Click += new System.EventHandler(this.Number9Click);
            // 
            // number8
            // 
            this.number8.AutoSize = true;
            this.number8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number8.Cursor = System.Windows.Forms.Cursors.Default;
            this.number8.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number8.Location = new System.Drawing.Point(85, 167);
            this.number8.Name = "number8";
            this.number8.Size = new System.Drawing.Size(70, 46);
            this.number8.TabIndex = 7;
            this.number8.Text = "8";
            this.number8.UseVisualStyleBackColor = false;
            this.number8.Click += new System.EventHandler(this.Number8Click);
            // 
            // number7
            // 
            this.number7.AutoSize = true;
            this.number7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number7.Cursor = System.Windows.Forms.Cursors.Default;
            this.number7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number7.Location = new System.Drawing.Point(7, 167);
            this.number7.Name = "number7";
            this.number7.Size = new System.Drawing.Size(70, 46);
            this.number7.TabIndex = 6;
            this.number7.Text = "7";
            this.number7.UseVisualStyleBackColor = false;
            this.number7.Click += new System.EventHandler(this.Number7Click);
            // 
            // number6
            // 
            this.number6.AutoSize = true;
            this.number6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number6.Cursor = System.Windows.Forms.Cursors.Default;
            this.number6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number6.Location = new System.Drawing.Point(163, 113);
            this.number6.Name = "number6";
            this.number6.Size = new System.Drawing.Size(70, 46);
            this.number6.TabIndex = 5;
            this.number6.Text = "6";
            this.number6.UseVisualStyleBackColor = false;
            this.number6.Click += new System.EventHandler(this.Number6Click);
            // 
            // number5
            // 
            this.number5.AutoSize = true;
            this.number5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number5.Cursor = System.Windows.Forms.Cursors.Default;
            this.number5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number5.Location = new System.Drawing.Point(85, 113);
            this.number5.Name = "number5";
            this.number5.Size = new System.Drawing.Size(70, 46);
            this.number5.TabIndex = 4;
            this.number5.Text = "5";
            this.number5.UseVisualStyleBackColor = false;
            this.number5.Click += new System.EventHandler(this.Number5Click);
            // 
            // number4
            // 
            this.number4.AutoSize = true;
            this.number4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number4.Cursor = System.Windows.Forms.Cursors.Default;
            this.number4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number4.Location = new System.Drawing.Point(7, 113);
            this.number4.Name = "number4";
            this.number4.Size = new System.Drawing.Size(70, 46);
            this.number4.TabIndex = 3;
            this.number4.Text = "4";
            this.number4.UseVisualStyleBackColor = false;
            this.number4.Click += new System.EventHandler(this.Number4Click);
            // 
            // number3
            // 
            this.number3.AutoSize = true;
            this.number3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number3.Cursor = System.Windows.Forms.Cursors.Default;
            this.number3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number3.Location = new System.Drawing.Point(163, 59);
            this.number3.Name = "number3";
            this.number3.Size = new System.Drawing.Size(71, 46);
            this.number3.TabIndex = 2;
            this.number3.Text = "3";
            this.number3.UseVisualStyleBackColor = false;
            this.number3.Click += new System.EventHandler(this.Number3Click);
            // 
            // number2
            // 
            this.number2.AutoSize = true;
            this.number2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number2.Cursor = System.Windows.Forms.Cursors.Default;
            this.number2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number2.Location = new System.Drawing.Point(85, 59);
            this.number2.Name = "number2";
            this.number2.Size = new System.Drawing.Size(70, 46);
            this.number2.TabIndex = 1;
            this.number2.Text = "2";
            this.number2.UseVisualStyleBackColor = false;
            this.number2.Click += new System.EventHandler(this.Number2Click);
            // 
            // number1
            // 
            this.number1.AutoSize = true;
            this.number1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.number1.Cursor = System.Windows.Forms.Cursors.Default;
            this.number1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.number1.Location = new System.Drawing.Point(7, 59);
            this.number1.Name = "number1";
            this.number1.Size = new System.Drawing.Size(70, 46);
            this.number1.TabIndex = 0;
            this.number1.Text = "1";
            this.number1.UseVisualStyleBackColor = false;
            this.number1.Click += new System.EventHandler(this.Number1Click);
            // 
            // subtraction
            // 
            this.subtraction.AutoSize = true;
            this.subtraction.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.subtraction.Cursor = System.Windows.Forms.Cursors.Default;
            this.subtraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subtraction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.subtraction.Location = new System.Drawing.Point(242, 5);
            this.subtraction.Name = "subtraction";
            this.subtraction.Size = new System.Drawing.Size(70, 46);
            this.subtraction.TabIndex = 1;
            this.subtraction.Text = "-";
            this.subtraction.UseVisualStyleBackColor = false;
            this.subtraction.Click += new System.EventHandler(this.SubtractionClick);
            // 
            // multiplication
            // 
            this.multiplication.AutoSize = true;
            this.multiplication.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.multiplication.Cursor = System.Windows.Forms.Cursors.Default;
            this.multiplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiplication.Location = new System.Drawing.Point(242, 59);
            this.multiplication.Name = "multiplication";
            this.multiplication.Size = new System.Drawing.Size(70, 46);
            this.multiplication.TabIndex = 2;
            this.multiplication.Text = "*";
            this.multiplication.UseVisualStyleBackColor = false;
            this.multiplication.Click += new System.EventHandler(this.MultiplicationClick);
            // 
            // division
            // 
            this.division.AutoSize = true;
            this.division.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.division.Cursor = System.Windows.Forms.Cursors.Default;
            this.division.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.division.Location = new System.Drawing.Point(242, 113);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(70, 46);
            this.division.TabIndex = 3;
            this.division.Text = "/";
            this.division.UseVisualStyleBackColor = false;
            this.division.Click += new System.EventHandler(this.DivisionClick);
            // 
            // addition
            // 
            this.addition.AutoSize = true;
            this.addition.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.addition.Cursor = System.Windows.Forms.Cursors.Default;
            this.addition.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addition.Location = new System.Drawing.Point(242, 167);
            this.addition.Name = "addition";
            this.addition.Size = new System.Drawing.Size(70, 46);
            this.addition.TabIndex = 11;
            this.addition.Text = "+";
            this.addition.UseVisualStyleBackColor = false;
            this.addition.Click += new System.EventHandler(this.AdditionClick);
            // 
            // equalSign
            // 
            this.equalSign.AutoSize = true;
            this.equalSign.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.equalSign.Cursor = System.Windows.Forms.Cursors.Default;
            this.equalSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.equalSign.Location = new System.Drawing.Point(242, 221);
            this.equalSign.Name = "equalSign";
            this.equalSign.Size = new System.Drawing.Size(70, 46);
            this.equalSign.TabIndex = 9;
            this.equalSign.Text = "=";
            this.equalSign.UseVisualStyleBackColor = false;
            this.equalSign.Click += new System.EventHandler(this.EqualSignClick);
            // 
            // comma
            // 
            this.comma.AutoSize = true;
            this.comma.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.comma.Cursor = System.Windows.Forms.Cursors.Default;
            this.comma.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comma.Location = new System.Drawing.Point(163, 221);
            this.comma.Name = "comma";
            this.comma.Size = new System.Drawing.Size(70, 46);
            this.comma.TabIndex = 13;
            this.comma.Text = ",";
            this.comma.UseVisualStyleBackColor = false;
            this.comma.Click += new System.EventHandler(this.CommaClick);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(7, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "+/-";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ChangeSignClick);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.AutoSize = true;
            this.deleteAllButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.deleteAllButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.deleteAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteAllButton.Location = new System.Drawing.Point(7, 5);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(70, 46);
            this.deleteAllButton.TabIndex = 19;
            this.deleteAllButton.Text = "CE";
            this.deleteAllButton.UseVisualStyleBackColor = false;
            this.deleteAllButton.Click += new System.EventHandler(this.DeleteAllClick);
            // 
            // deleteLineButton
            // 
            this.deleteLineButton.AutoSize = true;
            this.deleteLineButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.deleteLineButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.deleteLineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteLineButton.Location = new System.Drawing.Point(85, 5);
            this.deleteLineButton.Name = "deleteLineButton";
            this.deleteLineButton.Size = new System.Drawing.Size(70, 46);
            this.deleteLineButton.TabIndex = 20;
            this.deleteLineButton.Text = "C";
            this.deleteLineButton.UseVisualStyleBackColor = false;
            this.deleteLineButton.Click += new System.EventHandler(this.DeleteLineClick);
            // 
            // deleteOneSymbolButton
            // 
            this.deleteOneSymbolButton.AutoSize = true;
            this.deleteOneSymbolButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.deleteOneSymbolButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.deleteOneSymbolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteOneSymbolButton.Location = new System.Drawing.Point(163, 5);
            this.deleteOneSymbolButton.Name = "deleteOneSymbolButton";
            this.deleteOneSymbolButton.Size = new System.Drawing.Size(70, 46);
            this.deleteOneSymbolButton.TabIndex = 21;
            this.deleteOneSymbolButton.Text = "<=";
            this.deleteOneSymbolButton.UseVisualStyleBackColor = false;
            this.deleteOneSymbolButton.Click += new System.EventHandler(this.DeleteOneSymbolButtonClick);
            // 
            // tempExpression
            // 
            this.tempExpression.AutoSize = true;
            this.tempExpression.Font = new System.Drawing.Font("Microsoft YaHei Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tempExpression.Location = new System.Drawing.Point(7, 43);
            this.tempExpression.Name = "tempExpression";
            this.tempExpression.Size = new System.Drawing.Size(0, 25);
            this.tempExpression.TabIndex = 2;
            // 
            // textBox
            // 
            this.textBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(12, 71);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(317, 38);
            this.textBox.TabIndex = 6;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(344, 390);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.tempExpression);
            this.Controls.Add(this.tableLayoutPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 429);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button number9;
        private System.Windows.Forms.Button number8;
        private System.Windows.Forms.Button number7;
        private System.Windows.Forms.Button number6;
        private System.Windows.Forms.Button number5;
        private System.Windows.Forms.Button number4;
        private System.Windows.Forms.Button number3;
        private System.Windows.Forms.Button number2;
        private System.Windows.Forms.Button number1;
        private System.Windows.Forms.Label tempExpression;
        private System.Windows.Forms.Button comma;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.Button deleteLineButton;
        private System.Windows.Forms.Button division;
        private System.Windows.Forms.Button subtraction;
        private System.Windows.Forms.Button multiplication;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button number0;
        private System.Windows.Forms.Button equalSign;
        private System.Windows.Forms.Button addition;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button deleteOneSymbolButton;
    }
}

