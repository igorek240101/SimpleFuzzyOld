using System.Reflection;

namespace SimpleFuzzy
{
    public partial class Form1 : Form
    {
        UserControl nowPanel;
        Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>();

        public Form1()
        {
            InitializeComponent();
        }


        private void setPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("setProperties", typeof(SetProperty).GetConstructors()[0]);


        private void setsReToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("setsRelations", typeof(SetsRelations).GetConstructors()[0]);

        private void ndimensionalSetsToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("ndimensionalSets", typeof(NDimensionalSets).GetConstructors()[0]);

        private void logicFazificationToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("logicFazification", typeof(LogicFazification).GetConstructors()[0]);

        private void logicOperationToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("logicOperation", typeof(LogicOperation).GetConstructors()[0]);

        private void lingvisticRulesToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("lingvisticRules", typeof(LingvisticRules).GetConstructors()[0]);

        private void logicResultsToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("logicResults", typeof(LogicResults).GetConstructors()[0]);

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
            => SetPanel("fuzzyControl", typeof(FuzzyControl).GetConstructors()[0]);

        private void SetPanel(string key, ConstructorInfo constructor)
        {
            if (nowPanel != null)
            {
                nowPanel.Visible = false;
            }
            UserControl newPanel = null;
            if (!userControls.TryGetValue(key, out newPanel))
            {
                newPanel = constructor.Invoke(null) as UserControl;
                userControls.Add(key, newPanel);
                Controls.Add(newPanel);
            }
            else
            {
                newPanel.Visible = true;
            }
            nowPanel = newPanel;
        }


    }
}