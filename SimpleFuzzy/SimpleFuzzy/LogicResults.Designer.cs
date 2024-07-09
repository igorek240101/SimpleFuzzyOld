namespace SimpleFuzzy
{
    partial class LogicResults
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
            logicFazification1 = new LogicFazification();
            logicFazification2 = new LogicFazification();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // logicFazification1
            // 
            logicFazification1.AutoSize = true;
            logicFazification1.Location = new Point(13, 20);
            logicFazification1.Name = "logicFazification1";
            logicFazification1.Result = null;
            logicFazification1.Size = new Size(794, 590);
            logicFazification1.TabIndex = 0;
            // 
            // logicFazification2
            // 
            logicFazification2.AutoSize = true;
            logicFazification2.Location = new Point(813, 20);
            logicFazification2.Name = "logicFazification2";
            logicFazification2.Result = null;
            logicFazification2.Size = new Size(794, 590);
            logicFazification2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1632, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(144, 92);
            dataGridView1.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(1632, 30);
            button3.Name = "button3";
            button3.Size = new Size(111, 33);
            button3.TabIndex = 5;
            button3.Text = "Расчитать";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // LogicResults
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(logicFazification2);
            Controls.Add(logicFazification1);
            Name = "LogicResults";
            Size = new Size(1779, 613);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LogicFazification logicFazification1;
        private LogicFazification logicFazification2;
        private DataGridView dataGridView1;
        private Button button3;
    }
}
