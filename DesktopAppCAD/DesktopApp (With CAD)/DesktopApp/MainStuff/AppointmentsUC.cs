using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Imaging;

namespace DesktopApp
{
    public partial class AppointmentsUC : UserControl
    {
        DatabaseStuff DBStuff = new DatabaseStuff();
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;

        int NumRows;
        DateTime[] DateArr;
        int UserID;
        DateTime AppointDate;
        String ProbDesc;

        public AppointmentsUC()
        {
            InitializeComponent();
        }

        public void getAppointDate()
        {
            Cursor.Current = Cursors.WaitCursor;
            DBStuff.ConnectToDB();
            CommandString = "SELECT Appointment_Time FROM Appointments";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            SqlDataAdapter DataAdap = new SqlDataAdapter();
            DataAdap.SelectCommand = Command;
            DataTable AppointDataSet = new DataTable();

            try
            {
                DataAdap.Fill(AppointDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            NumRows = Convert.ToInt32(AppointDataSet.Rows.Count.ToString());

            DateArr = new DateTime[NumRows];

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            int x = 0;

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    DateArr[x] = (DateTime)Reader["Appointment_Time"];
                    x++;
                }
            }

            Command.Connection.Close();

            this.AppointCalendar.TitleBackColor = System.Drawing.Color.Blue;
            this.AppointCalendar.TrailingForeColor = System.Drawing.Color.Red;
            this.AppointCalendar.TitleForeColor = System.Drawing.Color.Yellow;

            this.AppointCalendar.MaxSelectionCount = 1;

            this.AppointCalendar.BoldedDates = DateArr;
            //this.AppointCalendar.BoldedDates = new System.DateTime[] { new System.DateTime(2014, 12, 12, 15, 30, 0, 0) };

            Cursor.Current = Cursors.Default;
        }

        public void getAppointInfo()
        {
            /*DateTime SelectedDate = this.AppointCalendar.SelectionRange.End;
            DateTime SelectedDate2 = SelectedDate;
            SelectedDate2.Add(this.AppointCalendar.SelectionRange.Start.TimeOfDay);*/
            DateTime SelectedDate = new System.DateTime(2014, 12, 12, 15, 30, 0, 0);
            Cursor.Current = Cursors.WaitCursor;
            DBStuff.ConnectToDB();
            CommandString = "SELECT * FROM Appointments WHERE Appointment_Time='" + SelectedDate + "'";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    UserID = Convert.ToInt32(Reader["User_ID"].ToString());
                    AppointDate = (DateTime)Reader["Appointment_Time"];
                    ProbDesc = Reader["Problem_Desc"].ToString();
                }
            }
            Command.Connection.Close();

            DBStuff.ConnectToDB();
            CommandString = "SELECT U_FName, U_LName, U_Address FROM Users WHERE User_ID='" + UserID + "'";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {

                    MessageBox.Show("Client Name: " + Reader["U_FName"].ToString() + " " + Reader["U_LName"].ToString()
                        + "\r\n" + "Address: " + Reader["U_Address"].ToString() + "\r\n" + "Appointment Date And Time: " + AppointDate
                        + "\r\n" + "Problem Description: " + ProbDesc);
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;
        }


        private void AppointCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void AppointCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            getAppointInfo();
        }

        private void AppointCalendar_MouseHover(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(this.AppointCalendar, "Click to see Appointment Details");
            //tooltip.SetToolTip(this.AppointCalendar, AppointDate.ToString());
        }

        private void AppointmentsUC_Load(object sender, EventArgs e)
        {
            getAppointDate();
        }
    }
}
