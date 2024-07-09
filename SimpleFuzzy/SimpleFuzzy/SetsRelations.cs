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
    public partial class SetsRelations : UserControl
    {
        Module<IBaseSet> BaseSet { get; set; }
        Module<IHasFunc> HasFunc1 { get; set; }
        Module<IHasFunc> HasFunc2 { get; set; }
        List<(object, double, double)> Values { get; set; }
        public SetsRelations()
        {
            InitializeComponent();
            BaseSet = new Module<IBaseSet>("Базовое множество", ModuleChecker);
            BaseSet.Location = new Point(10, 20);
            Controls.Add(BaseSet);
            HasFunc1 = new Module<IHasFunc>("Функция принадлежности A", ModuleChecker);
            HasFunc1.Location = new Point(10, 80);
            Controls.Add(HasFunc1);
            HasFunc2 = new Module<IHasFunc>("Функция принадлежности B", ModuleChecker);
            HasFunc2.Location = new Point(10, 140);
            Controls.Add(HasFunc2);
        }

        private bool ModuleChecker()
        {
            if (BaseSet.now != null && HasFunc1.now != null && HasFunc2.now != null)
            {
                BaseSet.now.ToFirst();
                if (BaseSet.now.Get().GetType() == HasFunc1.now.GetInputType && BaseSet.now.Get().GetType() == HasFunc2.now.GetInputType)
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
            Values = new List<(object, double, double)>();
            BaseSet.now.ToFirst();
            while (!BaseSet.now.IsEnd())
            {
                object x = BaseSet.now.Get();
                Values.Add((x, HasFunc1.now.GetResult(x), HasFunc2.now.GetResult(x)));
                BaseSet.now.ToNext();
            }
            pictureBox1.Refresh();
            pictureBox1.Visible = true;
            numericUpDown1.Visible = true;
            label2.Visible = true;
            label3.Text = Values.All(t => t.Item3 <= t.Item2) ? "B ⊆ A" : "B НЕ является нечетким подмножеством A";
            label3.Visible = true;
            label4.Text = Values.All(t => t.Item3 >= t.Item2) ? "A ⊆ B" : "A НЕ является нечетким подмножеством B";
            label4.Visible = true;
            var coreA = Values.Where(t => t.Item2 == 1).ToList();
            var coreB = Values.Where(t => t.Item3 == 1).ToList();
            bool coreIsEqual = coreA.Count == coreB.Count;
            for (int i = 0; i < coreA.Count && coreIsEqual; i++)
                if (coreA[i] != coreB[i]) coreIsEqual = false;
            label5.Text = coreIsEqual ? "A и B - fuzzy подобны" : "A и B - НЕ fuzzy подобны";
            label5.Visible = true;
            var actionZoneA = Values.Where(t => t.Item2 != 0).ToList();
            var actionZoneB = Values.Where(t => t.Item3 != 0).ToList();
            bool actionZoneIsEqual = coreA.Count == coreB.Count;
            for (int i = 0; i < coreA.Count && actionZoneIsEqual; i++)
                if (coreA[i] != coreB[i]) actionZoneIsEqual = false;
            label6.Text = actionZoneIsEqual ? "A и B - строго fuzzy подобны" : "A и B - НЕ строго fuzzy подобны";
            label6.Visible = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
            checkBox5.Visible = true;
            checkBox6.Visible = true;
            checkBox7.Visible = true;
            checkBox8.Visible = true;
            checkBox9.Visible = true;
            checkBox10.Visible = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen xyz = new Pen(Color.Black, 3);
            Pen curveA = new Pen(Color.Red, 2);
            Pen curveB = new Pen(Color.Blue, 2);
            graphics.DrawLine(xyz, 5, 195, pictureBox1.Width - 5, 195);
            TextRenderer.DrawText(graphics, "1", this.Font, new Point(0, 5), SystemColors.ControlText);
            graphics.DrawLine(xyz, 5, 5, pictureBox1.Width - 5, 5);
            TextRenderer.DrawText(graphics, "0", this.Font, new Point(0, 195), SystemColors.ControlText);
            for (int i = 1; i < Values.Count; i++)
            {
                DrawLine(graphics, curveA, curveB, i, x => x);
                if (Values.Count <= numericUpDown1.Value)
                {
                    TextRenderer.DrawText(graphics, Values[i - 1].Item1.ToString(),
                    this.Font, new Point((i - 1) * (pictureBox1.Width - 10) / Values.Count + 5, i % 2 == 0 ? 200 : 210),
                    SystemColors.ControlText);
                }
            }
            List<(object, double)> smalCurve;
            if (checkBox1.Checked)
                DrawLine(graphics, new Pen(Color.Violet, 2), Values.ConvertAll(t => (t.Item1, Math.Min(t.Item2, t.Item3))), x => x);
            if (checkBox3.Checked)
                DrawLine(graphics, new Pen(Color.Green, 2), Values.ConvertAll(t => (t.Item1, Math.Max(0, t.Item2 + t.Item3 - 1))), x => x);
            if (checkBox5.Checked)
                DrawLine(graphics, new Pen(Color.Gold, 2), Values.ConvertAll(t => (t.Item1, t.Item2 * t.Item3)), x => x);
            if (checkBox4.Checked)
                DrawLine(graphics, new Pen(Color.HotPink, 2), Values.ConvertAll(t => (t.Item1, (t.Item2 * t.Item3) / (2 - (t.Item2 + t.Item3 - t.Item2 * t.Item3)))), x => x);
            if (checkBox6.Checked)
                DrawLine(graphics, new Pen(Color.Brown, 2), Values.ConvertAll(t => (t.Item1, (t.Item2 + t.Item3 - t.Item2 * t.Item3 > 0) ? (t.Item2 * t.Item3) / (t.Item2 + t.Item3 - t.Item2 * t.Item3) : 0)), x => x);
            if (checkBox2.Checked)
                DrawLine(graphics, new Pen(Color.Violet, 2), Values.ConvertAll(t => (t.Item1, Math.Max(t.Item2, t.Item3))), x => x);
            if (checkBox10.Checked)
                DrawLine(graphics, new Pen(Color.Green, 2), Values.ConvertAll(t => (t.Item1, Math.Min(1, t.Item2 + t.Item3))), x => x);
            if (checkBox9.Checked)
                DrawLine(graphics, new Pen(Color.Gold, 2), Values.ConvertAll(t => (t.Item1, t.Item2 + t.Item3 - t.Item2 * t.Item3)), x => x);
            if (checkBox8.Checked)
                DrawLine(graphics, new Pen(Color.HotPink, 2), Values.ConvertAll(t => (t.Item1, (t.Item2 + t.Item3) / (1 + t.Item2 * t.Item3))), x => x);
            if (checkBox7.Checked)
                DrawLine(graphics, new Pen(Color.Brown, 2), Values.ConvertAll(t => (t.Item1, t.Item2 != 1 || t.Item3 != 1 ? (t.Item2 + t.Item3 - 2 * t.Item2 * t.Item3) / (1 - t.Item2 * t.Item3) : 1)), x => x);
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

        private void DrawLine(Graphics graphics, Pen curve1, Pen curve2, int i, Func<double, double> func)
        {
            graphics.DrawLine(curve1,
                    (i - 1) * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i - 1].Item2) * 190),
                    i * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i].Item2) * 190));
            graphics.DrawLine(curve2,
                    (i - 1) * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i - 1].Item3) * 190),
                    i * (pictureBox1.Width - 10) / Values.Count + 5,
                    (float)(195 - func(Values[i].Item3) * 190));
        }

        private void DrawLine(Graphics graphics, Pen curve1, List<(object, double)> curve, Func<double, double> func)
        {
            for (int i = 1; i < curve.Count; i++)
                graphics.DrawLine(curve1,
                    (i - 1) * (pictureBox1.Width - 10) / curve.Count + 5,
                    (float)(195 - func(curve[i - 1].Item2) * 190),
                    i * (pictureBox1.Width - 10) / curve.Count + 5,
                    (float)(195 - func(curve[i].Item2) * 190));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
