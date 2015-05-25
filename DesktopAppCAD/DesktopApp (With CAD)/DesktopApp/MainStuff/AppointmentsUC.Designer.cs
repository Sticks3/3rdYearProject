namespace DesktopApp
{
    partial class AppointmentsUC
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
            this.AppointCalendar = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // AppointCalendar
            // 
            this.AppointCalendar.CalendarDimensions = new System.Drawing.Size(3, 6);
            this.AppointCalendar.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppointCalendar.Location = new System.Drawing.Point(9, 33);
            this.AppointCalendar.Name = "AppointCalendar";
            this.AppointCalendar.TabIndex = 0;
            this.AppointCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.AppointCalendar_DateChanged);
            this.AppointCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.AppointCalendar_DateSelected);
            this.AppointCalendar.MouseHover += new System.EventHandler(this.AppointCalendar_MouseHover);
            // 
            // AppointmentsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AppointCalendar);
            this.Name = "AppointmentsUC";
            this.Size = new System.Drawing.Size(1653, 961);
            this.Load += new System.EventHandler(this.AppointmentsUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar AppointCalendar;
    }
}
