namespace SimpleFuzzy
{
    partial class SetProperty
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            checkBox1 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(10, 150);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 0;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(127, 159);
            label1.Name = "label1";
            label1.Size = new Size(151, 15);
            label1.TabIndex = 1;
            label1.Text = "Не все модули загружены";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(295, 178);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 250);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(215, 188);
            numericUpDown1.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(74, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Visible = false;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 190);
            label2.Name = "label2";
            label2.Size = new Size(199, 15);
            label2.TabIndex = 4;
            label2.Text = "Количество элементов по шкале x";
            label2.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(10, 217);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(216, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Отображать нечеткое дополнение";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // SetProperty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "SetProperty";
            Size = new Size(713, 490);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private PictureBox pictureBox1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private CheckBox checkBox1;
    }
}
