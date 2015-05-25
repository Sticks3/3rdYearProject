namespace DesktopApp
{
    partial class BoardsUC
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabCManClients = new System.Windows.Forms.TabControl();
            this.tabEnterBoardVals = new System.Windows.Forms.TabPage();
            this.gbBoardValues = new System.Windows.Forms.GroupBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.cbProNameBoard = new System.Windows.Forms.ComboBox();
            this.cbCustNameBoard = new System.Windows.Forms.ComboBox();
            this.lblCustName = new System.Windows.Forms.Label();
            this.lblProName = new System.Windows.Forms.Label();
            this.lblImpedance = new System.Windows.Forms.Label();
            this.txtImpedance = new System.Windows.Forms.TextBox();
            this.btnAddValues = new System.Windows.Forms.Button();
            this.lblResistance = new System.Windows.Forms.Label();
            this.txtResistance = new System.Windows.Forms.TextBox();
            this.lblAmps = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.txtAmps = new System.Windows.Forms.TextBox();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.tabViewInTbl = new System.Windows.Forms.TabPage();
            this.ViewStuffTable = new System.Windows.Forms.DataGridView();
            this.tabViewInGraph = new System.Windows.Forms.TabPage();
            this.lblDiaMeas = new System.Windows.Forms.Label();
            this.cbDiaMeasurement = new System.Windows.Forms.ComboBox();
            this.BoardValuesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblBoards = new System.Windows.Forms.Label();
            this.tabCManClients.SuspendLayout();
            this.tabEnterBoardVals.SuspendLayout();
            this.gbBoardValues.SuspendLayout();
            this.tabViewInTbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).BeginInit();
            this.tabViewInGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardValuesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCManClients
            // 
            this.tabCManClients.Controls.Add(this.tabEnterBoardVals);
            this.tabCManClients.Controls.Add(this.tabViewInTbl);
            this.tabCManClients.Controls.Add(this.tabViewInGraph);
            this.tabCManClients.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCManClients.Location = new System.Drawing.Point(9, 39);
            this.tabCManClients.Name = "tabCManClients";
            this.tabCManClients.SelectedIndex = 0;
            this.tabCManClients.Size = new System.Drawing.Size(1600, 919);
            this.tabCManClients.TabIndex = 83;
            this.tabCManClients.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabCManClients_Selected);
            // 
            // tabEnterBoardVals
            // 
            this.tabEnterBoardVals.Controls.Add(this.gbBoardValues);
            this.tabEnterBoardVals.Location = new System.Drawing.Point(4, 38);
            this.tabEnterBoardVals.Name = "tabEnterBoardVals";
            this.tabEnterBoardVals.Size = new System.Drawing.Size(1592, 877);
            this.tabEnterBoardVals.TabIndex = 2;
            this.tabEnterBoardVals.Text = "Enter Board Values";
            this.tabEnterBoardVals.UseVisualStyleBackColor = true;
            // 
            // gbBoardValues
            // 
            this.gbBoardValues.BackColor = System.Drawing.Color.Transparent;
            this.gbBoardValues.Controls.Add(this.lblCurrent);
            this.gbBoardValues.Controls.Add(this.txtCurrent);
            this.gbBoardValues.Controls.Add(this.cbProNameBoard);
            this.gbBoardValues.Controls.Add(this.cbCustNameBoard);
            this.gbBoardValues.Controls.Add(this.lblCustName);
            this.gbBoardValues.Controls.Add(this.lblProName);
            this.gbBoardValues.Controls.Add(this.lblImpedance);
            this.gbBoardValues.Controls.Add(this.txtImpedance);
            this.gbBoardValues.Controls.Add(this.btnAddValues);
            this.gbBoardValues.Controls.Add(this.lblResistance);
            this.gbBoardValues.Controls.Add(this.txtResistance);
            this.gbBoardValues.Controls.Add(this.lblAmps);
            this.gbBoardValues.Controls.Add(this.lblVoltage);
            this.gbBoardValues.Controls.Add(this.txtAmps);
            this.gbBoardValues.Controls.Add(this.txtVoltage);
            this.gbBoardValues.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBoardValues.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.gbBoardValues.Location = new System.Drawing.Point(581, 128);
            this.gbBoardValues.Name = "gbBoardValues";
            this.gbBoardValues.Size = new System.Drawing.Size(400, 451);
            this.gbBoardValues.TabIndex = 73;
            this.gbBoardValues.TabStop = false;
            this.gbBoardValues.Text = "Board Values";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblCurrent.Location = new System.Drawing.Point(12, 307);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(94, 29);
            this.lblCurrent.TabIndex = 85;
            this.lblCurrent.Text = "Current:";
            // 
            // txtCurrent
            // 
            this.txtCurrent.BackColor = System.Drawing.Color.White;
            this.txtCurrent.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtCurrent.Location = new System.Drawing.Point(196, 304);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(179, 37);
            this.txtCurrent.TabIndex = 50;
            // 
            // cbProNameBoard
            // 
            this.cbProNameBoard.BackColor = System.Drawing.Color.White;
            this.cbProNameBoard.DropDownWidth = 300;
            this.cbProNameBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbProNameBoard.FormattingEnabled = true;
            this.cbProNameBoard.Location = new System.Drawing.Point(197, 89);
            this.cbProNameBoard.Name = "cbProNameBoard";
            this.cbProNameBoard.Size = new System.Drawing.Size(179, 37);
            this.cbProNameBoard.TabIndex = 84;
            this.cbProNameBoard.DropDown += new System.EventHandler(this.ProNameComboBox_DropDown);
            // 
            // cbCustNameBoard
            // 
            this.cbCustNameBoard.BackColor = System.Drawing.Color.White;
            this.cbCustNameBoard.DropDownWidth = 300;
            this.cbCustNameBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.cbCustNameBoard.FormattingEnabled = true;
            this.cbCustNameBoard.Location = new System.Drawing.Point(197, 46);
            this.cbCustNameBoard.Name = "cbCustNameBoard";
            this.cbCustNameBoard.Size = new System.Drawing.Size(179, 37);
            this.cbCustNameBoard.TabIndex = 83;
            this.cbCustNameBoard.DropDown += new System.EventHandler(this.CustInfoComboBox_DropDown);
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblCustName.Location = new System.Drawing.Point(14, 54);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(178, 29);
            this.lblCustName.TabIndex = 52;
            this.lblCustName.Text = "Customer Name:";
            // 
            // lblProName
            // 
            this.lblProName.AutoSize = true;
            this.lblProName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblProName.Location = new System.Drawing.Point(14, 95);
            this.lblProName.Name = "lblProName";
            this.lblProName.Size = new System.Drawing.Size(160, 29);
            this.lblProName.TabIndex = 50;
            this.lblProName.Text = "Product Name:";
            // 
            // lblImpedance
            // 
            this.lblImpedance.AutoSize = true;
            this.lblImpedance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpedance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblImpedance.Location = new System.Drawing.Point(13, 264);
            this.lblImpedance.Name = "lblImpedance";
            this.lblImpedance.Size = new System.Drawing.Size(129, 29);
            this.lblImpedance.TabIndex = 48;
            this.lblImpedance.Text = "Impedance:";
            // 
            // txtImpedance
            // 
            this.txtImpedance.BackColor = System.Drawing.Color.White;
            this.txtImpedance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpedance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtImpedance.Location = new System.Drawing.Point(197, 261);
            this.txtImpedance.Name = "txtImpedance";
            this.txtImpedance.Size = new System.Drawing.Size(179, 37);
            this.txtImpedance.TabIndex = 49;
            // 
            // btnAddValues
            // 
            this.btnAddValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnAddValues.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddValues.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnAddValues.Location = new System.Drawing.Point(90, 370);
            this.btnAddValues.Name = "btnAddValues";
            this.btnAddValues.Size = new System.Drawing.Size(225, 48);
            this.btnAddValues.TabIndex = 18;
            this.btnAddValues.Text = "ADD VALUES";
            this.btnAddValues.UseVisualStyleBackColor = false;
            this.btnAddValues.Click += new System.EventHandler(this.btnAddValues_Click);
            // 
            // lblResistance
            // 
            this.lblResistance.AutoSize = true;
            this.lblResistance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblResistance.Location = new System.Drawing.Point(13, 221);
            this.lblResistance.Name = "lblResistance";
            this.lblResistance.Size = new System.Drawing.Size(123, 29);
            this.lblResistance.TabIndex = 42;
            this.lblResistance.Text = "Resistance:";
            // 
            // txtResistance
            // 
            this.txtResistance.BackColor = System.Drawing.Color.White;
            this.txtResistance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResistance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtResistance.Location = new System.Drawing.Point(197, 218);
            this.txtResistance.Name = "txtResistance";
            this.txtResistance.Size = new System.Drawing.Size(179, 37);
            this.txtResistance.TabIndex = 47;
            // 
            // lblAmps
            // 
            this.lblAmps.AutoSize = true;
            this.lblAmps.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblAmps.Location = new System.Drawing.Point(13, 178);
            this.lblAmps.Name = "lblAmps";
            this.lblAmps.Size = new System.Drawing.Size(74, 29);
            this.lblAmps.TabIndex = 41;
            this.lblAmps.Text = "Amps:";
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblVoltage.Location = new System.Drawing.Point(13, 135);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(94, 29);
            this.lblVoltage.TabIndex = 40;
            this.lblVoltage.Text = "Voltage:";
            // 
            // txtAmps
            // 
            this.txtAmps.BackColor = System.Drawing.Color.White;
            this.txtAmps.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtAmps.Location = new System.Drawing.Point(197, 175);
            this.txtAmps.Name = "txtAmps";
            this.txtAmps.Size = new System.Drawing.Size(179, 37);
            this.txtAmps.TabIndex = 46;
            // 
            // txtVoltage
            // 
            this.txtVoltage.BackColor = System.Drawing.Color.White;
            this.txtVoltage.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtVoltage.Location = new System.Drawing.Point(196, 132);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.Size = new System.Drawing.Size(179, 37);
            this.txtVoltage.TabIndex = 45;
            // 
            // tabViewInTbl
            // 
            this.tabViewInTbl.Controls.Add(this.ViewStuffTable);
            this.tabViewInTbl.Location = new System.Drawing.Point(4, 38);
            this.tabViewInTbl.Name = "tabViewInTbl";
            this.tabViewInTbl.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewInTbl.Size = new System.Drawing.Size(1592, 877);
            this.tabViewInTbl.TabIndex = 0;
            this.tabViewInTbl.Text = "View Board Values In Table";
            this.tabViewInTbl.UseVisualStyleBackColor = true;
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
            this.ViewStuffTable.TabIndex = 61;
            // 
            // tabViewInGraph
            // 
            this.tabViewInGraph.Controls.Add(this.lblDiaMeas);
            this.tabViewInGraph.Controls.Add(this.cbDiaMeasurement);
            this.tabViewInGraph.Controls.Add(this.BoardValuesChart);
            this.tabViewInGraph.Location = new System.Drawing.Point(4, 38);
            this.tabViewInGraph.Name = "tabViewInGraph";
            this.tabViewInGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewInGraph.Size = new System.Drawing.Size(1592, 877);
            this.tabViewInGraph.TabIndex = 1;
            this.tabViewInGraph.Text = "View Board Values In Graph";
            this.tabViewInGraph.UseVisualStyleBackColor = true;
            // 
            // lblDiaMeas
            // 
            this.lblDiaMeas.AutoSize = true;
            this.lblDiaMeas.BackColor = System.Drawing.Color.Transparent;
            this.lblDiaMeas.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaMeas.ForeColor = System.Drawing.Color.Black;
            this.lblDiaMeas.Location = new System.Drawing.Point(514, 36);
            this.lblDiaMeas.Name = "lblDiaMeas";
            this.lblDiaMeas.Size = new System.Drawing.Size(246, 29);
            this.lblDiaMeas.TabIndex = 87;
            this.lblDiaMeas.Text = "Diagram Measurement:";
            // 
            // cbDiaMeasurement
            // 
            this.cbDiaMeasurement.BackColor = System.Drawing.SystemColors.Window;
            this.cbDiaMeasurement.DropDownWidth = 350;
            this.cbDiaMeasurement.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDiaMeasurement.ForeColor = System.Drawing.Color.Black;
            this.cbDiaMeasurement.FormattingEnabled = true;
            this.cbDiaMeasurement.Location = new System.Drawing.Point(769, 33);
            this.cbDiaMeasurement.Name = "cbDiaMeasurement";
            this.cbDiaMeasurement.Size = new System.Drawing.Size(179, 37);
            this.cbDiaMeasurement.TabIndex = 86;
            this.cbDiaMeasurement.DropDown += new System.EventHandler(this.cbDiaMeasurement_DropDown);
            this.cbDiaMeasurement.SelectedIndexChanged += new System.EventHandler(this.cbDiaMeasurement_SelectedIndexChanged);
            // 
            // BoardValuesChart
            // 
            this.BoardValuesChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            this.BoardValuesChart.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardValuesChart.Legends.Add(legend1);
            this.BoardValuesChart.Location = new System.Drawing.Point(167, 108);
            this.BoardValuesChart.Name = "BoardValuesChart";
            this.BoardValuesChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(60)))), ((int)(((byte)(204)))));
            series1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Voltage";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(223)))));
            series2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.Name = "Amperage";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(16)))), ((int)(((byte)(117)))));
            series3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Resistance";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(213)))), ((int)(((byte)(11)))));
            series4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Impedance";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Gold;
            series5.Legend = "Legend1";
            series5.Name = "Current";
            this.BoardValuesChart.Series.Add(series1);
            this.BoardValuesChart.Series.Add(series2);
            this.BoardValuesChart.Series.Add(series3);
            this.BoardValuesChart.Series.Add(series4);
            this.BoardValuesChart.Series.Add(series5);
            this.BoardValuesChart.Size = new System.Drawing.Size(1258, 660);
            this.BoardValuesChart.TabIndex = 83;
            this.BoardValuesChart.Text = "Board Values";
            // 
            // lblBoards
            // 
            this.lblBoards.AutoSize = true;
            this.lblBoards.BackColor = System.Drawing.Color.Transparent;
            this.lblBoards.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoards.ForeColor = System.Drawing.Color.Black;
            this.lblBoards.Location = new System.Drawing.Point(16, 0);
            this.lblBoards.Name = "lblBoards";
            this.lblBoards.Size = new System.Drawing.Size(117, 36);
            this.lblBoards.TabIndex = 100;
            this.lblBoards.Text = "BOARDS";
            this.lblBoards.Click += new System.EventHandler(this.lblManage_Click);
            // 
            // BoardsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBoards);
            this.Controls.Add(this.tabCManClients);
            this.Name = "BoardsUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.tabCManClients.ResumeLayout(false);
            this.tabEnterBoardVals.ResumeLayout(false);
            this.gbBoardValues.ResumeLayout(false);
            this.gbBoardValues.PerformLayout();
            this.tabViewInTbl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewStuffTable)).EndInit();
            this.tabViewInGraph.ResumeLayout(false);
            this.tabViewInGraph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardValuesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCManClients;
        private System.Windows.Forms.TabPage tabViewInTbl;
        private System.Windows.Forms.TabPage tabViewInGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart BoardValuesChart;
        private System.Windows.Forms.Label lblDiaMeas;
        private System.Windows.Forms.ComboBox cbDiaMeasurement;
        private System.Windows.Forms.DataGridView ViewStuffTable;
        private System.Windows.Forms.Label lblBoards;
        private System.Windows.Forms.TabPage tabEnterBoardVals;
        private System.Windows.Forms.GroupBox gbBoardValues;
        private System.Windows.Forms.ComboBox cbProNameBoard;
        private System.Windows.Forms.ComboBox cbCustNameBoard;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Label lblProName;
        private System.Windows.Forms.Label lblImpedance;
        private System.Windows.Forms.TextBox txtImpedance;
        private System.Windows.Forms.Button btnAddValues;
        private System.Windows.Forms.Label lblResistance;
        private System.Windows.Forms.TextBox txtResistance;
        private System.Windows.Forms.Label lblAmps;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.TextBox txtAmps;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtCurrent;
    }
}
