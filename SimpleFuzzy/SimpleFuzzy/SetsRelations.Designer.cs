namespace SimpleFuzzy
{
    partial class SetsRelations
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
            label1 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            checkBox7 = new CheckBox();
            checkBox8 = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox10 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(127, 219);
            label1.Name = "label1";
            label1.Size = new Size(151, 15);
            label1.TabIndex = 3;
            label1.Text = "Не все модули загружены";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(10, 210);
            button1.Name = "button1";
            button1.Size = new Size(111, 33);
            button1.TabIndex = 2;
            button1.Text = "Расчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(516, 219);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 250);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 246);
            label2.Name = "label2";
            label2.Size = new Size(199, 15);
            label2.TabIndex = 6;
            label2.Text = "Количество элементов по шкале x";
            label2.Visible = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(215, 244);
            numericUpDown1.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(74, 23);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown1.Visible = false;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 288);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 9;
            label3.Text = "label3";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 313);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 10;
            label4.Text = "label4";
            label4.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 337);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 12;
            label5.Text = "label5";
            label5.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 362);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 11;
            label6.Text = "label6";
            label6.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(10, 390);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(130, 19);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Пересечение (осн)";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(263, 390);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(132, 19);
            checkBox2.TabIndex = 14;
            checkBox2.Text = "Объединение (осн)";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.Visible = false;
            checkBox2.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(10, 414);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(183, 19);
            checkBox3.TabIndex = 15;
            checkBox3.Text = "Пересечение (Огр разность)";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.Visible = false;
            checkBox3.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(10, 465);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(247, 19);
            checkBox4.TabIndex = 17;
            checkBox4.Text = "Пересечение (Эйнштейн произведение)";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.Visible = false;
            checkBox4.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(10, 440);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(230, 19);
            checkBox5.TabIndex = 16;
            checkBox5.Text = "Пересечение (Алгебр произведение)";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.Visible = false;
            checkBox5.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(10, 490);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(237, 19);
            checkBox6.TabIndex = 18;
            checkBox6.Text = "Пересечение (Хамахер произведение)";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.Visible = false;
            checkBox6.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox7
            // 
            checkBox7.AutoSize = true;
            checkBox7.Location = new Point(263, 490);
            checkBox7.Name = "checkBox7";
            checkBox7.Size = new Size(237, 19);
            checkBox7.TabIndex = 22;
            checkBox7.Text = "Пересечение (Хамахер произведение)";
            checkBox7.UseVisualStyleBackColor = true;
            checkBox7.Visible = false;
            checkBox7.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox8
            // 
            checkBox8.AutoSize = true;
            checkBox8.Location = new Point(263, 465);
            checkBox8.Name = "checkBox8";
            checkBox8.Size = new Size(247, 19);
            checkBox8.TabIndex = 21;
            checkBox8.Text = "Пересечение (Эйнштейн произведение)";
            checkBox8.UseVisualStyleBackColor = true;
            checkBox8.Visible = false;
            checkBox8.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox9
            // 
            checkBox9.AutoSize = true;
            checkBox9.Location = new Point(263, 440);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(230, 19);
            checkBox9.TabIndex = 20;
            checkBox9.Text = "Пересечение (Алгебр произведение)";
            checkBox9.UseVisualStyleBackColor = true;
            checkBox9.Visible = false;
            checkBox9.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox10
            // 
            checkBox10.AutoSize = true;
            checkBox10.Location = new Point(263, 414);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(183, 19);
            checkBox10.TabIndex = 19;
            checkBox10.Text = "Пересечение (Огр разность)";
            checkBox10.UseVisualStyleBackColor = true;
            checkBox10.Visible = false;
            checkBox10.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // SetsRelations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBox7);
            Controls.Add(checkBox8);
            Controls.Add(checkBox9);
            Controls.Add(checkBox10);
            Controls.Add(checkBox6);
            Controls.Add(checkBox4);
            Controls.Add(checkBox5);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "SetsRelations";
            Size = new Size(981, 617);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox checkBox10;
    }
}
