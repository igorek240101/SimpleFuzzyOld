namespace SimpleFuzzy
{
    public partial class LogicResults : UserControl
    {
        public LogicResults()
        {
            InitializeComponent();
            logicFazification2.IsOutput = true;
            logicFazification2.Action = () =>
            {
                if (dataGridView1.ColumnCount == logicFazification2.Count() &&
                dataGridView1.RowCount == logicFazification1.Count())
                    logicFazification2.Result = Mul(logicFazification1.Result, Table);
            };
            dataGridView1.AutoSize = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            if (logicFazification1.Count() > 0 && logicFazification2.Count() > 0)
            {
                DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[logicFazification2.Count()];
                for (int i = 0; i < column.Length; i++)
                {
                    column[i] = new DataGridViewTextBoxColumn();
                }
                dataGridView1.Columns.AddRange(column);
                dataGridView1.Rows.Add(logicFazification1.Count());
            }
        }

        public double[,] Table
        {
            get
            {
                double[,] table = new double[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        if (dataGridView1[j, i].Value == null)
                            table[i, j] = 0;
                        else if (!double.TryParse(dataGridView1[j, i].Value.ToString(), out table[i, j]))
                            table[i, j] = 0;
                    }
                }
                return table;
            }
        }

        public List<(int, double)> Mul(List<(int, double)> input, double[,] table)
        {
            List<(int, double)> result = new List<(int, double)>();
            if (input != null)
            {
                for (int i = 0; i < table.GetLength(1); i++)
                {
                    double max = 0;
                    if (input.Count != 0)
                        max = Math.Min(input[0].Item2, table[input[0].Item1, i]);
                    for (int j = 1; j < input.Count; j++)
                    {
                        max = Math.Max(max, Math.Min(input[j].Item2, table[input[j].Item1, i]));
                    }
                    if (max > 0) result.Add((i, max));
                }
            }
            return result;
        }
    }
}
