namespace SimpleFuzzy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            setsToolStripMenuItem = new ToolStripMenuItem();
            setPropertiesToolStripMenuItem = new ToolStripMenuItem();
            setsReToolStripMenuItem = new ToolStripMenuItem();
            ndimensionalSetsToolStripMenuItem = new ToolStripMenuItem();
            logicToolStripMenuItem = new ToolStripMenuItem();
            logicFazificationToolStripMenuItem = new ToolStripMenuItem();
            logicOperationToolStripMenuItem = new ToolStripMenuItem();
            lingvisticRulesToolStripMenuItem = new ToolStripMenuItem();
            loToolStripMenuItem = new ToolStripMenuItem();
            controlsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { setsToolStripMenuItem, logicToolStripMenuItem, controlsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // setsToolStripMenuItem
            // 
            setsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setPropertiesToolStripMenuItem, setsReToolStripMenuItem, ndimensionalSetsToolStripMenuItem });
            setsToolStripMenuItem.Name = "setsToolStripMenuItem";
            setsToolStripMenuItem.Size = new Size(40, 20);
            setsToolStripMenuItem.Text = "Sets";
            // 
            // setPropertiesToolStripMenuItem
            // 
            setPropertiesToolStripMenuItem.Name = "setPropertiesToolStripMenuItem";
            setPropertiesToolStripMenuItem.Size = new Size(177, 22);
            setPropertiesToolStripMenuItem.Text = "Set Properties";
            setPropertiesToolStripMenuItem.Click += setPropertiesToolStripMenuItem_Click;
            // 
            // setsReToolStripMenuItem
            // 
            setsReToolStripMenuItem.Name = "setsReToolStripMenuItem";
            setsReToolStripMenuItem.Size = new Size(177, 22);
            setsReToolStripMenuItem.Text = "Sets Relations";
            setsReToolStripMenuItem.Click += setsReToolStripMenuItem_Click;
            // 
            // ndimensionalSetsToolStripMenuItem
            // 
            ndimensionalSetsToolStripMenuItem.Name = "ndimensionalSetsToolStripMenuItem";
            ndimensionalSetsToolStripMenuItem.Size = new Size(177, 22);
            ndimensionalSetsToolStripMenuItem.Text = "N-dimensional Sets";
            ndimensionalSetsToolStripMenuItem.Click += ndimensionalSetsToolStripMenuItem_Click;
            // 
            // logicToolStripMenuItem
            // 
            logicToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logicFazificationToolStripMenuItem, logicOperationToolStripMenuItem, lingvisticRulesToolStripMenuItem, loToolStripMenuItem });
            logicToolStripMenuItem.Name = "logicToolStripMenuItem";
            logicToolStripMenuItem.Size = new Size(48, 20);
            logicToolStripMenuItem.Text = "Logic";
            // 
            // logicFazificationToolStripMenuItem
            // 
            logicFazificationToolStripMenuItem.Name = "logicFazificationToolStripMenuItem";
            logicFazificationToolStripMenuItem.Size = new Size(163, 22);
            logicFazificationToolStripMenuItem.Text = "LogicFazification";
            logicFazificationToolStripMenuItem.Click += logicFazificationToolStripMenuItem_Click;
            // 
            // logicOperationToolStripMenuItem
            // 
            logicOperationToolStripMenuItem.Name = "logicOperationToolStripMenuItem";
            logicOperationToolStripMenuItem.Size = new Size(163, 22);
            logicOperationToolStripMenuItem.Text = "LogicOperation";
            logicOperationToolStripMenuItem.Click += logicOperationToolStripMenuItem_Click;
            // 
            // lingvisticRulesToolStripMenuItem
            // 
            lingvisticRulesToolStripMenuItem.Name = "lingvisticRulesToolStripMenuItem";
            lingvisticRulesToolStripMenuItem.Size = new Size(163, 22);
            lingvisticRulesToolStripMenuItem.Text = "LingvisticRules";
            lingvisticRulesToolStripMenuItem.Click += lingvisticRulesToolStripMenuItem_Click;
            // 
            // loToolStripMenuItem
            // 
            loToolStripMenuItem.Name = "loToolStripMenuItem";
            loToolStripMenuItem.Size = new Size(163, 22);
            loToolStripMenuItem.Text = "LogicResults";
            loToolStripMenuItem.Click += logicResultsToolStripMenuItem_Click;
            // 
            // controlsToolStripMenuItem
            // 
            controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            controlsToolStripMenuItem.Size = new Size(64, 20);
            controlsToolStripMenuItem.Text = "Controls";
            controlsToolStripMenuItem.Click += controlsToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 473);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem setsToolStripMenuItem;
        private ToolStripMenuItem setPropertiesToolStripMenuItem;
        private ToolStripMenuItem setsReToolStripMenuItem;
        private ToolStripMenuItem ndimensionalSetsToolStripMenuItem;
        private ToolStripMenuItem logicToolStripMenuItem;
        private ToolStripMenuItem logicFazificationToolStripMenuItem;
        private ToolStripMenuItem logicOperationToolStripMenuItem;
        private ToolStripMenuItem lingvisticRulesToolStripMenuItem;
        private ToolStripMenuItem loToolStripMenuItem;
        private ToolStripMenuItem controlsToolStripMenuItem;
    }
}