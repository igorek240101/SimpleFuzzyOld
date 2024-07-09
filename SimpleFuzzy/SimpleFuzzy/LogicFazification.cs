using SimpleFuzzy.Abstract;
using System.Data;

namespace SimpleFuzzy
{
    public partial class LogicFazification : UserControl, IVariable
    {
        List<(int, double)> IVariable.Terms()
        {
            return Result;
        }

        public int Count()
        {
            return Terms.Count;
        }

        public override string ToString()
        {
            return VarName;
        }

        string IVariable.Name()
        {
            return VarName;
        }
        Module<IBaseSet> BaseSet { get; set; }
        List<Module<IHasFunc>> Terms { get; set; } = new List<Module<IHasFunc>>();

        Color[] Colors { get; set; } = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Gold, Color.FromArgb(72, 44, 61),
                                                    Color.FromArgb(83, 125, 141), Color.FromArgb(155, 162, 255)};

        public List<(int, double)> Result { get; set; }

        public Action Action { private get; set; }

        public bool IsOutput { get; set; } = false;

        public string VarName => textBox1.Text;

        public int Input 
        {
            set 
            {
                comboBox1.SelectedIndex = value;
            }
        }

        List<(object, List<double>)> Values { get; set; } = new List<(object, List<double>)>();

        public LogicFazification()
        {
            InitializeComponent();
            BaseSet = new Module<IBaseSet>("Базовое множество термов", ModuleChecker);
            BaseSet.Location = new Point(10, 100);
            Controls.Add(BaseSet);
            panel1.Location = new Point(0, (Terms.Count + 1) * 70 + 100);
        }

        public List<(int, double)> Calc()
        {
            if (ModuleChecker())
            {
                button3_Click(null, null);
                return Result;
            }
            return null;
        }

        public bool ModuleChecker()
        {
            if (Terms.Count < 1)
            {
                label1.Text = "Недостаточно модулей";
                button3.Enabled = false;
                return false;
            }
            foreach (var item in Terms)
            {
                if (BaseSet.now != null && item.now != null)
                {
                    BaseSet.now.ToFirst();
                    if (BaseSet.now.Get().GetType() == item.now.GetInputType)
                    {
                        button3.Enabled = true;
                        label1.Text = "";
                    }
                    else
                    {
                        label1.Text = "Тип значения базового множества не совпадает с типом термов";
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
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Module<IHasFunc> func = new Module<IHasFunc>($"Терм {(char)('A' + Terms.Count)}", ModuleChecker);
            func.Location = new Point(10, Terms.Count * 70 + 170);
            Controls.Add(func);
            Terms.Add(func);
            button2.Enabled = true;
            panel1.Location = new Point(0, (Terms.Count + 1) * 70 + 100);
            ModuleChecker();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Remove(Terms[^1]);
            Terms[^1].Dispose();
            Terms.RemoveAt(Terms.Count - 1);
            if (Terms.Count == 0) button2.Enabled = false;
            panel1.Location = new Point(0, (Terms.Count + 1) * 70 + 100);
            ModuleChecker();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Values.Clear();
            comboBox1.Items.Clear();
            BaseSet.now.ToFirst();
            while (!BaseSet.now.IsEnd())
            {
                object x = BaseSet.now.Get();
                List<double> values = new List<double>();
                foreach (var term in Terms)
                {
                    values.Add(term.now.GetResult(x));
                }
                Values.Add((x, values));
                BaseSet.now.ToNext();
            }
            pictureBox1.Refresh();
            pictureBox1.Visible = true;
            label2.Visible = true;
            numericUpDown1.Visible = true;
            if (!IsOutput)
            {
                comboBox1.Visible = true;
                comboBox1.Items.AddRange(Values.ConvertAll(t => t.Item1).ToArray());
                comboBox1.SelectedIndex = 0;
                label4.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;
                if (Action != null)
                {
                    Action();
                    if (Result != null)
                    {
                        Resulter(Result);
                        label4.Visible = true;
                        return;
                    }
                }
                label4.Visible = false;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen xyz = new Pen(Color.Black, 3);
            graphics.DrawLine(xyz, 5, 195, pictureBox1.Width - 5, 195);
            TextRenderer.DrawText(graphics, "1", this.Font, new Point(0, 5), SystemColors.ControlText);
            graphics.DrawLine(xyz, 5, 5, pictureBox1.Width - 5, 5);
            TextRenderer.DrawText(graphics, "0", this.Font, new Point(0, 195), SystemColors.ControlText);
            for (int i = 1; i < Values.Count; i++)
            {
                DrawLine(graphics, i, x => x);
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

        private void DrawLine(Graphics graphics, int i, Func<double, double> func)
        {
            for (int j = 0; j < Values[0].Item2.Count; j++)
            {
                Pen pen = new Pen(Colors[j % Colors.Length], 2);
                graphics.DrawLine(pen,
                    (i - 1) * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i - 1].Item2[j]) * 190),
                    i * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i].Item2[j]) * 190));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Result = new List<(int, double)>();
            for (int i = 0; i < Values[comboBox1.SelectedIndex].Item2.Count; i++)
            {
                if (Values[comboBox1.SelectedIndex].Item2[i] != 0)
                    Result.Add((i, Values[comboBox1.SelectedIndex].Item2[i]));
            }
            Resulter(Result);
        }

        public void Resulter(List<(int, double)> results)
        {
            label4.Text = "";
            if (results.Count == 0) label4.Text = $"{textBox1.Text} не имеет определенного качественного значения";
            else
            {
                if (results.Count == 1)
                {
                    if (results[0].Item2 == 1)
                        label4.Text += $"{textBox1.Text} - {Terms[results[0].Item1].now.Name}\r\n";
                    else if (results[0].Item2 >= 0.5)
                        label4.Text += $"{textBox1.Text} почти {Terms[results[0].Item1].now.Name}\r\n";
                    else
                        label4.Text += $"{textBox1.Text} немного {Terms[results[0].Item1].now.Name}\r\n";
                }
                else
                {
                    results = results.OrderByDescending(x => x.Item2).ToList();
                    foreach (var item in results.Where(t => t.Item2 == 1))
                    {
                        label4.Text += $"{textBox1.Text} - {Terms[item.Item1].now.Name}\r\n";
                    }
                    for (int i = 1; i < results.Count; i++)
                    {
                        if (results[i].Item2 != 1)
                        {
                            for (int j = i; j < results.Count; j++)
                            {
                                if (results[i - 1].Item2 == results[j].Item2)
                                    label4.Text += $"{textBox1.Text} в равной степени {Terms[results[i - 1].Item1].now.Name} и {Terms[results[j].Item1].now.Name}\r\n";
                                else
                                    label4.Text += $"{textBox1.Text} скорее {Terms[results[i - 1].Item1].now.Name}, чем {Terms[results[j].Item1].now.Name}\r\n";
                            }
                        }
                    }
                }
            }
        }

    }
}
