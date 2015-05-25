namespace DesktopApp
{
    partial class OrderStuffUC
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
            this.tabInputOrderInfo = new System.Windows.Forms.TabPage();
            this.gbOrderDetails = new System.Windows.Forms.GroupBox();
            this.cbProNameOrder = new System.Windows.Forms.ComboBox();
            this.cbCustNameOrder = new System.Windows.Forms.ComboBox();
            this.lblCustNameOrder = new System.Windows.Forms.Label();
            this.lblProNameOrder = new System.Windows.Forms.Label();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.lblDescOrder = new System.Windows.Forms.Label();
            this.lblQuanOrder = new System.Windows.Forms.Label();
            this.txtDescOrder = new System.Windows.Forms.TextBox();
            this.txtQuanOrder = new System.Windows.Forms.TextBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.lblManage = new System.Windows.Forms.Label();
            this.tabCManClients.SuspendLayout();
            this.tabInputOrderInfo.SuspendLayout();
            this.gbOrderDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCManClients
            // 
            this.tabCManClients.Controls.Add(this.tabInputOrderInfo);
            this.tabCManClients.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCManClients.Location = new System.Drawing.Point(9, 39);
            this.tabCManClients.Name = "tabCManClients";
            this.tabCManClients.SelectedIndex = 0;
            this.tabCManClients.Size = new System.Drawing.Size(1600, 919);
            this.tabCManClients.TabIndex = 85;
            // 
            // tabInputOrderInfo
            // 
            this.tabInputOrderInfo.Controls.Add(this.gbOrderDetails);
            this.tabInputOrderInfo.Location = new System.Drawing.Point(4, 38);
            this.tabInputOrderInfo.Name = "tabInputOrderInfo";
            this.tabInputOrderInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputOrderInfo.Size = new System.Drawing.Size(1592, 877);
            this.tabInputOrderInfo.TabIndex = 1;
            this.tabInputOrderInfo.Text = "Input Order Info";
            this.tabInputOrderInfo.UseVisualStyleBackColor = true;
            // 
            // gbOrderDetails
            // 
            this.gbOrderDetails.BackColor = System.Drawing.Color.Transparent;
            this.gbOrderDetails.Controls.Add(this.cbProNameOrder);
            this.gbOrderDetails.Controls.Add(this.cbCustNameOrder);
            this.gbOrderDetails.Controls.Add(this.lblCustNameOrder);
            this.gbOrderDetails.Controls.Add(this.lblProNameOrder);
            this.gbOrderDetails.Controls.Add(this.btnAddOrder);
            this.gbOrderDetails.Controls.Add(this.lblDescOrder);
            this.gbOrderDetails.Controls.Add(this.lblQuanOrder);
            this.gbOrderDetails.Controls.Add(this.txtDescOrder);
            this.gbOrderDetails.Controls.Add(this.txtQuanOrder);
            this.gbOrderDetails.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOrderDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbOrderDetails.Location = new System.Drawing.Point(581, 128);
            this.gbOrderDetails.Name = "gbOrderDetails";
            this.gbOrderDetails.Size = new System.Drawing.Size(400, 309);
            this.gbOrderDetails.TabIndex = 85;
            this.gbOrderDetails.TabStop = false;
            this.gbOrderDetails.Text = "Order Details";
            // 
            // cbProNameOrder
            // 
            this.cbProNameOrder.BackColor = System.Drawing.Color.White;
            this.cbProNameOrder.DropDownWidth = 350;
            this.cbProNameOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbProNameOrder.FormattingEnabled = true;
            this.cbProNameOrder.Location = new System.Drawing.Point(197, 89);
            this.cbProNameOrder.Name = "cbProNameOrder";
            this.cbProNameOrder.Size = new System.Drawing.Size(179, 37);
            this.cbProNameOrder.TabIndex = 84;
            this.cbProNameOrder.DropDown += new System.EventHandler(this.cbProNameOrder_DropDown);
            // 
            // cbCustNameOrder
            // 
            this.cbCustNameOrder.BackColor = System.Drawing.Color.White;
            this.cbCustNameOrder.DropDownWidth = 300;
            this.cbCustNameOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbCustNameOrder.FormattingEnabled = true;
            this.cbCustNameOrder.Location = new System.Drawing.Point(197, 46);
            this.cbCustNameOrder.Name = "cbCustNameOrder";
            this.cbCustNameOrder.Size = new System.Drawing.Size(179, 37);
            this.cbCustNameOrder.TabIndex = 83;
            this.cbCustNameOrder.DropDown += new System.EventHandler(this.cbCustNameOrder_DropDown);
            // 
            // lblCustNameOrder
            // 
            this.lblCustNameOrder.AutoSize = true;
            this.lblCustNameOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustNameOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblCustNameOrder.Location = new System.Drawing.Point(14, 54);
            this.lblCustNameOrder.Name = "lblCustNameOrder";
            this.lblCustNameOrder.Size = new System.Drawing.Size(178, 29);
            this.lblCustNameOrder.TabIndex = 52;
            this.lblCustNameOrder.Text = "Customer Name:";
            // 
            // lblProNameOrder
            // 
            this.lblProNameOrder.AutoSize = true;
            this.lblProNameOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProNameOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProNameOrder.Location = new System.Drawing.Point(14, 95);
            this.lblProNameOrder.Name = "lblProNameOrder";
            this.lblProNameOrder.Size = new System.Drawing.Size(160, 29);
            this.lblProNameOrder.TabIndex = 50;
            this.lblProNameOrder.Text = "Product Name:";
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnAddOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAddOrder.Location = new System.Drawing.Point(90, 238);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(225, 48);
            this.btnAddOrder.TabIndex = 18;
            this.btnAddOrder.Text = "ADD ORDER";
            this.btnAddOrder.UseVisualStyleBackColor = false;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // lblDescOrder
            // 
            this.lblDescOrder.AutoSize = true;
            this.lblDescOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblDescOrder.Location = new System.Drawing.Point(13, 178);
            this.lblDescOrder.Name = "lblDescOrder";
            this.lblDescOrder.Size = new System.Drawing.Size(131, 29);
            this.lblDescOrder.TabIndex = 41;
            this.lblDescOrder.Text = "Description:";
            // 
            // lblQuanOrder
            // 
            this.lblQuanOrder.AutoSize = true;
            this.lblQuanOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuanOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblQuanOrder.Location = new System.Drawing.Point(13, 135);
            this.lblQuanOrder.Name = "lblQuanOrder";
            this.lblQuanOrder.Size = new System.Drawing.Size(105, 29);
            this.lblQuanOrder.TabIndex = 40;
            this.lblQuanOrder.Text = "Quantity:";
            // 
            // txtDescOrder
            // 
            this.txtDescOrder.BackColor = System.Drawing.Color.White;
            this.txtDescOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtDescOrder.Location = new System.Drawing.Point(197, 175);
            this.txtDescOrder.MinimumSize = new System.Drawing.Size(179, 50);
            this.txtDescOrder.Multiline = true;
            this.txtDescOrder.Name = "txtDescOrder";
            this.txtDescOrder.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescOrder.Size = new System.Drawing.Size(179, 50);
            this.txtDescOrder.TabIndex = 46;
            // 
            // txtQuanOrder
            // 
            this.txtQuanOrder.BackColor = System.Drawing.Color.White;
            this.txtQuanOrder.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuanOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtQuanOrder.Location = new System.Drawing.Point(196, 132);
            this.txtQuanOrder.Name = "txtQuanOrder";
            this.txtQuanOrder.Size = new System.Drawing.Size(179, 37);
            this.txtQuanOrder.TabIndex = 45;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.BackColor = System.Drawing.Color.Transparent;
            this.lblClient.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.ForeColor = System.Drawing.Color.Black;
            this.lblClient.Location = new System.Drawing.Point(97, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(73, 36);
            this.lblClient.TabIndex = 87;
            this.lblClient.Text = "INFO";
            // 
            // lblManage
            // 
            this.lblManage.AutoSize = true;
            this.lblManage.BackColor = System.Drawing.Color.Transparent;
            this.lblManage.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManage.ForeColor = System.Drawing.Color.Black;
            this.lblManage.Location = new System.Drawing.Point(3, 0);
            this.lblManage.Name = "lblManage";
            this.lblManage.Size = new System.Drawing.Size(99, 36);
            this.lblManage.TabIndex = 86;
            this.lblManage.Text = "ORDER";
            // 
            // OrderStuffUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblManage);
            this.Controls.Add(this.tabCManClients);
            this.Name = "OrderStuffUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.tabCManClients.ResumeLayout(false);
            this.tabInputOrderInfo.ResumeLayout(false);
            this.gbOrderDetails.ResumeLayout(false);
            this.gbOrderDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCManClients;
        private System.Windows.Forms.TabPage tabInputOrderInfo;
        private System.Windows.Forms.GroupBox gbOrderDetails;
        private System.Windows.Forms.ComboBox cbProNameOrder;
        private System.Windows.Forms.ComboBox cbCustNameOrder;
        private System.Windows.Forms.Label lblCustNameOrder;
        private System.Windows.Forms.Label lblProNameOrder;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Label lblDescOrder;
        private System.Windows.Forms.Label lblQuanOrder;
        private System.Windows.Forms.TextBox txtDescOrder;
        private System.Windows.Forms.TextBox txtQuanOrder;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Label lblManage;

    }
}
