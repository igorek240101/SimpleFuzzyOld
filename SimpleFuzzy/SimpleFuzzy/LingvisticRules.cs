using SimpleFuzzy.Abstract;

namespace SimpleFuzzy
{
    public partial class LingvisticRules : UserControl
    {
        Module<IBaseSet> BaseSetA { get; set; }
        Module<IBaseSet> BaseSetB { get; set; }
        Module<IHasFunc> TermA { get; set; }
        Module<IHasFunc> TermB { get; set; }

        double[,] Values { get; set; }

        List<object> NameA { get; set; }
        List<object> NameB { get; set; }

        public LingvisticRules()
        {
            InitializeComponent();
            dataGridView1.AutoSize = true;
            dataGridView2.AutoSize = true;
            dataGridView3.AutoSize = true;
            BaseSetA = new Module<IBaseSet>($"Базовое множество A", ModuleChecker);
            TermA = new Module<IHasFunc>($"Функция принадлежности A", ModuleChecker);
            BaseSetB = new Module<IBaseSet>($"Базовое множество B", ModuleChecker);
            TermB = new Module<IHasFunc>($"Функция принадлежности B", ModuleChecker);
            BaseSetA.Location = new Point(10, 30);
            TermA.Location = new Point(575, 30);
            BaseSetB.Location = new Point(10, 100);
            TermB.Location = new Point(575, 100);
            Controls.Add(BaseSetA);
            Controls.Add(TermA);
            Controls.Add(BaseSetB);
            Controls.Add(TermB);
        }

        private bool ModuleChecker()
        {
            if (BaseSetA.now != null && TermA.now != null && BaseSetB.now != null && TermB.now != null)
            {
                BaseSetA.now.ToFirst();
                BaseSetB.now.ToFirst();
                if (BaseSetA.now.Get().GetType() == TermA.now.GetInputType && BaseSetB.now.Get().GetType() == TermB.now.GetInputType)
                {
                    button3.Enabled = true;
                    label1.Text = "";
                    return true;
                }
                else
                {
                    label1.Text = "Тип значения базового множества не совпадает с типом функции принадлежности";
                    button3.Enabled = false;
                    return false;
                }
            }
            else
            {
                label1.Text = "Не все модули загружены";
                button3.Enabled = false;
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<(object, double)> valuesA = new List<(object, double)>();
            List<(object, double)> valuesB = new List<(object, double)>();
            NameA = new List<object>();
            NameB = new List<object>();
            BaseSetA.now.ToFirst();
            BaseSetB.now.ToFirst();
            while (!BaseSetA.now.IsEnd())
            {
                object x = BaseSetA.now.Get();
                valuesA.Add((x, TermA.now.GetResult(x)));
                NameA.Add(x);
                BaseSetA.now.ToNext();
            }
            while (!BaseSetB.now.IsEnd())
            {
                object x = BaseSetB.now.Get();
                valuesB.Add((x, TermB.now.GetResult(x)));
                NameB.Add(x);
                BaseSetB.now.ToNext();
            }
            Values = new double[valuesB.Count, valuesA.Count];
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[valuesA.Count + 1];
            column[0] = new DataGridViewTextBoxColumn();
            column[0].HeaderText = "";
            column[0].Name = "";
            for (int i = 0; i < valuesA.Count; i++)
            {
                column[i + 1] = new DataGridViewTextBoxColumn();
                column[i + 1].HeaderText = valuesA[i].Item1.ToString();
                column[i + 1].Name = valuesA[i].Item1.ToString();
            }
            dataGridView1.Columns.AddRange(column);
            for (int i = 0; i < valuesB.Count; i++)
            {
                string[] results = new string[valuesA.Count + 1];
                results[0] = valuesB[i].Item1.ToString();
                for (int j = 0; j < valuesA.Count; j++)
                {
                    Values[i, j] = radioButton1.Checked ?
                        Math.Min(valuesA[j].Item2, valuesB[i].Item2) :
                        Math.Max(valuesA[j].Item2, valuesB[i].Item2);
                    results[j + 1] = Values[i, j].ToString();
                }
                dataGridView1.Rows.Add(results);
            }
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            DataGridViewTextBoxColumn[] column2 = new DataGridViewTextBoxColumn[valuesA.Count + 1];
            for (int i = 0; i < column.Length; i++) column2[i] = column[i].Clone() as DataGridViewTextBoxColumn;
            dataGridView2.Columns.AddRange(column2);
            for (int i = 0; i < valuesB.Count; i++)
            {
                string[] results = new string[valuesA.Count + 1];
                results[0] = valuesB[i].Item1.ToString();
                for (int j = 0; j < valuesA.Count; j++)
                {
                    results[j + 1] = valuesA[j].Item2.ToString();
                }
                dataGridView2.Rows.Add(results);
            }
            dataGridView3.Columns.Clear();
            dataGridView3.Rows.Clear();
            column2 = new DataGridViewTextBoxColumn[valuesA.Count + 1];
            for (int i = 0; i < column.Length; i++) column2[i] = column[i].Clone() as DataGridViewTextBoxColumn;
            dataGridView3.Columns.AddRange(column2);
            for (int i = 0; i < valuesB.Count; i++)
            {
                string[] results = new string[valuesA.Count + 1];
                results[0] = valuesB[i].Item1.ToString();
                for (int j = 0; j < valuesA.Count; j++)
                {
                    results[j + 1] = valuesB[i].Item2.ToString();
                }
                dataGridView3.Rows.Add(results);
            }
            label2.Visible = true;
            label3.Visible = true;
            numericUpDown1.Visible = true;
            numericUpDown2.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView2.Location = new Point(dataGridView2.Location.X, dataGridView1.Location.Y + dataGridView1.Height + 10);
        }

        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
            dataGridView3.Location = new Point(dataGridView3.Location.X, dataGridView2.Location.Y + dataGridView2.Height + 10);
        }

        private void dataGridView3_Paint(object sender, PaintEventArgs e)
        {
            panel2.Location = new Point(0, dataGridView3.Location.Y + dataGridView3.Height + 10);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            => pictureBox1.Refresh();

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
            => pictureBox2.Refresh();

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen xyz = new Pen(Color.Black, 3);
            Pen curve = new Pen(Color.Red, 2);
            graphics.DrawLine(xyz, 5, 195, pictureBox1.Width - 5, 195);
            TextRenderer.DrawText(graphics, "1", this.Font, new Point(0, 5), SystemColors.ControlText);
            graphics.DrawLine(xyz, 5, 5, pictureBox1.Width - 5, 5);
            TextRenderer.DrawText(graphics, "0", this.Font, new Point(0, 195), SystemColors.ControlText);
            for (int i = 1; i < Values.GetLength(1); i++)
            {
                double first = Values[0, i - 1];
                for (int j = 1; j < Values.GetLength(0); j++) first = radioButton1.Checked ? Math.Max(first, Values[j, i - 1]) : Math.Min(first, Values[j, i - 1]);
                double second = Values[0, i];
                for (int j = 1; j < Values.GetLength(0); j++) second = radioButton1.Checked ? Math.Max(second, Values[j, i]) : Math.Min(second, Values[j, i]);
                graphics.DrawLine(curve,
                    (i - 1) * (pictureBox1.Width - 10) / Values.GetLength(1) + 5,
                    (float)(195 - first * 190),
                    i * (pictureBox1.Width - 10) / Values.GetLength(1) + 5,
                    (float)(195 - second * 190));
                if (Values.GetLength(1) <= numericUpDown1.Value)
                {
                    TextRenderer.DrawText(graphics, NameA[i - 1].ToString(),
                    this.Font, new Point((i - 1) * (pictureBox1.Width - 10) / Values.GetLength(1) + 5, i % 2 == 0 ? 200 : 210),
                    SystemColors.ControlText);
                }
            }
            if (Values.GetLength(1) > numericUpDown1.Value)
            {
                for (int i = 0; i < numericUpDown1.Value - 1; i++)
                {
                    TextRenderer.DrawText(graphics, NameA[i].ToString(),
                    this.Font, new Point((int)(Values.GetLength(1) / (numericUpDown1.Value - 1) * i) * (pictureBox1.Width - 10) / Values.GetLength(1) + 5, i % 2 == 0 ? 200 : 210),
                    SystemColors.ControlText);
                }
                TextRenderer.DrawText(graphics, NameA[^1].ToString(),
                                    this.Font, new Point(Values.GetLength(1) * (pictureBox1.Width - 10) / Values.GetLength(1) - 10, numericUpDown1.Value - 1 % 2 == 0 ? 200 : 210),
                                    SystemColors.ControlText);
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen xyz = new Pen(Color.Black, 3);
            Pen curve = new Pen(Color.Red, 2);
            graphics.DrawLine(xyz, 5, 195, pictureBox2.Width - 5, 195);
            TextRenderer.DrawText(graphics, "1", this.Font, new Point(0, 5), SystemColors.ControlText);
            graphics.DrawLine(xyz, 5, 5, pictureBox2.Width - 5, 5);
            TextRenderer.DrawText(graphics, "0", this.Font, new Point(0, 195), SystemColors.ControlText);
            for (int i = 1; i < Values.GetLength(0); i++)
            {
                double first = Values[i - 1, 0];
                for (int j = 1; j < Values.GetLength(1); j++) first = radioButton1.Checked ? Math.Max(first, Values[i - 1, j]) : Math.Min(first, Values[i - 1, j]);
                double second = Values[i, 0];
                for (int j = 1; j < Values.GetLength(1); j++) second = radioButton1.Checked ? Math.Max(second, Values[i, j]) : Math.Min(second, Values[i, j]);
                graphics.DrawLine(curve,
                    (i - 1) * (pictureBox2.Width - 10) / Values.GetLength(0) + 5,
                    (float)(195 - first * 190),
                    i * (pictureBox2.Width - 10) / Values.GetLength(0) + 5,
                    (float)(195 - second * 190));
                if (Values.GetLength(0) <= numericUpDown2.Value)
                {
                    TextRenderer.DrawText(graphics, NameB[i - 1].ToString(),
                    this.Font, new Point((i - 1) * (pictureBox2.Width - 10) / Values.GetLength(0) + 5, i % 2 == 0 ? 200 : 210),
                    SystemColors.ControlText);
                }
            }
            if (Values.GetLength(0) > numericUpDown2.Value)
            {
                for (int i = 0; i < numericUpDown2.Value - 1; i++)
                {
                    TextRenderer.DrawText(graphics, NameB[i].ToString(),
                    this.Font, new Point((int)(Values.GetLength(0) / (numericUpDown2.Value - 1) * i) * (pictureBox2.Width - 10) / Values.GetLength(0) + 5, i % 2 == 0 ? 200 : 210),
                    SystemColors.ControlText);
                }
                TextRenderer.DrawText(graphics, NameB[^1].ToString(),
                                    this.Font, new Point(Values.GetLength(0) * (pictureBox2.Width - 10) / Values.GetLength(0) - 10, numericUpDown2.Value - 1 % 2 == 0 ? 200 : 210),
                                    SystemColors.ControlText);
            }
        }
    }
}
