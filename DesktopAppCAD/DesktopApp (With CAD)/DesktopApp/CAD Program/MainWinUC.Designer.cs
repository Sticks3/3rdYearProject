namespace DesktopApp.CAD_Program
{
    partial class MainWinUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_mainMenu = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.m_aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_mainMenu
            // 
            this.m_mainMenu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.m_helpMenu});
            this.m_mainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_mainMenu.Name = "m_mainMenu";
            this.m_mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.m_mainMenu.Size = new System.Drawing.Size(1092, 27);
            this.m_mainMenu.TabIndex = 1;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem1,
            this.layersToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(72, 23);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(120, 24);
            this.optionsToolStripMenuItem1.Tag = "Grid";
            this.optionsToolStripMenuItem1.Text = "&Grid";
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.layersToolStripMenuItem.Tag = "Layers";
            this.layersToolStripMenuItem.Text = "Layers";
            // 
            // m_helpMenu
            // 
            this.m_helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_aboutMenuItem});
            this.m_helpMenu.Name = "m_helpMenu";
            this.m_helpMenu.Size = new System.Drawing.Size(51, 23);
            this.m_helpMenu.Text = "&Help";
            // 
            // m_aboutMenuItem
            // 
            this.m_aboutMenuItem.Name = "m_aboutMenuItem";
            this.m_aboutMenuItem.Size = new System.Drawing.Size(116, 24);
            this.m_aboutMenuItem.Text = "&About";
            // 
            // MainWinUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_mainMenu);
            this.Name = "MainWinUC";
            this.Size = new System.Drawing.Size(1092, 799);
            this.m_mainMenu.ResumeLayout(false);
            this.m_mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_mainMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_helpMenu;
        private System.Windows.Forms.ToolStripMenuItem m_aboutMenuItem;
    }
}
