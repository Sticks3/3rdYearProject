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
    public partial class InvoicesUC : UserControl
    {

        DatabaseStuff DBStuff = new DatabaseStuff();
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;
        int User_ID;
        int Pro_ID;
        int Order_ID;
        string Pro_Name;
        string C_Name;
        int C_Quantity;
        double C_Price;
        double C_Value;

        public InvoicesUC()
        {
            InitializeComponent();
        }

        private void cbSelectClient_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbSelectClient.Items.Clear();

            DBStuff.ConnectToDB();
            CommandString = "SELECT U_FName, U_LName FROM Users WHERE U_Type=3";
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
                    cbSelectClient.Items.Add(Reader["U_FName"].ToString() + " " + Reader["U_LName"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;

        }

        private void cbSelectClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProClientOrder.Visible = true;
            cbProClientOrder.Visible = true;
        }

        private void cbProClientOrder_DropDown(object sender, EventArgs e)
        {
            string retVal = cbSelectClient.Text;

            string[] tokens = retVal.Split(' ');
            string FNameClient = tokens[0];
            string LNameClient = tokens[1];

            Cursor.Current = Cursors.WaitCursor;

            cbProClientOrder.Items.Clear();

            //DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID FROM Users WHERE U_FName = '" + FNameClient + "' AND U_LName = '" + LNameClient + "'";
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
                    User_ID = Convert.ToInt32(Reader["User_ID"].ToString());
                }
            }

            Command.Connection.Close();

            DBStuff.ConnectToDB();
            CommandString = "SELECT Pro_ID FROM Orders WHERE Cust_ID = '" + User_ID + "'";
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
                    Pro_ID = Convert.ToInt32(Reader["Pro_ID"].ToString());
                }
            }

            Command.Connection.Close();

            //DBStuff.ConnectToDB();
            CommandString = "SELECT Pro_Name FROM Product WHERE Pro_ID = '" + Pro_ID + "'";
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
                    Pro_Name = Reader["Pro_Name"].ToString();
                }
            }

            Command.Connection.Close();

            //DBStuff.ConnectToDB();
            CommandString = "SELECT Order_ID, Order_Date FROM Orders WHERE Cust_ID = '" + User_ID + "'";
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
                    Order_ID = Convert.ToInt32(Reader["Order_ID"].ToString());
                    cbProClientOrder.Items.Add("Order ID: " + Reader["Order_ID"].ToString() + " " + Pro_Name + " " + Reader["Order_Date"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;
        }

        private void cbProClientOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

            CommandString = "SELECT * FROM Component WHERE Pro_ID = '" + Pro_ID + "'";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            if(Reader.HasRows)
            {
                while(Reader.Read())
                {
                    C_Name = Reader["C_Name"].ToString();
                    C_Price = Convert.ToDouble(Reader["C_Price"].ToString());
                    C_Quantity = Convert.ToInt32(Reader["C_Quantity"].ToString());
                    C_Value = Convert.ToDouble(Reader["C_Value"].ToString());
                }
            }
            Command.Connection.Close();

            CommandString = "SELECT * FROM Orders WHERE Order_ID = '" + Order_ID + "'";
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
                    MessageBox.Show("Order Number: " + Reader["Order_ID"].ToString() + "\r\n" + "Customer ID: " + Reader["Cust_ID"].ToString()
                                    + "\r\n" + "Product ID: " + Reader["Pro_ID"].ToString() + "\r\n" + "Order Details: " + Reader["Order_desc"].ToString()
                                    + "\r\n" + "Order Quantity: " + Reader["Order_quan"].ToString() + "\r\n" + "Order Date: " + Reader["Order_Date"].ToString()
                                    + "\r\n" + "Client Name: " + Reader["Client_FName"].ToString() + " " + Reader["Client_LName"].ToString()
                                    + "\r\n" + "Component Name: " + C_Name + "\r\n" + "Number of Components: " + C_Quantity + "\r\n" + "Measurement of Component: " + C_Value
                                    + "\r\n" + "Component Price: " + C_Price);
                }
            }

            cbProClientOrder.Text = "";
            cbSelectClient.Text = "";
            cbProClientOrder.Items.Clear();
            cbSelectClient.Items.Clear();
        }
    }
}
