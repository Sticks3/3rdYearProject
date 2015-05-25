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
    public partial class BoardsUC : UserControl
    {

        DatabaseStuff DBStuff = new DatabaseStuff();
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;
        Boards boards = new Boards();
        public string EnteredUsername;
        public string AddEngID;
        public string AddCustID;
        string FNameCust;
        string LNameCust;
        string ProID;
        string AddCustName;
        string AddProName;
        string AddVoltage;
        string AddAmps;
        string AddResistance;
        string AddImpedance;
        string AddCurrent;

        public BoardsUC()
        {
            InitializeComponent();
        }

        private void lblManage_Click(object sender, EventArgs e)
        {

        }

        public void setUpChart()
        {
            BoardValuesChart.Series["Voltage"].Points.Clear();
            BoardValuesChart.Series["Amperage"].Points.Clear();
            BoardValuesChart.Series["Resistance"].Points.Clear();
            BoardValuesChart.Series["Impedance"].Points.Clear();
            BoardValuesChart.Series["Current"].Points.Clear();

            int NumRowsBoardTbl = boards.getNumRowsBoardTable();
            boards.GetBoardInfo();


            int v = 0;
            double x = 0.5;
            double y = 1.5;

            BoardValuesChart.ChartAreas["ChartArea1"].AxisX.Title = "Board Number";
            BoardValuesChart.ChartAreas["ChartArea1"].AxisY.Title = cbDiaMeasurement.Text;
            //BoardValuesChart.ChartAreas["ChartArea1"].AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;


            if (cbDiaMeasurement.Text == "Voltage")
            {
                for (int i = 1; i < NumRowsBoardTbl + 1; i++)
                {
                    BoardValuesChart.Series["Voltage"].Points.AddXY(i, boards.Voltage[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(x, y, boards.boardNum[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisY.Title = cbDiaMeasurement.Text + " (volts)";
                    v++;
                    x += 1;
                    y += 1;
                }
            }
            if (cbDiaMeasurement.Text == "Amperage")
            {
                for (int i = 1; i < NumRowsBoardTbl + 1; i++)
                {
                    BoardValuesChart.Series["Amperage"].Points.AddXY(i, boards.Amps[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(x, y, boards.boardNum[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisY.Title = cbDiaMeasurement.Text + " (amps)";
                    v++;
                    x += 1;
                    y += 1;
                }
            }
            if (cbDiaMeasurement.Text == "Resistance")
            {
                for (int i = 1; i < NumRowsBoardTbl + 1; i++)
                {
                    BoardValuesChart.Series["Resistance"].Points.AddXY(i, boards.Resistance[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(x, y, boards.boardNum[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisY.Title = cbDiaMeasurement.Text + " (ohms)";
                    v++;
                    x += 1;
                    y += 1;
                }
            }
            if (cbDiaMeasurement.Text == "Impedance")
            {
                for (int i = 1; i < NumRowsBoardTbl + 1; i++)
                {
                    BoardValuesChart.Series["Impedance"].Points.AddXY(i, boards.Impedance[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(x, y, boards.boardNum[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisY.Title = cbDiaMeasurement.Text + " (Z)";
                    v++;
                    x += 1;
                    y += 1;
                }
            }

            if (cbDiaMeasurement.Text == "Current")
            {
                for (int i = 1; i < NumRowsBoardTbl + 1; i++)
                {
                    BoardValuesChart.Series["Current"].Points.AddXY(i, boards.Current[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(x, y, boards.boardNum[v]);
                    BoardValuesChart.ChartAreas["ChartArea1"].AxisY.Title = cbDiaMeasurement.Text + " (I)";
                    v++;
                    x += 1;
                    y += 1;
                }
            }


        }

        private void cbDiaMeasurement_DropDown(object sender, EventArgs e)
        {
            cbDiaMeasurement.Items.Clear();
            cbDiaMeasurement.Items.Add("Voltage");
            cbDiaMeasurement.Items.Add("Amperage");
            cbDiaMeasurement.Items.Add("Resistance");
            cbDiaMeasurement.Items.Add("Impedance");
            cbDiaMeasurement.Items.Add("Current");
        }

        private void cbDiaMeasurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            BoardValuesChart.Visible = true;

            Cursor.Current = Cursors.WaitCursor;
            setUpChart();
            Cursor.Current = Cursors.Default;
        }

        private void btnAddValues_Click(object sender, EventArgs e)
        {
            AddCustName = cbCustNameBoard.Text;
            AddProName = cbProNameBoard.Text;
            AddVoltage = txtVoltage.Text;
            AddAmps = txtAmps.Text;
            AddResistance = txtResistance.Text;
            AddImpedance = txtImpedance.Text;
            AddCurrent = txtCurrent.Text;


            if (cbCustNameBoard.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Customer Name");
                return;
            }
            if (cbProNameBoard.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Product Name");
                return;
            }

            string retVal = cbCustNameBoard.Text;

            string[] tokens = retVal.Split(' ');
            FNameCust = tokens[0];
            LNameCust = tokens[1];

            MessageBox.Show(AddCurrent);

            Cursor.Current = Cursors.WaitCursor;

            DBStuff.ConnectToDB();

            GetUserIDCust();
            GetUserID();
            getProID();

            CommandString = "INSERT BoardMeasurements (User_ID, Pro_ID, Voltage, Amps, Resistance, Impedance, CurrentV, Eng_ID) VALUES ('" + AddCustID + "','" + ProID + "','" + AddVoltage
                                                                                                                                        + "','" + AddAmps + "','" + AddResistance + "','"
                                                                                                                                        + AddImpedance + "','" + AddCurrent + "','" + AddEngID + "')";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();

            MessageBox.Show("Successfully added Board Measurments");
            txtVoltage.Clear();
            txtResistance.Clear();
            txtAmps.Clear();
            txtImpedance.Clear();
            txtCurrent.Clear();
            cbCustNameBoard.Text = "";
            cbProNameBoard.Text = "";
            cbCustNameBoard.Items.Clear();
            cbProNameBoard.Items.Clear();

            Cursor.Current = Cursors.Default;
        }

        public void GetUserID()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID FROM Users WHERE U_Username='" + EnteredUsername + "'";
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
                    AddEngID = Reader["User_ID"].ToString();
                }
            }

            Console.WriteLine("Eng ID: " + AddEngID);
            Command.Connection.Close();
        }

        public void GetUserIDCust()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID FROM Users WHERE U_FName = '" + FNameCust + "'AND U_LName = '" + LNameCust + "'";
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
                    AddCustID = Reader["User_ID"].ToString();
                }
            }

            Command.Connection.Close();
        }

        public void getProID()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT Pro_ID FROM Product WHERE Pro_Name = '" + AddProName + "'";
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
                    ProID = Reader["Pro_ID"].ToString();
                }
            }

            Command.Connection.Close();

        }

        public void getBoardInfoIntoTableEng()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT * FROM BoardMeasurements";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            SqlDataAdapter DataAdap = new SqlDataAdapter();
            DataAdap.SelectCommand = Command;
            DataTable BoardDataSet = new DataTable();

            try
            {
                DataAdap.Fill(BoardDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID, U_Username, U_FName FROM Users WHERE U_Type=3";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            DataAdap.SelectCommand = Command;
            DataTable ClientDataSet = new DataTable();

            try
            {
                DataAdap.Fill(ClientDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBStuff.ConnectToDB();
            CommandString = "SELECT Pro_ID, Pro_Name, Pro_Desc, Pro_Manufac FROM Product";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            DataAdap.SelectCommand = Command;
            DataTable ProDataSet = new DataTable();

            try
            {
                DataAdap.Fill(ProDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ClientDataSet.Merge(ProDataSet);
            BoardDataSet.Merge(ClientDataSet);
            ViewStuffTable.DataSource = BoardDataSet;
            Command.Connection.Close();
        }

        private void CustInfoComboBox_DropDown(object sender, System.EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            cbCustNameBoard.Items.Clear();
            DBStuff.ConnectToDB();
            CommandString = "SELECT U_FName, U_LName FROM Users WHERE U_Type = 3";
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
                    cbCustNameBoard.Items.Add(Reader["U_FName"].ToString() + " " + Reader["U_LName"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;
        }

        private void ProNameComboBox_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbProNameBoard.Items.Clear();
            DBStuff.ConnectToDB();
            CommandString = "SELECT Pro_Name FROM Product";
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
                    cbProNameBoard.Items.Add(Reader["Pro_Name"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;
        }

        private void tabCManClients_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == tabViewInTbl.Name)
            {
                Cursor.Current = Cursors.WaitCursor;
                getBoardInfoIntoTableEng();
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
