namespace DesktopApp
{
    partial class ManageProductsUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabCManProducts = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.gbAddProduct = new System.Windows.Forms.GroupBox();
            this.txtProManAdd = new System.Windows.Forms.TextBox();
            this.btnAddProductAdmin = new System.Windows.Forms.Button();
            this.lblProManAdd = new System.Windows.Forms.Label();
            this.lblProDescAdd = new System.Windows.Forms.Label();
            this.txtProDescAdd = new System.Windows.Forms.TextBox();
            this.lblProQuanAdd = new System.Windows.Forms.Label();
            this.lblProNameAdd = new System.Windows.Forms.Label();
            this.txtProQuanAdd = new System.Windows.Forms.TextBox();
            this.txtProNameAdd = new System.Windows.Forms.TextBox();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.gbEditProduct = new System.Windows.Forms.GroupBox();
            this.cbEditProName = new System.Windows.Forms.ComboBox();
            this.btnResetProduct = new System.Windows.Forms.Button();
            this.lblProManEdit = new System.Windows.Forms.Label();
            this.txtProManEdit = new System.Windows.Forms.TextBox();
            this.txtProQuanEdit = new System.Windows.Forms.TextBox();
            this.btnEditProductAdmin = new System.Windows.Forms.Button();
            this.txtProDescEdit = new System.Windows.Forms.TextBox();
            this.lblProNameEdit = new System.Windows.Forms.Label();
            this.lblProDescEdit = new System.Windows.Forms.Label();
            this.lblProQuanEdit = new System.Windows.Forms.Label();
            this.tabHide = new System.Windows.Forms.TabPage();
            this.gbHideProduct = new System.Windows.Forms.GroupBox();
            this.cbHideProName = new System.Windows.Forms.ComboBox();
            this.btnUnhideProAdmin = new System.Windows.Forms.Button();
            this.lblProNameRemove = new System.Windows.Forms.Label();
            this.btnHideProAdmin = new System.Windows.Forms.Button();
            this.ViewProductInTbl = new System.Windows.Forms.TabPage();
            this.ViewStuffTable = new System.Windows.Forms.DataGridView();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblManage = new System.Windows.Forms.Label();
            this.tabCManProducts.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.gbAddProduct.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.gbEditProduct.SuspendLayout();
            this.tabHide.SuspendLayout();
            this.gbHideProduct.SuspendLayout();
            this.ViewProductInTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCManProducts
            // 
            this.tabCManProducts.Controls.Add(this.tabAdd);
            this.tabCManProducts.Controls.Add(this.tabEdit);
            this.tabCManProducts.Controls.Add(this.tabHide);
            this.tabCManProducts.Controls.Add(this.ViewProductInTbl);
            this.tabCManProducts.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCManProducts.Location = new System.Drawing.Point(9, 39);
            this.tabCManProducts.Name = "tabCManProducts";
            this.tabCManProducts.SelectedIndex = 0;
            this.tabCManProducts.Size = new System.Drawing.Size(1600, 919);
            this.tabCManProducts.TabIndex = 71;
            this.tabCManProducts.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCManProducts_Selected);
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.gbAddProduct);
            this.tabAdd.Location = new System.Drawing.Point(4, 38);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(1592, 877);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Text = "Add Product";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // gbAddProduct
            // 
            this.gbAddProduct.BackColor = System.Drawing.Color.Transparent;
            this.gbAddProduct.Controls.Add(this.txtProManAdd);
            this.gbAddProduct.Controls.Add(this.btnAddProductAdmin);
            this.gbAddProduct.Controls.Add(this.lblProManAdd);
            this.gbAddProduct.Controls.Add(this.lblProDescAdd);
            this.gbAddProduct.Controls.Add(this.txtProDescAdd);
            this.gbAddProduct.Controls.Add(this.lblProQuanAdd);
            this.gbAddProduct.Controls.Add(this.lblProNameAdd);
            this.gbAddProduct.Controls.Add(this.txtProQuanAdd);
            this.gbAddProduct.Controls.Add(this.txtProNameAdd);
            this.gbAddProduct.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbAddProduct.Location = new System.Drawing.Point(581, 128);
            this.gbAddProduct.Name = "gbAddProduct";
            this.gbAddProduct.Size = new System.Drawing.Size(400, 396);
            this.gbAddProduct.TabIndex = 63;
            this.gbAddProduct.TabStop = false;
            this.gbAddProduct.Text = "ADD Product";
            // 
            // txtProManAdd
            // 
            this.txtProManAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProManAdd.BackColor = System.Drawing.Color.White;
            this.txtProManAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProManAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtProManAdd.Location = new System.Drawing.Point(198, 254);
            this.txtProManAdd.Multiline = true;
            this.txtProManAdd.Name = "txtProManAdd";
            this.txtProManAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProManAdd.Size = new System.Drawing.Size(179, 50);
            this.txtProManAdd.TabIndex = 49;
            // 
            // btnAddProductAdmin
            // 
            this.btnAddProductAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProductAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnAddProductAdmin.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProductAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAddProductAdmin.Location = new System.Drawing.Point(84, 316);
            this.btnAddProductAdmin.Name = "btnAddProductAdmin";
            this.btnAddProductAdmin.Size = new System.Drawing.Size(225, 48);
            this.btnAddProductAdmin.TabIndex = 18;
            this.btnAddProductAdmin.Text = "ADD PRODUCT";
            this.btnAddProductAdmin.UseVisualStyleBackColor = false;
            this.btnAddProductAdmin.Click += new System.EventHandler(this.btnAddProductAdmin_Click);
            // 
            // lblProManAdd
            // 
            this.lblProManAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProManAdd.AutoSize = true;
            this.lblProManAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProManAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProManAdd.Location = new System.Drawing.Point(17, 262);
            this.lblProManAdd.Name = "lblProManAdd";
            this.lblProManAdd.Size = new System.Drawing.Size(156, 29);
            this.lblProManAdd.TabIndex = 47;
            this.lblProManAdd.Text = "Manufacturer:";
            // 
            // lblProDescAdd
            // 
            this.lblProDescAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProDescAdd.AutoSize = true;
            this.lblProDescAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProDescAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProDescAdd.Location = new System.Drawing.Point(17, 199);
            this.lblProDescAdd.Name = "lblProDescAdd";
            this.lblProDescAdd.Size = new System.Drawing.Size(131, 29);
            this.lblProDescAdd.TabIndex = 42;
            this.lblProDescAdd.Text = "Description:";
            // 
            // txtProDescAdd
            // 
            this.txtProDescAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProDescAdd.BackColor = System.Drawing.Color.White;
            this.txtProDescAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProDescAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtProDescAdd.Location = new System.Drawing.Point(198, 191);
            this.txtProDescAdd.Multiline = true;
            this.txtProDescAdd.Name = "txtProDescAdd";
            this.txtProDescAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProDescAdd.Size = new System.Drawing.Size(179, 50);
            this.txtProDescAdd.TabIndex = 47;
            // 
            // lblProQuanAdd
            // 
            this.lblProQuanAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProQuanAdd.AutoSize = true;
            this.lblProQuanAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProQuanAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProQuanAdd.Location = new System.Drawing.Point(17, 131);
            this.lblProQuanAdd.Name = "lblProQuanAdd";
            this.lblProQuanAdd.Size = new System.Drawing.Size(105, 29);
            this.lblProQuanAdd.TabIndex = 41;
            this.lblProQuanAdd.Text = "Quantity:";
            // 
            // lblProNameAdd
            // 
            this.lblProNameAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProNameAdd.AutoSize = true;
            this.lblProNameAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProNameAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProNameAdd.Location = new System.Drawing.Point(17, 61);
            this.lblProNameAdd.Name = "lblProNameAdd";
            this.lblProNameAdd.Size = new System.Drawing.Size(78, 29);
            this.lblProNameAdd.TabIndex = 40;
            this.lblProNameAdd.Text = "Name:";
            // 
            // txtProQuanAdd
            // 
            this.txtProQuanAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProQuanAdd.BackColor = System.Drawing.Color.White;
            this.txtProQuanAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProQuanAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtProQuanAdd.Location = new System.Drawing.Point(198, 123);
            this.txtProQuanAdd.Name = "txtProQuanAdd";
            this.txtProQuanAdd.Size = new System.Drawing.Size(179, 37);
            this.txtProQuanAdd.TabIndex = 46;
            // 
            // txtProNameAdd
            // 
            this.txtProNameAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProNameAdd.BackColor = System.Drawing.Color.White;
            this.txtProNameAdd.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProNameAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtProNameAdd.Location = new System.Drawing.Point(198, 57);
            this.txtProNameAdd.Name = "txtProNameAdd";
            this.txtProNameAdd.Size = new System.Drawing.Size(179, 37);
            this.txtProNameAdd.TabIndex = 45;
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.gbEditProduct);
            this.tabEdit.Location = new System.Drawing.Point(4, 38);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(1592, 877);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "Edit Product";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // gbEditProduct
            // 
            this.gbEditProduct.BackColor = System.Drawing.Color.Transparent;
            this.gbEditProduct.Controls.Add(this.cbEditProName);
            this.gbEditProduct.Controls.Add(this.btnResetProduct);
            this.gbEditProduct.Controls.Add(this.lblProManEdit);
            this.gbEditProduct.Controls.Add(this.txtProManEdit);
            this.gbEditProduct.Controls.Add(this.txtProQuanEdit);
            this.gbEditProduct.Controls.Add(this.btnEditProductAdmin);
            this.gbEditProduct.Controls.Add(this.txtProDescEdit);
            this.gbEditProduct.Controls.Add(this.lblProNameEdit);
            this.gbEditProduct.Controls.Add(this.lblProDescEdit);
            this.gbEditProduct.Controls.Add(this.lblProQuanEdit);
            this.gbEditProduct.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEditProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbEditProduct.Location = new System.Drawing.Point(581, 128);
            this.gbEditProduct.Name = "gbEditProduct";
            this.gbEditProduct.Size = new System.Drawing.Size(400, 396);
            this.gbEditProduct.TabIndex = 65;
            this.gbEditProduct.TabStop = false;
            this.gbEditProduct.Text = "EDIT Product";
            // 
            // cbEditProName
            // 
            this.cbEditProName.BackColor = System.Drawing.Color.White;
            this.cbEditProName.DropDownWidth = 300;
            this.cbEditProName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbEditProName.FormattingEnabled = true;
            this.cbEditProName.Location = new System.Drawing.Point(196, 92);
            this.cbEditProName.Name = "cbEditProName";
            this.cbEditProName.Size = new System.Drawing.Size(179, 41);
            this.cbEditProName.TabIndex = 86;
            this.cbEditProName.DropDown += new System.EventHandler(this.EditProNameCB_DropDown);
            this.cbEditProName.SelectedIndexChanged += new System.EventHandler(this.EditProNameCB_SelectedIndexChanged);
            // 
            // btnResetProduct
            // 
            this.btnResetProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnResetProduct.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnResetProduct.Location = new System.Drawing.Point(24, 46);
            this.btnResetProduct.Name = "btnResetProduct";
            this.btnResetProduct.Size = new System.Drawing.Size(79, 25);
            this.btnResetProduct.TabIndex = 71;
            this.btnResetProduct.Text = "RESET";
            this.btnResetProduct.UseVisualStyleBackColor = false;
            this.btnResetProduct.Click += new System.EventHandler(this.btnResetProduct_Click);
            // 
            // lblProManEdit
            // 
            this.lblProManEdit.AutoSize = true;
            this.lblProManEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProManEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProManEdit.Location = new System.Drawing.Point(25, 262);
            this.lblProManEdit.Name = "lblProManEdit";
            this.lblProManEdit.Size = new System.Drawing.Size(156, 29);
            this.lblProManEdit.TabIndex = 48;
            this.lblProManEdit.Text = "Manufacturer:";
            // 
            // txtProManEdit
            // 
            this.txtProManEdit.BackColor = System.Drawing.Color.White;
            this.txtProManEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProManEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtProManEdit.Location = new System.Drawing.Point(198, 254);
            this.txtProManEdit.Multiline = true;
            this.txtProManEdit.Name = "txtProManEdit";
            this.txtProManEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProManEdit.Size = new System.Drawing.Size(179, 50);
            this.txtProManEdit.TabIndex = 48;
            // 
            // txtProQuanEdit
            // 
            this.txtProQuanEdit.BackColor = System.Drawing.Color.White;
            this.txtProQuanEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProQuanEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtProQuanEdit.Location = new System.Drawing.Point(198, 147);
            this.txtProQuanEdit.Name = "txtProQuanEdit";
            this.txtProQuanEdit.Size = new System.Drawing.Size(179, 37);
            this.txtProQuanEdit.TabIndex = 46;
            // 
            // btnEditProductAdmin
            // 
            this.btnEditProductAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnEditProductAdmin.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProductAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnEditProductAdmin.Location = new System.Drawing.Point(99, 324);
            this.btnEditProductAdmin.Name = "btnEditProductAdmin";
            this.btnEditProductAdmin.Size = new System.Drawing.Size(225, 48);
            this.btnEditProductAdmin.TabIndex = 18;
            this.btnEditProductAdmin.Text = "EDIT PRODUCT";
            this.btnEditProductAdmin.UseVisualStyleBackColor = false;
            this.btnEditProductAdmin.Click += new System.EventHandler(this.btnEditProductAdmin_Click);
            // 
            // txtProDescEdit
            // 
            this.txtProDescEdit.BackColor = System.Drawing.Color.White;
            this.txtProDescEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProDescEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtProDescEdit.Location = new System.Drawing.Point(198, 193);
            this.txtProDescEdit.Multiline = true;
            this.txtProDescEdit.Name = "txtProDescEdit";
            this.txtProDescEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProDescEdit.Size = new System.Drawing.Size(179, 50);
            this.txtProDescEdit.TabIndex = 45;
            // 
            // lblProNameEdit
            // 
            this.lblProNameEdit.AutoSize = true;
            this.lblProNameEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProNameEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProNameEdit.Location = new System.Drawing.Point(25, 95);
            this.lblProNameEdit.Name = "lblProNameEdit";
            this.lblProNameEdit.Size = new System.Drawing.Size(160, 29);
            this.lblProNameEdit.TabIndex = 39;
            this.lblProNameEdit.Text = "Product Name:";
            // 
            // lblProDescEdit
            // 
            this.lblProDescEdit.AutoSize = true;
            this.lblProDescEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProDescEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProDescEdit.Location = new System.Drawing.Point(25, 206);
            this.lblProDescEdit.Name = "lblProDescEdit";
            this.lblProDescEdit.Size = new System.Drawing.Size(131, 29);
            this.lblProDescEdit.TabIndex = 40;
            this.lblProDescEdit.Text = "Description:";
            // 
            // lblProQuanEdit
            // 
            this.lblProQuanEdit.AutoSize = true;
            this.lblProQuanEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProQuanEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProQuanEdit.Location = new System.Drawing.Point(25, 150);
            this.lblProQuanEdit.Name = "lblProQuanEdit";
            this.lblProQuanEdit.Size = new System.Drawing.Size(105, 29);
            this.lblProQuanEdit.TabIndex = 41;
            this.lblProQuanEdit.Text = "Quantity:";
            // 
            // tabHide
            // 
            this.tabHide.Controls.Add(this.gbHideProduct);
            this.tabHide.Location = new System.Drawing.Point(4, 38);
            this.tabHide.Name = "tabHide";
            this.tabHide.Size = new System.Drawing.Size(1592, 877);
            this.tabHide.TabIndex = 2;
            this.tabHide.Text = "Hide/Unhide Product";
            this.tabHide.UseVisualStyleBackColor = true;
            // 
            // gbHideProduct
            // 
            this.gbHideProduct.BackColor = System.Drawing.Color.Transparent;
            this.gbHideProduct.Controls.Add(this.cbHideProName);
            this.gbHideProduct.Controls.Add(this.btnUnhideProAdmin);
            this.gbHideProduct.Controls.Add(this.lblProNameRemove);
            this.gbHideProduct.Controls.Add(this.btnHideProAdmin);
            this.gbHideProduct.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHideProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbHideProduct.Location = new System.Drawing.Point(581, 128);
            this.gbHideProduct.Name = "gbHideProduct";
            this.gbHideProduct.Size = new System.Drawing.Size(400, 270);
            this.gbHideProduct.TabIndex = 66;
            this.gbHideProduct.TabStop = false;
            this.gbHideProduct.Text = "HIDE/UNHIDE Product";
            // 
            // cbHideProName
            // 
            this.cbHideProName.BackColor = System.Drawing.Color.White;
            this.cbHideProName.DropDownWidth = 300;
            this.cbHideProName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbHideProName.FormattingEnabled = true;
            this.cbHideProName.Location = new System.Drawing.Point(188, 57);
            this.cbHideProName.Name = "cbHideProName";
            this.cbHideProName.Size = new System.Drawing.Size(179, 41);
            this.cbHideProName.TabIndex = 86;
            this.cbHideProName.DropDown += new System.EventHandler(this.HideProNameCB_DropDown);
            // 
            // btnUnhideProAdmin
            // 
            this.btnUnhideProAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnUnhideProAdmin.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnhideProAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnUnhideProAdmin.Location = new System.Drawing.Point(88, 194);
            this.btnUnhideProAdmin.Name = "btnUnhideProAdmin";
            this.btnUnhideProAdmin.Size = new System.Drawing.Size(225, 48);
            this.btnUnhideProAdmin.TabIndex = 34;
            this.btnUnhideProAdmin.Text = "UNHIDE PRODUCT";
            this.btnUnhideProAdmin.UseVisualStyleBackColor = false;
            this.btnUnhideProAdmin.Click += new System.EventHandler(this.btnUnhideProAdmin_Click);
            // 
            // lblProNameRemove
            // 
            this.lblProNameRemove.AutoSize = true;
            this.lblProNameRemove.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProNameRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProNameRemove.Location = new System.Drawing.Point(30, 61);
            this.lblProNameRemove.Name = "lblProNameRemove";
            this.lblProNameRemove.Size = new System.Drawing.Size(160, 29);
            this.lblProNameRemove.TabIndex = 28;
            this.lblProNameRemove.Text = "Product Name:";
            // 
            // btnHideProAdmin
            // 
            this.btnHideProAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnHideProAdmin.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideProAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnHideProAdmin.Location = new System.Drawing.Point(88, 131);
            this.btnHideProAdmin.Name = "btnHideProAdmin";
            this.btnHideProAdmin.Size = new System.Drawing.Size(225, 48);
            this.btnHideProAdmin.TabIndex = 18;
            this.btnHideProAdmin.Text = "HIDE PRODUCT";
            this.btnHideProAdmin.UseVisualStyleBackColor = false;
            this.btnHideProAdmin.Click += new System.EventHandler(this.btnHideProAdmin_Click);
            // 
            // ViewProductInTbl
            // 
            this.ViewProductInTbl.Controls.Add(this.ViewStuffTable);
            this.ViewProductInTbl.Location = new System.Drawing.Point(4, 38);
            this.ViewProductInTbl.Name = "ViewProductInTbl";
            this.ViewProductInTbl.Size = new System.Drawing.Size(1592, 877);
            this.ViewProductInTbl.TabIndex = 3;
            this.ViewProductInTbl.Text = "View Product Details";
            this.ViewProductInTbl.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ViewStuffTable.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ViewStuffTable.Size = new System.Drawing.Size(1530, 755);
            this.ViewStuffTable.TabIndex = 60;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblProducts.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.ForeColor = System.Drawing.Color.Black;
            this.lblProducts.Location = new System.Drawing.Point(124, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(144, 36);
            this.lblProducts.TabIndex = 75;
            this.lblProducts.Text = "PRODUCTS";
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
            this.lblManage.TabIndex = 74;
            this.lblManage.Text = "MANAGE";
            // 
            // ManageProductsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblManage);
            this.Controls.Add(this.tabCManProducts);
            this.Name = "ManageProductsUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.Load += new System.EventHandler(this.ManageProductsUC_Load);
            this.tabCManProducts.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.gbAddProduct.ResumeLayout(false);
            this.gbAddProduct.PerformLayout();
            this.tabEdit.ResumeLayout(false);
            this.gbEditProduct.ResumeLayout(false);
            this.gbEditProduct.PerformLayout();
            this.tabHide.ResumeLayout(false);
            this.gbHideProduct.ResumeLayout(false);
            this.gbHideProduct.PerformLayout();
            this.ViewProductInTbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCManProducts;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TabPage tabHide;
        private System.Windows.Forms.TabPage ViewProductInTbl;
        private System.Windows.Forms.DataGridView ViewStuffTable;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblManage;
        private System.Windows.Forms.GroupBox gbAddProduct;
        private System.Windows.Forms.TextBox txtProManAdd;
        private System.Windows.Forms.Button btnAddProductAdmin;
        private System.Windows.Forms.Label lblProManAdd;
        private System.Windows.Forms.Label lblProDescAdd;
        private System.Windows.Forms.TextBox txtProDescAdd;
        private System.Windows.Forms.Label lblProQuanAdd;
        private System.Windows.Forms.Label lblProNameAdd;
        private System.Windows.Forms.TextBox txtProQuanAdd;
        private System.Windows.Forms.TextBox txtProNameAdd;
        private System.Windows.Forms.GroupBox gbEditProduct;
        private System.Windows.Forms.ComboBox cbEditProName;
        private System.Windows.Forms.Button btnResetProduct;
        private System.Windows.Forms.Label lblProManEdit;
        private System.Windows.Forms.TextBox txtProManEdit;
        private System.Windows.Forms.TextBox txtProQuanEdit;
        private System.Windows.Forms.Button btnEditProductAdmin;
        private System.Windows.Forms.TextBox txtProDescEdit;
        private System.Windows.Forms.Label lblProNameEdit;
        private System.Windows.Forms.Label lblProDescEdit;
        private System.Windows.Forms.Label lblProQuanEdit;
        private System.Windows.Forms.GroupBox gbHideProduct;
        private System.Windows.Forms.ComboBox cbHideProName;
        private System.Windows.Forms.Button btnUnhideProAdmin;
        private System.Windows.Forms.Label lblProNameRemove;
        private System.Windows.Forms.Button btnHideProAdmin;
    }
}
