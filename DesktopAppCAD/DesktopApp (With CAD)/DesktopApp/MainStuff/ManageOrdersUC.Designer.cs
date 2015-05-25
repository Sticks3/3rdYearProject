namespace DesktopApp
{
    partial class ManageOrdersUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabCManOrders = new System.Windows.Forms.TabControl();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.tabHide = new System.Windows.Forms.TabPage();
            this.ViewOrderDetailsTbl = new System.Windows.Forms.TabPage();
            this.ViewStuffTable = new System.Windows.Forms.DataGridView();
            this.lblEngineers = new System.Windows.Forms.Label();
            this.lblManage = new System.Windows.Forms.Label();
            this.tabCManOrders.SuspendLayout();
            this.ViewOrderDetailsTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCManOrders
            // 
            this.tabCManOrders.Controls.Add(this.tabEdit);
            this.tabCManOrders.Controls.Add(this.tabHide);
            this.tabCManOrders.Controls.Add(this.ViewOrderDetailsTbl);
            this.tabCManOrders.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCManOrders.Location = new System.Drawing.Point(9, 39);
            this.tabCManOrders.Name = "tabCManOrders";
            this.tabCManOrders.SelectedIndex = 0;
            this.tabCManOrders.Size = new System.Drawing.Size(1600, 919);
            this.tabCManOrders.TabIndex = 71;
            this.tabCManOrders.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCManOrders_Selected);
            // 
            // tabEdit
            // 
            this.tabEdit.Location = new System.Drawing.Point(4, 38);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(1592, 877);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "Edit Order";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // tabHide
            // 
            this.tabHide.Location = new System.Drawing.Point(4, 38);
            this.tabHide.Name = "tabHide";
            this.tabHide.Size = new System.Drawing.Size(1592, 877);
            this.tabHide.TabIndex = 2;
            this.tabHide.Text = "Hide/Unhide Order";
            this.tabHide.UseVisualStyleBackColor = true;
            // 
            // ViewOrderDetailsTbl
            // 
            this.ViewOrderDetailsTbl.Controls.Add(this.ViewStuffTable);
            this.ViewOrderDetailsTbl.Location = new System.Drawing.Point(4, 38);
            this.ViewOrderDetailsTbl.Name = "ViewOrderDetailsTbl";
            this.ViewOrderDetailsTbl.Size = new System.Drawing.Size(1592, 877);
            this.ViewOrderDetailsTbl.TabIndex = 3;
            this.ViewOrderDetailsTbl.Text = "View Order Details";
            this.ViewOrderDetailsTbl.UseVisualStyleBackColor = true;
            // 
            // ViewStuffTable
            // 
            this.ViewStuffTable.AllowUserToAddRows = false;
            this.ViewStuffTable.AllowUserToDeleteRows = false;
            this.ViewStuffTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ViewStuffTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ViewStuffTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewStuffTable.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.ViewStuffTable.Location = new System.Drawing.Point(0, 0);
            this.ViewStuffTable.Name = "ViewStuffTable";
            this.ViewStuffTable.ReadOnly = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ViewStuffTable.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ViewStuffTable.Size = new System.Drawing.Size(1530, 755);
            this.ViewStuffTable.TabIndex = 60;
            // 
            // lblEngineers
            // 
            this.lblEngineers.AutoSize = true;
            this.lblEngineers.BackColor = System.Drawing.Color.Transparent;
            this.lblEngineers.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineers.ForeColor = System.Drawing.Color.Black;
            this.lblEngineers.Location = new System.Drawing.Point(124, 0);
            this.lblEngineers.Name = "lblEngineers";
            this.lblEngineers.Size = new System.Drawing.Size(111, 36);
            this.lblEngineers.TabIndex = 73;
            this.lblEngineers.Text = "ORDERS";
            // 
            // lblManage
            // 
            this.lblManage.AutoSize = true;
            this.lblManage.BackColor = System.Drawing.Color.Transparent;
            this.lblManage.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManage.ForeColor = System.Drawing.Color.Black;
            this.lblManage.Location = new System.Drawing.Point(3, 0);
            this.lblManage.Name = "lblManage";
            this.lblManage.Size = new System.Drawing.Size(127, 36);
            this.lblManage.TabIndex = 72;
            this.lblManage.Text = "MANAGE";
            // 
            // ManageOrdersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEngineers);
            this.Controls.Add(this.lblManage);
            this.Controls.Add(this.tabCManOrders);
            this.Name = "ManageOrdersUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.tabCManOrders.ResumeLayout(false);
            this.ViewOrderDetailsTbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCManOrders;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TabPage tabHide;
        private System.Windows.Forms.TabPage ViewOrderDetailsTbl;
        private System.Windows.Forms.DataGridView ViewStuffTable;
        private System.Windows.Forms.Label lblEngineers;
        private System.Windows.Forms.Label lblManage;
    }
}
