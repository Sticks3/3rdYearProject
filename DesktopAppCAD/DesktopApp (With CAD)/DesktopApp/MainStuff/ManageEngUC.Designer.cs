namespace DesktopApp
{
    partial class ManageEngUC
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
            this.tabCManEng = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.gbAddEngineer = new System.Windows.Forms.GroupBox();
            this.txtAddAssocProEng = new System.Windows.Forms.TextBox();
            this.lblAddAssocProEng = new System.Windows.Forms.Label();
            this.lblAddConfirmPassEng = new System.Windows.Forms.Label();
            this.txtAddConfirmPassEng = new System.Windows.Forms.TextBox();
            this.lblEmailAddEng = new System.Windows.Forms.Label();
            this.txtAddEmailEng = new System.Windows.Forms.TextBox();
            this.lblLastNameAddEng = new System.Windows.Forms.Label();
            this.txtAddLastNameEng = new System.Windows.Forms.TextBox();
            this.btnAddEng = new System.Windows.Forms.Button();
            this.lblRealNameEng = new System.Windows.Forms.Label();
            this.txtAddFirstNameEng = new System.Windows.Forms.TextBox();
            this.lblPasswordEng = new System.Windows.Forms.Label();
            this.lblUsernameEng = new System.Windows.Forms.Label();
            this.txtAddPasswordEng = new System.Windows.Forms.TextBox();
            this.txtAddUsernameEng = new System.Windows.Forms.TextBox();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.gbEditEng = new System.Windows.Forms.GroupBox();
            this.cbEditEngUsername = new System.Windows.Forms.ComboBox();
            this.txtEditLastNameEng = new System.Windows.Forms.TextBox();
            this.lblEditLastNameEng = new System.Windows.Forms.Label();
            this.txtEditEmailEng = new System.Windows.Forms.TextBox();
            this.lblEditEmailEng = new System.Windows.Forms.Label();
            this.txtEditAssocProEng = new System.Windows.Forms.TextBox();
            this.lblEditAssocProEng = new System.Windows.Forms.Label();
            this.btnResetEngineer = new System.Windows.Forms.Button();
            this.txtEditFirstNameEng = new System.Windows.Forms.TextBox();
            this.btnEditEng = new System.Windows.Forms.Button();
            this.lblUsernameEdit = new System.Windows.Forms.Label();
            this.lblEditFirstNameEng = new System.Windows.Forms.Label();
            this.tabHide = new System.Windows.Forms.TabPage();
            this.gbHideEngineer = new System.Windows.Forms.GroupBox();
            this.cbEngHideName = new System.Windows.Forms.ComboBox();
            this.btnUnhideEngineer = new System.Windows.Forms.Button();
            this.lblNameEngRem = new System.Windows.Forms.Label();
            this.btnHideEngineer = new System.Windows.Forms.Button();
            this.ViewEngInTbl = new System.Windows.Forms.TabPage();
            this.ViewStuffTable = new System.Windows.Forms.DataGridView();
            this.lblManage = new System.Windows.Forms.Label();
            this.lblEngineers = new System.Windows.Forms.Label();
            this.tabCManEng.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.gbAddEngineer.SuspendLayout();
            this.tabEdit.SuspendLayout();
            this.gbEditEng.SuspendLayout();
            this.tabHide.SuspendLayout();
            this.gbHideEngineer.SuspendLayout();
            this.ViewEngInTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCManEng
            // 
            this.tabCManEng.Controls.Add(this.tabAdd);
            this.tabCManEng.Controls.Add(this.tabEdit);
            this.tabCManEng.Controls.Add(this.tabHide);
            this.tabCManEng.Controls.Add(this.ViewEngInTbl);
            this.tabCManEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCManEng.Location = new System.Drawing.Point(9, 39);
            this.tabCManEng.Name = "tabCManEng";
            this.tabCManEng.SelectedIndex = 0;
            this.tabCManEng.Size = new System.Drawing.Size(1600, 919);
            this.tabCManEng.TabIndex = 69;
            this.tabCManEng.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCManEng_Selected);
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.gbAddEngineer);
            this.tabAdd.Location = new System.Drawing.Point(4, 38);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(1592, 877);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Text = "Add Engineer";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // gbAddEngineer
            // 
            this.gbAddEngineer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbAddEngineer.BackColor = System.Drawing.Color.Transparent;
            this.gbAddEngineer.Controls.Add(this.txtAddAssocProEng);
            this.gbAddEngineer.Controls.Add(this.lblAddAssocProEng);
            this.gbAddEngineer.Controls.Add(this.lblAddConfirmPassEng);
            this.gbAddEngineer.Controls.Add(this.txtAddConfirmPassEng);
            this.gbAddEngineer.Controls.Add(this.lblEmailAddEng);
            this.gbAddEngineer.Controls.Add(this.txtAddEmailEng);
            this.gbAddEngineer.Controls.Add(this.lblLastNameAddEng);
            this.gbAddEngineer.Controls.Add(this.txtAddLastNameEng);
            this.gbAddEngineer.Controls.Add(this.btnAddEng);
            this.gbAddEngineer.Controls.Add(this.lblRealNameEng);
            this.gbAddEngineer.Controls.Add(this.txtAddFirstNameEng);
            this.gbAddEngineer.Controls.Add(this.lblPasswordEng);
            this.gbAddEngineer.Controls.Add(this.lblUsernameEng);
            this.gbAddEngineer.Controls.Add(this.txtAddPasswordEng);
            this.gbAddEngineer.Controls.Add(this.txtAddUsernameEng);
            this.gbAddEngineer.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddEngineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbAddEngineer.Location = new System.Drawing.Point(581, 128);
            this.gbAddEngineer.Name = "gbAddEngineer";
            this.gbAddEngineer.Size = new System.Drawing.Size(400, 503);
            this.gbAddEngineer.TabIndex = 67;
            this.gbAddEngineer.TabStop = false;
            this.gbAddEngineer.Text = "ADD Engineer";
            // 
            // txtAddAssocProEng
            // 
            this.txtAddAssocProEng.BackColor = System.Drawing.Color.White;
            this.txtAddAssocProEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddAssocProEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAddAssocProEng.Location = new System.Drawing.Point(198, 369);
            this.txtAddAssocProEng.Name = "txtAddAssocProEng";
            this.txtAddAssocProEng.Size = new System.Drawing.Size(179, 37);
            this.txtAddAssocProEng.TabIndex = 72;
            // 
            // lblAddAssocProEng
            // 
            this.lblAddAssocProEng.AutoSize = true;
            this.lblAddAssocProEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddAssocProEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblAddAssocProEng.Location = new System.Drawing.Point(17, 358);
            this.lblAddAssocProEng.Name = "lblAddAssocProEng";
            this.lblAddAssocProEng.Size = new System.Drawing.Size(124, 58);
            this.lblAddAssocProEng.TabIndex = 73;
            this.lblAddAssocProEng.Text = "Associated \r\nProduct:";
            // 
            // lblAddConfirmPassEng
            // 
            this.lblAddConfirmPassEng.AutoSize = true;
            this.lblAddConfirmPassEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddConfirmPassEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblAddConfirmPassEng.Location = new System.Drawing.Point(17, 154);
            this.lblAddConfirmPassEng.Name = "lblAddConfirmPassEng";
            this.lblAddConfirmPassEng.Size = new System.Drawing.Size(111, 58);
            this.lblAddConfirmPassEng.TabIndex = 71;
            this.lblAddConfirmPassEng.Text = "Confirm \r\nPassword:";
            // 
            // txtAddConfirmPassEng
            // 
            this.txtAddConfirmPassEng.BackColor = System.Drawing.Color.White;
            this.txtAddConfirmPassEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddConfirmPassEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAddConfirmPassEng.Location = new System.Drawing.Point(198, 164);
            this.txtAddConfirmPassEng.Name = "txtAddConfirmPassEng";
            this.txtAddConfirmPassEng.Size = new System.Drawing.Size(179, 37);
            this.txtAddConfirmPassEng.TabIndex = 70;
            this.txtAddConfirmPassEng.UseSystemPasswordChar = true;
            // 
            // lblEmailAddEng
            // 
            this.lblEmailAddEng.AutoSize = true;
            this.lblEmailAddEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailAddEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblEmailAddEng.Location = new System.Drawing.Point(17, 322);
            this.lblEmailAddEng.Name = "lblEmailAddEng";
            this.lblEmailAddEng.Size = new System.Drawing.Size(74, 29);
            this.lblEmailAddEng.TabIndex = 50;
            this.lblEmailAddEng.Text = "Email:";
            // 
            // txtAddEmailEng
            // 
            this.txtAddEmailEng.BackColor = System.Drawing.Color.White;
            this.txtAddEmailEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddEmailEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAddEmailEng.Location = new System.Drawing.Point(198, 314);
            this.txtAddEmailEng.Name = "txtAddEmailEng";
            this.txtAddEmailEng.Size = new System.Drawing.Size(179, 37);
            this.txtAddEmailEng.TabIndex = 51;
            // 
            // lblLastNameAddEng
            // 
            this.lblLastNameAddEng.AutoSize = true;
            this.lblLastNameAddEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNameAddEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblLastNameAddEng.Location = new System.Drawing.Point(17, 273);
            this.lblLastNameAddEng.Name = "lblLastNameAddEng";
            this.lblLastNameAddEng.Size = new System.Drawing.Size(122, 29);
            this.lblLastNameAddEng.TabIndex = 48;
            this.lblLastNameAddEng.Text = "Last Name:";
            // 
            // txtAddLastNameEng
            // 
            this.txtAddLastNameEng.BackColor = System.Drawing.Color.White;
            this.txtAddLastNameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddLastNameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAddLastNameEng.Location = new System.Drawing.Point(198, 265);
            this.txtAddLastNameEng.Name = "txtAddLastNameEng";
            this.txtAddLastNameEng.Size = new System.Drawing.Size(179, 37);
            this.txtAddLastNameEng.TabIndex = 49;
            // 
            // btnAddEng
            // 
            this.btnAddEng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnAddEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAddEng.Location = new System.Drawing.Point(84, 436);
            this.btnAddEng.Name = "btnAddEng";
            this.btnAddEng.Size = new System.Drawing.Size(225, 48);
            this.btnAddEng.TabIndex = 18;
            this.btnAddEng.Text = "ADD ENGINEER";
            this.btnAddEng.UseVisualStyleBackColor = false;
            this.btnAddEng.Click += new System.EventHandler(this.btnAddEng_Click);
            // 
            // lblRealNameEng
            // 
            this.lblRealNameEng.AutoSize = true;
            this.lblRealNameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealNameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblRealNameEng.Location = new System.Drawing.Point(17, 224);
            this.lblRealNameEng.Name = "lblRealNameEng";
            this.lblRealNameEng.Size = new System.Drawing.Size(125, 29);
            this.lblRealNameEng.TabIndex = 42;
            this.lblRealNameEng.Text = "First Name:";
            // 
            // txtAddFirstNameEng
            // 
            this.txtAddFirstNameEng.BackColor = System.Drawing.Color.White;
            this.txtAddFirstNameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddFirstNameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAddFirstNameEng.Location = new System.Drawing.Point(198, 216);
            this.txtAddFirstNameEng.Name = "txtAddFirstNameEng";
            this.txtAddFirstNameEng.Size = new System.Drawing.Size(179, 37);
            this.txtAddFirstNameEng.TabIndex = 47;
            // 
            // lblPasswordEng
            // 
            this.lblPasswordEng.AutoSize = true;
            this.lblPasswordEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblPasswordEng.Location = new System.Drawing.Point(17, 117);
            this.lblPasswordEng.Name = "lblPasswordEng";
            this.lblPasswordEng.Size = new System.Drawing.Size(111, 29);
            this.lblPasswordEng.TabIndex = 41;
            this.lblPasswordEng.Text = "Password:";
            // 
            // lblUsernameEng
            // 
            this.lblUsernameEng.AutoSize = true;
            this.lblUsernameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblUsernameEng.Location = new System.Drawing.Point(17, 70);
            this.lblUsernameEng.Name = "lblUsernameEng";
            this.lblUsernameEng.Size = new System.Drawing.Size(119, 29);
            this.lblUsernameEng.TabIndex = 40;
            this.lblUsernameEng.Text = "Username:";
            // 
            // txtAddPasswordEng
            // 
            this.txtAddPasswordEng.BackColor = System.Drawing.Color.White;
            this.txtAddPasswordEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddPasswordEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAddPasswordEng.Location = new System.Drawing.Point(198, 109);
            this.txtAddPasswordEng.Name = "txtAddPasswordEng";
            this.txtAddPasswordEng.Size = new System.Drawing.Size(179, 37);
            this.txtAddPasswordEng.TabIndex = 46;
            this.txtAddPasswordEng.UseSystemPasswordChar = true;
            // 
            // txtAddUsernameEng
            // 
            this.txtAddUsernameEng.BackColor = System.Drawing.Color.White;
            this.txtAddUsernameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddUsernameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAddUsernameEng.Location = new System.Drawing.Point(198, 62);
            this.txtAddUsernameEng.Name = "txtAddUsernameEng";
            this.txtAddUsernameEng.Size = new System.Drawing.Size(179, 37);
            this.txtAddUsernameEng.TabIndex = 45;
            // 
            // tabEdit
            // 
            this.tabEdit.Controls.Add(this.gbEditEng);
            this.tabEdit.Location = new System.Drawing.Point(4, 38);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(1592, 877);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "Edit Engineer";
            this.tabEdit.UseVisualStyleBackColor = true;
            // 
            // gbEditEng
            // 
            this.gbEditEng.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbEditEng.BackColor = System.Drawing.Color.Transparent;
            this.gbEditEng.Controls.Add(this.cbEditEngUsername);
            this.gbEditEng.Controls.Add(this.txtEditLastNameEng);
            this.gbEditEng.Controls.Add(this.lblEditLastNameEng);
            this.gbEditEng.Controls.Add(this.txtEditEmailEng);
            this.gbEditEng.Controls.Add(this.lblEditEmailEng);
            this.gbEditEng.Controls.Add(this.txtEditAssocProEng);
            this.gbEditEng.Controls.Add(this.lblEditAssocProEng);
            this.gbEditEng.Controls.Add(this.btnResetEngineer);
            this.gbEditEng.Controls.Add(this.txtEditFirstNameEng);
            this.gbEditEng.Controls.Add(this.btnEditEng);
            this.gbEditEng.Controls.Add(this.lblUsernameEdit);
            this.gbEditEng.Controls.Add(this.lblEditFirstNameEng);
            this.gbEditEng.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEditEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbEditEng.Location = new System.Drawing.Point(581, 128);
            this.gbEditEng.Name = "gbEditEng";
            this.gbEditEng.Size = new System.Drawing.Size(400, 404);
            this.gbEditEng.TabIndex = 68;
            this.gbEditEng.TabStop = false;
            this.gbEditEng.Text = "EDIT Engineer";
            // 
            // cbEditEngUsername
            // 
            this.cbEditEngUsername.BackColor = System.Drawing.Color.White;
            this.cbEditEngUsername.DropDownWidth = 300;
            this.cbEditEngUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbEditEngUsername.FormattingEnabled = true;
            this.cbEditEngUsername.Location = new System.Drawing.Point(196, 74);
            this.cbEditEngUsername.Name = "cbEditEngUsername";
            this.cbEditEngUsername.Size = new System.Drawing.Size(179, 41);
            this.cbEditEngUsername.TabIndex = 85;
            this.cbEditEngUsername.DropDown += new System.EventHandler(this.EditEngUsernameCB_DropDown);
            this.cbEditEngUsername.SelectedIndexChanged += new System.EventHandler(this.EditEngUsernameCB_SelectedIndexChanged);
            // 
            // txtEditLastNameEng
            // 
            this.txtEditLastNameEng.BackColor = System.Drawing.Color.White;
            this.txtEditLastNameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditLastNameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtEditLastNameEng.Location = new System.Drawing.Point(196, 164);
            this.txtEditLastNameEng.Name = "txtEditLastNameEng";
            this.txtEditLastNameEng.Size = new System.Drawing.Size(179, 37);
            this.txtEditLastNameEng.TabIndex = 77;
            // 
            // lblEditLastNameEng
            // 
            this.lblEditLastNameEng.AutoSize = true;
            this.lblEditLastNameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditLastNameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblEditLastNameEng.Location = new System.Drawing.Point(24, 167);
            this.lblEditLastNameEng.Name = "lblEditLastNameEng";
            this.lblEditLastNameEng.Size = new System.Drawing.Size(122, 29);
            this.lblEditLastNameEng.TabIndex = 76;
            this.lblEditLastNameEng.Text = "Last Name:";
            // 
            // txtEditEmailEng
            // 
            this.txtEditEmailEng.BackColor = System.Drawing.Color.White;
            this.txtEditEmailEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditEmailEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtEditEmailEng.Location = new System.Drawing.Point(196, 207);
            this.txtEditEmailEng.Name = "txtEditEmailEng";
            this.txtEditEmailEng.Size = new System.Drawing.Size(179, 37);
            this.txtEditEmailEng.TabIndex = 74;
            // 
            // lblEditEmailEng
            // 
            this.lblEditEmailEng.AutoSize = true;
            this.lblEditEmailEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditEmailEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblEditEmailEng.Location = new System.Drawing.Point(24, 213);
            this.lblEditEmailEng.Name = "lblEditEmailEng";
            this.lblEditEmailEng.Size = new System.Drawing.Size(74, 29);
            this.lblEditEmailEng.TabIndex = 75;
            this.lblEditEmailEng.Text = "Email:";
            // 
            // txtEditAssocProEng
            // 
            this.txtEditAssocProEng.BackColor = System.Drawing.Color.White;
            this.txtEditAssocProEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditAssocProEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtEditAssocProEng.Location = new System.Drawing.Point(196, 250);
            this.txtEditAssocProEng.Name = "txtEditAssocProEng";
            this.txtEditAssocProEng.Size = new System.Drawing.Size(179, 37);
            this.txtEditAssocProEng.TabIndex = 73;
            // 
            // lblEditAssocProEng
            // 
            this.lblEditAssocProEng.AutoSize = true;
            this.lblEditAssocProEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditAssocProEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblEditAssocProEng.Location = new System.Drawing.Point(23, 249);
            this.lblEditAssocProEng.Name = "lblEditAssocProEng";
            this.lblEditAssocProEng.Size = new System.Drawing.Size(124, 58);
            this.lblEditAssocProEng.TabIndex = 72;
            this.lblEditAssocProEng.Text = "Associated \r\nProduct:";
            // 
            // btnResetEngineer
            // 
            this.btnResetEngineer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnResetEngineer.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetEngineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnResetEngineer.Location = new System.Drawing.Point(30, 39);
            this.btnResetEngineer.Name = "btnResetEngineer";
            this.btnResetEngineer.Size = new System.Drawing.Size(79, 25);
            this.btnResetEngineer.TabIndex = 71;
            this.btnResetEngineer.Text = "RESET";
            this.btnResetEngineer.UseVisualStyleBackColor = false;
            this.btnResetEngineer.Click += new System.EventHandler(this.btnResetEngineer_Click);
            // 
            // txtEditFirstNameEng
            // 
            this.txtEditFirstNameEng.BackColor = System.Drawing.Color.White;
            this.txtEditFirstNameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditFirstNameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtEditFirstNameEng.Location = new System.Drawing.Point(196, 121);
            this.txtEditFirstNameEng.Name = "txtEditFirstNameEng";
            this.txtEditFirstNameEng.Size = new System.Drawing.Size(179, 37);
            this.txtEditFirstNameEng.TabIndex = 46;
            // 
            // btnEditEng
            // 
            this.btnEditEng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnEditEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnEditEng.Location = new System.Drawing.Point(90, 326);
            this.btnEditEng.Name = "btnEditEng";
            this.btnEditEng.Size = new System.Drawing.Size(225, 48);
            this.btnEditEng.TabIndex = 18;
            this.btnEditEng.Text = "EDIT ENGINEER";
            this.btnEditEng.UseVisualStyleBackColor = false;
            this.btnEditEng.Click += new System.EventHandler(this.btnEditEng_Click);
            // 
            // lblUsernameEdit
            // 
            this.lblUsernameEdit.AutoSize = true;
            this.lblUsernameEdit.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblUsernameEdit.Location = new System.Drawing.Point(23, 81);
            this.lblUsernameEdit.Name = "lblUsernameEdit";
            this.lblUsernameEdit.Size = new System.Drawing.Size(119, 29);
            this.lblUsernameEdit.TabIndex = 39;
            this.lblUsernameEdit.Text = "Username:";
            // 
            // lblEditFirstNameEng
            // 
            this.lblEditFirstNameEng.AutoSize = true;
            this.lblEditFirstNameEng.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditFirstNameEng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblEditFirstNameEng.Location = new System.Drawing.Point(25, 124);
            this.lblEditFirstNameEng.Name = "lblEditFirstNameEng";
            this.lblEditFirstNameEng.Size = new System.Drawing.Size(125, 29);
            this.lblEditFirstNameEng.TabIndex = 41;
            this.lblEditFirstNameEng.Text = "First Name:";
            // 
            // tabHide
            // 
            this.tabHide.Controls.Add(this.gbHideEngineer);
            this.tabHide.Location = new System.Drawing.Point(4, 38);
            this.tabHide.Name = "tabHide";
            this.tabHide.Size = new System.Drawing.Size(1592, 877);
            this.tabHide.TabIndex = 2;
            this.tabHide.Text = "Hide/Unhide Engineer";
            this.tabHide.UseVisualStyleBackColor = true;
            // 
            // gbHideEngineer
            // 
            this.gbHideEngineer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbHideEngineer.BackColor = System.Drawing.Color.Transparent;
            this.gbHideEngineer.Controls.Add(this.cbEngHideName);
            this.gbHideEngineer.Controls.Add(this.btnUnhideEngineer);
            this.gbHideEngineer.Controls.Add(this.lblNameEngRem);
            this.gbHideEngineer.Controls.Add(this.btnHideEngineer);
            this.gbHideEngineer.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHideEngineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbHideEngineer.Location = new System.Drawing.Point(581, 128);
            this.gbHideEngineer.Name = "gbHideEngineer";
            this.gbHideEngineer.Size = new System.Drawing.Size(400, 270);
            this.gbHideEngineer.TabIndex = 69;
            this.gbHideEngineer.TabStop = false;
            this.gbHideEngineer.Text = "HIDE/UNHIDE Engineer";
            // 
            // cbEngHideName
            // 
            this.cbEngHideName.BackColor = System.Drawing.Color.White;
            this.cbEngHideName.DropDownWidth = 300;
            this.cbEngHideName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbEngHideName.FormattingEnabled = true;
            this.cbEngHideName.Location = new System.Drawing.Point(114, 64);
            this.cbEngHideName.Name = "cbEngHideName";
            this.cbEngHideName.Size = new System.Drawing.Size(179, 41);
            this.cbEngHideName.TabIndex = 84;
            this.cbEngHideName.DropDown += new System.EventHandler(this.EngHideNameComboBox_DropDown);
            // 
            // btnUnhideEngineer
            // 
            this.btnUnhideEngineer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnUnhideEngineer.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnhideEngineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnUnhideEngineer.Location = new System.Drawing.Point(88, 192);
            this.btnUnhideEngineer.Name = "btnUnhideEngineer";
            this.btnUnhideEngineer.Size = new System.Drawing.Size(225, 48);
            this.btnUnhideEngineer.TabIndex = 34;
            this.btnUnhideEngineer.Text = "UNHIDE ENGINEER";
            this.btnUnhideEngineer.UseVisualStyleBackColor = false;
            this.btnUnhideEngineer.Click += new System.EventHandler(this.btnUnhideEngineer_Click);
            // 
            // lblNameEngRem
            // 
            this.lblNameEngRem.AutoSize = true;
            this.lblNameEngRem.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameEngRem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblNameEngRem.Location = new System.Drawing.Point(30, 72);
            this.lblNameEngRem.Name = "lblNameEngRem";
            this.lblNameEngRem.Size = new System.Drawing.Size(78, 29);
            this.lblNameEngRem.TabIndex = 28;
            this.lblNameEngRem.Text = "Name:";
            // 
            // btnHideEngineer
            // 
            this.btnHideEngineer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnHideEngineer.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideEngineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnHideEngineer.Location = new System.Drawing.Point(88, 129);
            this.btnHideEngineer.Name = "btnHideEngineer";
            this.btnHideEngineer.Size = new System.Drawing.Size(225, 48);
            this.btnHideEngineer.TabIndex = 18;
            this.btnHideEngineer.Text = "HIDE ENGINEER";
            this.btnHideEngineer.UseVisualStyleBackColor = false;
            this.btnHideEngineer.Click += new System.EventHandler(this.btnHideEngineer_Click);
            // 
            // ViewEngInTbl
            // 
            this.ViewEngInTbl.Controls.Add(this.ViewStuffTable);
            this.ViewEngInTbl.Location = new System.Drawing.Point(4, 38);
            this.ViewEngInTbl.Name = "ViewEngInTbl";
            this.ViewEngInTbl.Size = new System.Drawing.Size(1592, 877);
            this.ViewEngInTbl.TabIndex = 3;
            this.ViewEngInTbl.Text = "View Engineer Details";
            this.ViewEngInTbl.UseVisualStyleBackColor = true;
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
            // lblManage
            // 
            this.lblManage.AutoSize = true;
            this.lblManage.BackColor = System.Drawing.Color.Transparent;
            this.lblManage.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManage.ForeColor = System.Drawing.Color.Black;
            this.lblManage.Location = new System.Drawing.Point(3, 0);
            this.lblManage.Name = "lblManage";
            this.lblManage.Size = new System.Drawing.Size(127, 36);
            this.lblManage.TabIndex = 70;
            this.lblManage.Text = "MANAGE";
            // 
            // lblEngineers
            // 
            this.lblEngineers.AutoSize = true;
            this.lblEngineers.BackColor = System.Drawing.Color.Transparent;
            this.lblEngineers.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineers.ForeColor = System.Drawing.Color.Black;
            this.lblEngineers.Location = new System.Drawing.Point(124, 0);
            this.lblEngineers.Name = "lblEngineers";
            this.lblEngineers.Size = new System.Drawing.Size(149, 36);
            this.lblEngineers.TabIndex = 71;
            this.lblEngineers.Text = "ENGINEERS";
            // 
            // ManageEngUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEngineers);
            this.Controls.Add(this.lblManage);
            this.Controls.Add(this.tabCManEng);
            this.Name = "ManageEngUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.Load += new System.EventHandler(this.ManageEngUC_Load);
            this.tabCManEng.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.gbAddEngineer.ResumeLayout(false);
            this.gbAddEngineer.PerformLayout();
            this.tabEdit.ResumeLayout(false);
            this.gbEditEng.ResumeLayout(false);
            this.gbEditEng.PerformLayout();
            this.tabHide.ResumeLayout(false);
            this.gbHideEngineer.ResumeLayout(false);
            this.gbHideEngineer.PerformLayout();
            this.ViewEngInTbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCManEng;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.GroupBox gbAddEngineer;
        private System.Windows.Forms.TextBox txtAddAssocProEng;
        private System.Windows.Forms.Label lblAddAssocProEng;
        private System.Windows.Forms.Label lblAddConfirmPassEng;
        private System.Windows.Forms.TextBox txtAddConfirmPassEng;
        private System.Windows.Forms.Label lblEmailAddEng;
        private System.Windows.Forms.TextBox txtAddEmailEng;
        private System.Windows.Forms.Label lblLastNameAddEng;
        private System.Windows.Forms.TextBox txtAddLastNameEng;
        private System.Windows.Forms.Button btnAddEng;
        private System.Windows.Forms.Label lblRealNameEng;
        private System.Windows.Forms.TextBox txtAddFirstNameEng;
        private System.Windows.Forms.Label lblPasswordEng;
        private System.Windows.Forms.Label lblUsernameEng;
        private System.Windows.Forms.TextBox txtAddPasswordEng;
        private System.Windows.Forms.TextBox txtAddUsernameEng;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.GroupBox gbEditEng;
        private System.Windows.Forms.ComboBox cbEditEngUsername;
        private System.Windows.Forms.TextBox txtEditLastNameEng;
        private System.Windows.Forms.Label lblEditLastNameEng;
        private System.Windows.Forms.TextBox txtEditEmailEng;
        private System.Windows.Forms.Label lblEditEmailEng;
        private System.Windows.Forms.TextBox txtEditAssocProEng;
        private System.Windows.Forms.Label lblEditAssocProEng;
        private System.Windows.Forms.Button btnResetEngineer;
        private System.Windows.Forms.TextBox txtEditFirstNameEng;
        private System.Windows.Forms.Button btnEditEng;
        private System.Windows.Forms.Label lblUsernameEdit;
        private System.Windows.Forms.Label lblEditFirstNameEng;
        private System.Windows.Forms.TabPage tabHide;
        private System.Windows.Forms.GroupBox gbHideEngineer;
        private System.Windows.Forms.ComboBox cbEngHideName;
        private System.Windows.Forms.Button btnUnhideEngineer;
        private System.Windows.Forms.Label lblNameEngRem;
        private System.Windows.Forms.Button btnHideEngineer;
        private System.Windows.Forms.Label lblManage;
        private System.Windows.Forms.Label lblEngineers;
        private System.Windows.Forms.TabPage ViewEngInTbl;
        private System.Windows.Forms.DataGridView ViewStuffTable;

    }
}
