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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SimpleFuzzy
{
    public partial class LogicOperation : UserControl
    {
        Module<IBaseSet> BaseSet { get; set; }
        Module<IHasFunc> HasFunc1 { get; set; }
        Module<IHasFunc> HasFunc2 { get; set; }
        List<object> Values { get; set; }
        public LogicOperation()
        {
            InitializeComponent();
            BaseSet = new Module<IBaseSet>("Базовое множество", ModuleChecker);
            BaseSet.Location = new Point(10, 20);
            Controls.Add(BaseSet);
            HasFunc1 = new Module<IHasFunc>("Логическое выссказывание A", ModuleChecker);
            HasFunc1.Location = new Point(10, 80);
            Controls.Add(HasFunc1);
            HasFunc2 = new Module<IHasFunc>("Логическое выссказывание B", ModuleChecker);
            HasFunc2.Location = new Point(10, 140);
            Controls.Add(HasFunc2);
        }

        private bool ModuleChecker()
        {
            double i;
            if (!double.TryParse(textBox1.Text, out i))
            {
                label1.Text = "γ - не число";
                button1.Enabled = false;
                label2.Visible = false;
                comboBox1.Visible = false;
                return false;
            }
            if (BaseSet.now != null && HasFunc1.now != null && HasFunc2.now != null)
            {
                BaseSet.now.ToFirst();
                if (BaseSet.now.Get().GetType() == HasFunc1.now.GetInputType && BaseSet.now.Get().GetType() == HasFunc2.now.GetInputType)
                {
                    label2.Visible = true;
                    comboBox1.Visible = true;
                    Values = new List<object>();
                    BaseSet.now.ToFirst();
                    while (!BaseSet.now.IsEnd())
                    {
                        object x = BaseSet.now.Get();
                        Values.Add(x);
                        BaseSet.now.ToNext();
                    }
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(Values.ConvertAll(t => t).ToArray());
                    comboBox1.SelectedIndex = 0;
                    button1.Enabled = true;
                    label1.Text = "";
                    return true;
                }
                else
                {
                    label1.Text = "Тип значения базового множества не совпадает с типом функции принадлежности";
                    button1.Enabled = false;
                    label2.Visible = false;
                    comboBox1.Visible = false;
                    return false;
                }
            }
            else
            {
                label1.Text = "Не все модули загружены";
                button1.Enabled = false;
                label2.Visible = false;
                comboBox1.Visible = false;
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double μA = HasFunc1.now.GetResult(comboBox1.SelectedItem);
            double μB = HasFunc2.now.GetResult(comboBox1.SelectedItem);
            double γ = double.Parse(textBox1.Text);
            label4.Text = $"Fuzzy- A \"И\" B = {γ * Math.Min(μA, μB) + 0.5 * (1 - γ) * (μA + μB)}";
            label4.Visible = true;
            label5.Text = $"Fuzzy- A \"ИЛИ\" B = {γ * Math.Max(μA, μB) + 0.5 * (1 - γ) * (μA + μB)}";
            label5.Visible = true;
            label6.Text = $"γ-оператор A - B = {Math.Pow(μA * μB, 1 - γ) * (1 - (1 - μA) * (1 - μB))}";
            label6.Visible = true;
            label7.Text = $"Min-Max A \"И\" B = {Math.Min(μA, μB)}";
            label8.Text = $"Min-Max A \"ИЛИ\" B = {Math.Max(μA, μB)}";
            if (Math.Max(μA, μB) == 1)
                label9.Text = $"усиленное произведение A \"И\" B = {Math.Min(μA, μB)}";
            else
                label9.Text = $"усиленное произведение A \"И\" B = 0";
            if (Math.Min(μA, μB) == 0)
                label10.Text = $"усиленная сумма A \"ИЛИ\" B = {Math.Max(μA, μB)}";
            else
                label10.Text = $"усиленная сумма A \"ИЛИ\" B = 0";
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Text = $"Lukasiewicz A \"И\" B = {Math.Max(0, μA + μB - 1)}";
            label12.Text = $"Lukasiewicz A \"ИЛИ\" B = {Math.Min(1, μA + μB)}";
            label13.Text = $"Эйнштейновское A \"И\" B = {(μA * μB) / (2 - (μA + μB - μA * μB))}";
            label14.Text = $"Эйнштейновское A \"ИЛИ\" B = {(μA + μB) / (1 + μA * μB)}";
            label15.Text = $"алгебраическое A \"И\" B = {μA * μB}";
            label16.Text = $"алгебраическое A \"ИЛИ\" B = {μA + μB - μA * μB}";
            label17.Text = $"Lukasiewicz A \"ИЛИ\" B = {Math.Min(1, μA + μB)}";
            label18.Text = $"Xамахеровское A \"И\" B = {(μA * μB) / (μA + μB - μA * μB)}";
            label19.Text = $"Xамахеровское A \"ИЛИ\" B = {(μA + μB - 2 * μA * μB) / (1 - μA * μB)}";
            label20.Text = "Не реализовано";//$"Ягеровское A \"И\" B = {μA * μB}";
            label21.Text = "Не реализовано";//$"Ягеровское A \"ИЛИ\" B = {μA + μB - μA * μB}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
            => ModuleChecker();
    }
}
