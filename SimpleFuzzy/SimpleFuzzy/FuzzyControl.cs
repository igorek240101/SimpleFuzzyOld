using System.Data;

namespace SimpleFuzzy
{

    public partial class FuzzyControl : UserControl
    {
        List<(LogicFazification, CheckBox)> logicFazifications = new List<(LogicFazification, CheckBox)>();
        Dictionary<LogicFazification, LogicMasterRules> logicRules = new Dictionary<LogicFazification, LogicMasterRules>();
        public FuzzyControl()
        {
            InitializeComponent();
            FazificationChecker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogicFazification var = new LogicFazification();
            panel1.Controls.Add(var);
            if (logicFazifications.Count > 0)
                var.Location = new Point(10, logicFazifications[^1].Item1.Location.Y + logicFazifications[^1].Item1.Height);
            else
                var.Location = new Point(10, 100);
            var.SizeChanged += Paint;
            CheckBox checkBox = new CheckBox();
            checkBox.CheckedChanged += Check;
            panel1.Controls.Add(checkBox);
            checkBox.Location = new Point(820, var.Location.Y);
            checkBox.Text = "Выходное значение";
            logicFazifications.Add((var, checkBox));
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Remove(logicFazifications[^1].Item1);
            panel1.Controls.Remove(logicFazifications[^1].Item2);
            logicFazifications[^1].Item1.Dispose();
            logicFazifications[^1].Item2.Dispose();
            logicFazifications.RemoveAt(logicFazifications.Count - 1);
            if (logicFazifications.Count == 0) button2.Enabled = false;
        }

        private void Paint(object sender, EventArgs e)
        {
            for (int i = 1; i < logicFazifications.Count; i++)
            {
                logicFazifications[i].Item1.Location = new Point(10, logicFazifications[i - 1].Item1.Location.Y + logicFazifications[i - 1].Item1.Height);
                logicFazifications[i].Item2.Location = new Point(820, logicFazifications[i - 1].Item1.Location.Y + logicFazifications[i - 1].Item1.Height);
            }
        }

        private bool FazificationChecker()
            => logicFazifications.Any(t => t.Item1.IsOutput) && logicFazifications.Any(t => !t.Item1.IsOutput) && logicFazifications.All(t => t.Item1.ModuleChecker());

        private void Check(object sender, EventArgs e)
        {
            var value = logicFazifications.FirstOrDefault(t => t.Item2 == sender);
            value.Item1.IsOutput = value.Item2.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (FazificationChecker())
            {
                panel1.Enabled = false;
                panel2.Visible = true;
                panel2.Enabled = true;
                panel3.Visible = false;
                panel2.Controls.Clear();
                panel2.Location = new Point(panel1.Location.X + panel1.Width + 10, panel1.Location.Y);
                LogicMasterRules prev = null;
                logicRules.Clear();
                foreach (var value in logicFazifications)
                {
                    if (value.Item2.Checked)
                    {
                        LogicMasterRules rules = new LogicMasterRules();
                        panel2.Controls.Add(rules);
                        rules.VarName = value.Item1;
                        rules.LinVars = logicFazifications.Where(t => !t.Item1.IsOutput).ToList().ConvertAll(t => t.Item1 as IVariable);
                        rules.Location = new Point(10, prev != null ? prev.Location.Y + prev.Height + 10 : 10);
                        if (prev != null)
                        {
                            prev.SizeChanged += rules.RuleChange;
                            prev.LocationChanged += rules.RuleChange;
                        }
                        logicRules.Add(value.Item1, rules);
                        prev = rules;
                    }
                }
            }
            else radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
        }


    }
}
