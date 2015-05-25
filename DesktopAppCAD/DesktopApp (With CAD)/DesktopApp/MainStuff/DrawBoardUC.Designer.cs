namespace DesktopApp
{
    partial class DrawBoardUC
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
            this.tabCManClients = new System.Windows.Forms.TabControl();
            this.tabDrawBoard = new System.Windows.Forms.TabPage();
            this.lblBoard = new System.Windows.Forms.Label();
            this.lblDraw = new System.Windows.Forms.Label();
            this.mainWinUC1 = new CAD_Program.MainWinUC();
            this.tabCManClients.SuspendLayout();
            this.tabDrawBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCManClients
            // 
            this.tabCManClients.Controls.Add(this.tabDrawBoard);
            this.tabCManClients.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCManClients.Location = new System.Drawing.Point(9, 39);
            this.tabCManClients.Name = "tabCManClients";
            this.tabCManClients.SelectedIndex = 0;
            this.tabCManClients.Size = new System.Drawing.Size(1600, 919);
            this.tabCManClients.TabIndex = 84;
            // 
            // tabDrawBoard
            // 
            this.tabDrawBoard.Controls.Add(this.mainWinUC1);
            this.tabDrawBoard.Location = new System.Drawing.Point(4, 38);
            this.tabDrawBoard.Name = "tabDrawBoard";
            this.tabDrawBoard.Size = new System.Drawing.Size(1592, 877);
            this.tabDrawBoard.TabIndex = 2;
            this.tabDrawBoard.Text = "Draw Board";
            this.tabDrawBoard.UseVisualStyleBackColor = true;
            // 
            // lblBoard
            // 
            this.lblBoard.AutoSize = true;
            this.lblBoard.BackColor = System.Drawing.Color.Transparent;
            this.lblBoard.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoard.ForeColor = System.Drawing.Color.Black;
            this.lblBoard.Location = new System.Drawing.Point(114, 0);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(103, 36);
            this.lblBoard.TabIndex = 101;
            this.lblBoard.Text = "BOARD";
            // 
            // lblDraw
            // 
            this.lblDraw.AutoSize = true;
            this.lblDraw.BackColor = System.Drawing.Color.Transparent;
            this.lblDraw.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraw.ForeColor = System.Drawing.Color.Black;
            this.lblDraw.Location = new System.Drawing.Point(16, 0);
            this.lblDraw.Name = "lblDraw";
            this.lblDraw.Size = new System.Drawing.Size(92, 36);
            this.lblDraw.TabIndex = 102;
            this.lblDraw.Text = "DRAW";
            // 
            // mainWinUC1
            // 
            this.mainWinUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWinUC1.Location = new System.Drawing.Point(0, 0);
            this.mainWinUC1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.mainWinUC1.Name = "mainWinUC1";
            this.mainWinUC1.Size = new System.Drawing.Size(1592, 877);
            this.mainWinUC1.TabIndex = 0;
            // 
            // DrawBoardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDraw);
            this.Controls.Add(this.lblBoard);
            this.Controls.Add(this.tabCManClients);
            this.Name = "DrawBoardUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.tabCManClients.ResumeLayout(false);
            this.tabDrawBoard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCManClients;
        private System.Windows.Forms.TabPage tabDrawBoard;
        private System.Windows.Forms.Label lblBoard;
        private System.Windows.Forms.Label lblDraw;
        private CAD_Program.MainWinUC mainWinUC1;
    }
}
