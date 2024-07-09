namespace SimpleFuzzy
{
    public partial class LogicMasterOperation : UserControl, IVariable
    {
        public string VarName { get; set; } = "";

        Dictionary<string, Func<double, double, double>> binOperation;

        Dictionary<string, Func<double, double>> unoOperation;

        public event RenamedEventHandler Renamed;

        List<IVariable> vars;

        public List<IVariable> LogicFazifications
        {
            set
            {
                vars = value;
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                foreach (var faz in value)
                {
                    comboBox1.Items.Add(faz.Name());
                    comboBox2.Items.Add(faz.Name());
                }
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
            }
        }



        public LogicMasterOperation()
        {
            InitializeComponent();
            binOperation = new Dictionary<string, Func<double, double, double>>()
            {
                {"Fuzzy- A \"И\" B", (μA, μB) => (double)numericUpDown7.Value * Math.Min(μA, μB) + 0.5 * (1 - (double)numericUpDown7.Value) * (μA + μB)},
                {"Fuzzy- A \"ИЛИ\" B",  (μA, μB) =>  (double)numericUpDown7.Value * Math.Max(μA, μB) + 0.5 * (1 - (double)numericUpDown7.Value) * (μA + μB)},
                {"γ-оператор A - B", (μA, μB) => Math.Pow(μA * μB, 1 - (double)numericUpDown7.Value) * (1 - (1 - μA) * (1 - μB))},
                {"Min-Max A \"И\" B", (μA, μB) => Math.Min(μA, μB)},
                {"Min-Max A \"ИЛИ\" B", (μA, μB) => Math.Max(μA, μB)},
                {"усиленное произведение A \"И\" B", (μA, μB) => Math.Max(μA, μB) == 1 ? Math.Min(μA, μB) : 0},
                {"усиленная сумма A \"ИЛИ\" B", (μA, μB) => Math.Min(μA, μB) == 0 ? Math.Max(μA, μB) : 0},
                {"Lukasiewicz A \"И\" B", (μA, μB) => Math.Max(0, μA + μB - 1)},
                {"Lukasiewicz A \"ИЛИ\" B", (μA, μB) => Math.Min(1, μA + μB)},
                {"Эйнштейновское A \"И\" B", (μA, μB) => (μA * μB) / (2 - (μA + μB - μA * μB))},
                {"Эйнштейновское A \"ИЛИ\" B", (μA, μB) => (μA + μB) / (1 + μA * μB)},
                {"алгебраическое A \"И\" B", (μA, μB) => μA * μB},
                {"алгебраическое A \"ИЛИ\" B", (μA, μB) => μA + μB - μA * μB},
                {"Xамахеровское A \"И\" B", (μA, μB) => (μA * μB) / (μA + μB - μA * μB)},
                {"Xамахеровское A \"ИЛИ\" B", (μA, μB) => (μA + μB - 2 * μA * μB) / (1 - μA * μB)}
            };
            unoOperation = new Dictionary<string, Func<double, double>>()
            {
                {"Отрицание", (μA) => 1 - μA},
                {"Концентрация", (μA) => μA * μA},
                {"Раздутие", (μA) => Math.Sqrt(μA)},
                {"Контраст", (μA) => μA < 0.5 ? 2 * μA * μA : 1 - 2 * (1 - μA) * (1 - μA)}
            };
            radioButton2.Checked = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            label2.Visible = true;
            numericUpDown7.Visible = true;
            comboBox3.Items.Clear();
            foreach (var item in binOperation.Keys)
            {
                comboBox3.Items.Add(item);
            }
            comboBox3.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label2.Visible = false;
            numericUpDown7.Visible = false;
            comboBox3.Items.Clear();
            foreach (var item in unoOperation.Keys)
            {
                comboBox3.Items.Add(item);
            }
            comboBox3.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Renamed?.Invoke(this, new RenamedEventArgs(WatcherChangeTypes.Renamed, "", textBox1.Text, VarName));
            VarName = textBox1.Text;
        }

        public void Rename(object sender, RenamedEventArgs e)
        {
            for(int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString() == e.OldName)
                comboBox1.Items[i] = e.Name;
            }
        }

        public List<(int, double)> Terms()
        {
            return null;
        }

        public int Count()
        {
            if (radioButton1.Checked)
            {
                return vars[comboBox2.SelectedIndex].Count();
            }
            else
            {
                return vars[comboBox1.SelectedIndex].Count() * vars[comboBox2.SelectedIndex].Count();
            }
        }

        string IVariable.Name()
        {
            return VarName;
        }

        public override string ToString() => VarName;
    }
}
