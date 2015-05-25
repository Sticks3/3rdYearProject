namespace DesktopApp
{
    partial class InvoicesUC
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
            this.lblProClientOrder = new System.Windows.Forms.Label();
            this.cbProClientOrder = new System.Windows.Forms.ComboBox();
            this.lblSelectClient = new System.Windows.Forms.Label();
            this.cbSelectClient = new System.Windows.Forms.ComboBox();
            this.lblInvoices = new System.Windows.Forms.Label();
            this.lblView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProClientOrder
            // 
            this.lblProClientOrder.AutoSize = true;
            this.lblProClientOrder.BackColor = System.Drawing.Color.Transparent;
            this.lblProClientOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProClientOrder.ForeColor = System.Drawing.Color.Black;
            this.lblProClientOrder.Location = new System.Drawing.Point(313, 53);
            this.lblProClientOrder.Name = "lblProClientOrder";
            this.lblProClientOrder.Size = new System.Drawing.Size(246, 29);
            this.lblProClientOrder.TabIndex = 97;
            this.lblProClientOrder.Text = "Product Client Ordered:";
            // 
            // cbProClientOrder
            // 
            this.cbProClientOrder.BackColor = System.Drawing.SystemColors.Window;
            this.cbProClientOrder.DropDownWidth = 700;
            this.cbProClientOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProClientOrder.ForeColor = System.Drawing.Color.Black;
            this.cbProClientOrder.FormattingEnabled = true;
            this.cbProClientOrder.Location = new System.Drawing.Point(565, 50);
            this.cbProClientOrder.Name = "cbProClientOrder";
            this.cbProClientOrder.Size = new System.Drawing.Size(367, 37);
            this.cbProClientOrder.TabIndex = 96;
            this.cbProClientOrder.DropDown += new System.EventHandler(this.cbProClientOrder_DropDown);
            this.cbProClientOrder.SelectedIndexChanged += new System.EventHandler(this.cbProClientOrder_SelectedIndexChanged);
            // 
            // lblSelectClient
            // 
            this.lblSelectClient.AutoSize = true;
            this.lblSelectClient.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectClient.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectClient.ForeColor = System.Drawing.Color.Black;
            this.lblSelectClient.Location = new System.Drawing.Point(16, 53);
            this.lblSelectClient.Name = "lblSelectClient";
            this.lblSelectClient.Size = new System.Drawing.Size(77, 29);
            this.lblSelectClient.TabIndex = 95;
            this.lblSelectClient.Text = "Client:";
            // 
            // cbSelectClient
            // 
            this.cbSelectClient.BackColor = System.Drawing.SystemColors.Window;
            this.cbSelectClient.DropDownWidth = 350;
            this.cbSelectClient.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectClient.ForeColor = System.Drawing.Color.Black;
            this.cbSelectClient.FormattingEnabled = true;
            this.cbSelectClient.Location = new System.Drawing.Point(104, 50);
            this.cbSelectClient.Name = "cbSelectClient";
            this.cbSelectClient.Size = new System.Drawing.Size(179, 37);
            this.cbSelectClient.TabIndex = 94;
            this.cbSelectClient.DropDown += new System.EventHandler(this.cbSelectClient_DropDown);
            this.cbSelectClient.SelectedIndexChanged += new System.EventHandler(this.cbSelectClient_SelectedIndexChanged);
            // 
            // lblInvoices
            // 
            this.lblInvoices.AutoSize = true;
            this.lblInvoices.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoices.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoices.ForeColor = System.Drawing.Color.Black;
            this.lblInvoices.Location = new System.Drawing.Point(75, 0);
            this.lblInvoices.Name = "lblInvoices";
            this.lblInvoices.Size = new System.Drawing.Size(125, 36);
            this.lblInvoices.TabIndex = 99;
            this.lblInvoices.Text = "INVOICES";
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.BackColor = System.Drawing.Color.Transparent;
            this.lblView.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.ForeColor = System.Drawing.Color.Black;
            this.lblView.Location = new System.Drawing.Point(3, 0);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(80, 36);
            this.lblView.TabIndex = 98;
            this.lblView.Text = "VIEW";
            // 
            // InvoicesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInvoices);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.lblProClientOrder);
            this.Controls.Add(this.cbProClientOrder);
            this.Controls.Add(this.lblSelectClient);
            this.Controls.Add(this.cbSelectClient);
            this.Name = "InvoicesUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProClientOrder;
        private System.Windows.Forms.ComboBox cbProClientOrder;
        private System.Windows.Forms.Label lblSelectClient;
        private System.Windows.Forms.ComboBox cbSelectClient;
        private System.Windows.Forms.Label lblInvoices;
        private System.Windows.Forms.Label lblView;
    }
}
