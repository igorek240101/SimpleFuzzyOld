namespace SimpleFuzzy
{
    public partial class LogicMasterRules : UserControl
    {
        IVariable variable;
        public IVariable VarName { set { label1.Text = value.Name(); label2.Text = $"-> {value.Name()}"; variable = value; } }

        List<LogicMasterOperation> logicMasterOperation = new List<LogicMasterOperation>();

        private List<IVariable> linVars;
        public List<IVariable> LinVars
        {
            get => linVars;
            set
            {
                linVars = value;
                comboBox1.Items.Clear();
                foreach (var item in linVars)
                {
                    comboBox1.Items.Add(item.Name());
                }
                comboBox1.SelectedIndex = 0;
            }
        }

        public LogicMasterRules()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogicMasterOperation var = new LogicMasterOperation();
            if (logicMasterOperation.Count > 0)
                var.Location = new Point(10, logicMasterOperation[^1].Location.Y + logicMasterOperation[^1].Height);
            else
                var.Location = new Point(10, 100);
            var.LogicFazifications = LinVars;
            foreach (var value in logicMasterOperation)
            {
                value.Renamed += var.Rename;
            }
            var.Renamed += Rename;
            Controls.Add(var);
            logicMasterOperation.Add(var);
            LinVars.Add(var);
            panel1.Location = new Point(10, logicMasterOperation[^1].Location.Y + logicMasterOperation[^1].Height);
            comboBox1.Items.Add(var.VarName);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Remove(logicMasterOperation[^1]);
            logicMasterOperation[^1].Dispose();
            logicMasterOperation.RemoveAt(logicMasterOperation.Count - 1);
            LinVars.RemoveAt(LinVars.Count - 1);
            if (logicMasterOperation.Count == 0)
            {
                button2.Enabled = false;
                panel1.Location = new Point(10, 50);
            }
            else
            {
                panel1.Location = new Point(10, logicMasterOperation[^1].Location.Y + logicMasterOperation[^1].Height);
            }
        }

        public void Rename(object sender, RenamedEventArgs e)
        {
            comboBox1.Items[comboBox1.Items.IndexOf(e.OldName)] = e.Name;
        }

        public void RuleChange(object sender, EventArgs e)
        {
            LogicMasterRules prev = sender as LogicMasterRules;
            Location = new Point(10, prev.Location.Y + prev.Height + 10);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[variable.Count()];
            for (int i = 0; i < column.Length; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
            }
            dataGridView1.Columns.AddRange(column);
            dataGridView1.Rows.Add(linVars[comboBox1.SelectedIndex].Count());
        }
    }
}
