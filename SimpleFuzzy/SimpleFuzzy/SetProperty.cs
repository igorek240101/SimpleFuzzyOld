using SimpleFuzzy.Abstract;
using System.Security.Cryptography;

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

        private bool ModuleChecker()
        {
            if (BaseSet.now != null && HasFunc.now != null)
            {
                BaseSet.now.ToFirst();
                if (BaseSet.now.Get().GetType() == HasFunc.now.GetInputType)
                {
                    button1.Enabled = true;
                    label1.Text = "";
                    return true;
                }
                else
                {
                    label1.Text = "Тип значения базового множества не совпадает с типом функции принадлежности";
                    button1.Enabled = false;
                    return false;
                }
            }
            else
            {
                label1.Text = "Не все модули загружены";
                button1.Enabled = false;
                return false;
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
            string value = "";
            foreach (var item in Values.Where(t => t.Item2 != 0))
            {
                if (value != "") value += $", {item.Item1}";
                else value += item.Item1.ToString();
            }
            label3.Text = $"Область влияния: {{{value}}}";
            value = "";
            foreach (var item in Values.Where(t => t.Item2 == 1))
            {
                if (value != "") value += $", {item.Item1}";
                else value += item.Item1.ToString();
            }
            label4.Text = $"Ядро нечеткого множества: {{{value}}}";
            label5.Text = $"Высота нечеткого множества: {Values.Max(t => t.Item2)}";
            if (Values.Max(t => t.Item2) == 1)
                if (Values.All(t => t.Item2 == 1))
                    label6.Text = $"Универсальное нечеткое множество";
                else
                    label6.Text = $"Нормальное нечеткое множество";
            else
                if (Values.All(t => t.Item2 == 0))
                label6.Text = $"Пустое нечеткое множество";
            else
                label6.Text = $"Субнормальное нечеткое множество";
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            numericUpDown2.Visible = true;
            numericUpDown2_ValueChanged(null, null);
            label8.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen xyz = new Pen(Color.Black, 3);
            Pen curve = new Pen(Color.Red, 2);
            Pen antiCurve = new Pen(Color.Blue, 2);
            Pen concCurve = new Pen(Color.Green, 2);
            Pen dilationCurve = new Pen(Color.DarkGoldenrod, 2);
            Pen contratCurve = new Pen(Color.Purple, 2);
            graphics.DrawLine(xyz, 5, 195, pictureBox1.Width - 5, 195);
            TextRenderer.DrawText(graphics, "1", this.Font, new Point(0, 5), SystemColors.ControlText);
            graphics.DrawLine(xyz, 5, 5, pictureBox1.Width - 5, 5);
            TextRenderer.DrawText(graphics, "0", this.Font, new Point(0, 195), SystemColors.ControlText);
            for (int i = 1; i < Values.Count; i++)
            {
                DrawLine(graphics, curve, i, x => x);
                if (checkBox1.Checked)
                    DrawLine(graphics, antiCurve, i, x => 1 - x);
                if (checkBox2.Checked)
                    DrawLine(graphics, concCurve, i, x => x * x);
                if (checkBox3.Checked)
                    DrawLine(graphics, dilationCurve, i, x => Math.Sqrt(x));
                if (checkBox4.Checked)
                    DrawLine(graphics, contratCurve, i, x => x < 0.5 ? 2 * x * x : 1 - 2 * Math.Pow(1 - x, 2));
                if (Values.Count <= numericUpDown1.Value)
                {
                    TextRenderer.DrawText(graphics, Values[i - 1].Item1.ToString(),
                    this.Font, new Point((i - 1) * (pictureBox1.Width - 10) / Values.Count + 5, i % 2 == 0 ? 200 : 210),
                    SystemColors.ControlText);
                }
            }
            if (Values.Count > numericUpDown1.Value)
            {
                for (int i = 0; i < numericUpDown1.Value - 1; i++)
                {
                    TextRenderer.DrawText(graphics, Values[(int)(Values.Count / (numericUpDown1.Value - 1) * i)].Item1.ToString(),
                    this.Font, new Point((int)(Values.Count / (numericUpDown1.Value - 1) * i) * (pictureBox1.Width - 10) / Values.Count + 5, i % 2 == 0 ? 200 : 210),
                    SystemColors.ControlText);
                }
                TextRenderer.DrawText(graphics, Values[^1].Item1.ToString(),
                    this.Font, new Point(Values.Count * (pictureBox1.Width - 10) / Values.Count - 10, numericUpDown1.Value - 1 % 2 == 0 ? 200 : 210),
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

        private void SetProperty_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            string value = "";
            foreach (var item in Values.Where(t => t.Item2 >= (double)numericUpDown2.Value))
            {
                if (value != "") value += $", {item.Item1}";
                else value += item.Item1.ToString();
            }
            label7.Text = $"- {{{value}}}";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void DrawLine(Graphics graphics, Pen curve, int i, Func<double, double> func)
        {
            graphics.DrawLine(curve,
                    (i - 1) * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i - 1].Item2) * 190),
                    i * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i].Item2) * 190));
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
