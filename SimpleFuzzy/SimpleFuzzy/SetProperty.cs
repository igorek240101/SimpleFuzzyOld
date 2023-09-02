using SimpleFuzzy.Abstract;

namespace SimpleFuzzy
{
    public partial class SetProperty : UserControl
    {
        Module<IBaseSet> BaseSet { get; set; }
        Module<IHasFunc> HasFunc { get; set; }

        List<(object, double)> Values { get; set; }
        public SetProperty()
        {
            InitializeComponent();
            BaseSet = new Module<IBaseSet>("Базовое множество", ModuleChecker);
            BaseSet.Location = new Point(10, 20);
            Controls.Add(BaseSet);
            HasFunc = new Module<IHasFunc>("Функция принадлежности", ModuleChecker);
            HasFunc.Location = new Point(10, 80);
            Controls.Add(HasFunc);
        }

        private void ModuleChecker()
        {
            if (BaseSet.now != null && HasFunc.now != null)
            {
                if (BaseSet.now.Get().GetType() == HasFunc.now.GetInputType)
                {
                    button1.Enabled = true;
                    label1.Text = "";
                }
                else
                {
                    label1.Text = "Тип значения базового множества не совпадает с типом функции принадлежности";
                    button1.Enabled = false;
                }
            }
            else
            {
                label1.Text = "Не все модули загружены";
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Values = new List<(object, double)>();
            BaseSet.now.ToFirst();
            while (!BaseSet.now.IsEnd())
            {
                object x = BaseSet.now.Get();
                Values.Add((x, HasFunc.now.GetResult(x)));
                BaseSet.now.ToNext();
            }
            pictureBox1.Refresh();
            pictureBox1.Visible = true;
            numericUpDown1.Visible = true;
            label2.Visible = true;
            checkBox1.Visible = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen xyz = new Pen(Color.Black, 3);
            Pen curve = new Pen(Color.Red, 2);
            Pen antiCurve = new Pen(Color.Blue, 2);
            graphics.DrawLine(xyz, 5, 195, pictureBox1.Width - 5, 195);
            TextRenderer.DrawText(graphics, "1", this.Font, new Point(0, 5), SystemColors.ControlText);
            graphics.DrawLine(xyz, 5, 5, pictureBox1.Width - 5, 5);
            TextRenderer.DrawText(graphics, "0", this.Font, new Point(0, 195), SystemColors.ControlText);
            for (int i = 1; i < Values.Count; i++)
            {
                graphics.DrawLine(curve,
                    (i - 1) * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - Values[i - 1].Item2 * 190),
                    i * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - Values[i].Item2 * 190));
                if (checkBox1.Checked)
                {
                    graphics.DrawLine(antiCurve,
                        (i - 1) * (pictureBox1.Width - 10) / Values.Count + 5,
                        (float)(195 - (1 - Values[i - 1].Item2) * 190),
                        i * (pictureBox1.Width - 10) / Values.Count + 5,
                        (float)(195 - (1 - Values[i].Item2) * 190));
                }
                if (Values.Count <= numericUpDown1.Value)
                {
                    TextRenderer.DrawText(graphics, Values[i - 1].Item1.ToString(),
                    this.Font, new Point((i - 1) * (pictureBox1.Width - 10) / Values.Count + 5, 200),
                    SystemColors.ControlText);
                }
            }
            if (Values.Count > numericUpDown1.Value)
            {
                for (int i = 0; i < numericUpDown1.Value - 1; i++)
                {
                    TextRenderer.DrawText(graphics, Values[(int)(Values.Count / (numericUpDown1.Value - 1) * i)].Item1.ToString(),
                    this.Font, new Point((int)(Values.Count / (numericUpDown1.Value - 1) * i) * (pictureBox1.Width - 10) / Values.Count + 5, 200),
                    SystemColors.ControlText);
                }
                TextRenderer.DrawText(graphics, Values[^1].Item1.ToString(),
                    this.Font, new Point(Values.Count * (pictureBox1.Width - 10) / Values.Count - 10, 200),
                    SystemColors.ControlText);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
