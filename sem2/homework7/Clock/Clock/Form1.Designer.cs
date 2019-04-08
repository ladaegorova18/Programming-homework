namespace Clock
{
    partial class Form1
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

        private void ShowData()
        {
            var currentTime = System.DateTime.Now;
            this.time.Text = currentTime.ToLongTimeString();
            var localTimeZone = System.TimeZoneInfo.Local;
            this.timeZone.Text = localTimeZone.DisplayName;
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.time = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeZone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.time.AutoSize = true;
            this.time.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.time.Font = new System.Drawing.Font("Microsoft YaHei Light", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time.ForeColor = System.Drawing.Color.Linen;
            this.time.Location = new System.Drawing.Point(60, 33);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(136, 70);
            this.time.TabIndex = 0;
            this.time.Text = "time";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.TimerTick);
            // 
            // timeZone
            // 
            this.timeZone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timeZone.AutoSize = true;
            this.timeZone.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.timeZone.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeZone.ForeColor = System.Drawing.Color.Linen;
            this.timeZone.Location = new System.Drawing.Point(80, 103);
            this.timeZone.MaximumSize = new System.Drawing.Size(300, 0);
            this.timeZone.Name = "timeZone";
            this.timeZone.Size = new System.Drawing.Size(80, 21);
            this.timeZone.TabIndex = 1;
            this.timeZone.Text = "timeZone";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(334, 162);
            this.Controls.Add(this.timeZone);
            this.Controls.Add(this.time);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "Form1";
            this.Text = "CurrentTime";
            this.Load += new System.EventHandler(this.Form1Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timeZone;
    }
}

