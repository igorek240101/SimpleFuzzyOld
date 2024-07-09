using SimpleFuzzy.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFuzzy
{
    public partial class NDimensionalSets : UserControl
    {
        List<(Module<IBaseSet>, Module<IHasFunc>)> Sets { get; set; } = new List<(Module<IBaseSet>, Module<IHasFunc>)>();
        public NDimensionalSets()
        {
            InitializeComponent();
            dataGridView1.AutoSize = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Module<IBaseSet> baseSet = new Module<IBaseSet>($"Базовое множество {(char)('A' + Sets.Count)}", ModuleChecker);
            Module<IHasFunc> func = new Module<IHasFunc>($"Функция принадлежности {(char)('A' + Sets.Count)}", ModuleChecker);
            baseSet.Location = new Point(10, Sets.Count * 70 + 100);
            func.Location = new Point(575, Sets.Count * 70 + 100);
            Controls.Add(baseSet);
            Controls.Add(func);
            Sets.Add((baseSet, func));
            button2.Enabled = true;
            panel1.Location = new Point(0, (Sets.Count + 1) * 70 + 40);
            ModuleChecker();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Remove(Sets[^1].Item1);
            Controls.Remove(Sets[^1].Item2);
            Sets[^1].Item1.Dispose();
            Sets[^1].Item2.Dispose();
            Sets.RemoveAt(Sets.Count - 1);
            if (Sets.Count == 0) button2.Enabled = false;
            panel1.Location = new Point(0, (Sets.Count + 1) * 70 + 40);
            ModuleChecker();
        }

        private bool ModuleChecker()
        {
            if (Sets.Count < 2)
            {
                label1.Text = "Недостаточно модулей";
                button3.Enabled = false;
                return false;
            }
            foreach (var item in Sets)
            {
                if (item.Item1.now != null && item.Item2.now != null)
                {
                    item.Item1.now.ToFirst();
                    if (item.Item1.now.Get().GetType() == item.Item2.now.GetInputType)
                    {
                        button3.Enabled = true;
                        label1.Text = "";
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
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<List<(object, double)>> values = new List<List<(object, double)>>();
            foreach (var item in Sets)
            {
                values.Add(new List<(object, double)>());
                item.Item1.now.ToFirst();
                while (!item.Item1.now.IsEnd())
                {
                    object x = item.Item1.now.Get();
                    values[^1].Add((x, item.Item2.now.GetResult(x)));
                    item.Item1.now.ToNext();
                }
            }
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[values[0].Count + values.Count - 1];
            for (int i = 0; i < values.Count - 1; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
                column[i].HeaderText = "";
                column[i].Name = "";
            }
            for (int i = 0; i < values[0].Count; i++)
            {
                column[i + values.Count - 1] = new DataGridViewTextBoxColumn();
                column[i + values.Count - 1].HeaderText = values[0][i].Item1.ToString();
                column[i + values.Count - 1].Name = values[0][i].Item1.ToString();
            }
            dataGridView1.Columns.AddRange(column);
            int rowCounts = 1;
            for (int i = 1; i < values.Count; i++) rowCounts *= values[i].Count;
            for (int i = 0; i < rowCounts; i++)
            {
                string[] results = new string[values[0].Count + values.Count - 1];
                int dev = 1;
                for (int j = values.Count - 2; j >= 0; j--)
                {
                    results[j] = values[j + 1][(i / dev) % values[j + 1].Count].Item1.ToString();
                    dev *= values[j + 1].Count;
                }
                for (int j = 0; j < values[0].Count; j++)
                {
                    dev = 1;
                    double min = values[0][j].Item2;
                    for (int k = values.Count - 2; k >= 0; k--)
                    {
                        if (radioButton1.Checked)
                            min = Math.Min(min, values[k + 1][(i / dev) % values[k + 1].Count].Item2);
                        else
                            min = Math.Max(min, values[k + 1][(i / dev) % values[k + 1].Count].Item2);
                        dev *= values[k + 1].Count;
                    }
                    results[j + values.Count - 1] = min.ToString();
                }
                dataGridView1.Rows.Add(results);
            }
        }
    }
}
