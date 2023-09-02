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
        {

        }

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