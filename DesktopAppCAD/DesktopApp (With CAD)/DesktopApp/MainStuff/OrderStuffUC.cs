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
    public partial class OrderStuffUC : UserControl
    {

        DatabaseStuff DBStuff = new DatabaseStuff();
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;
        int User_ID;
        int Pro_ID;
        public string EngName;
        int EngID;

        public OrderStuffUC()
        {
            InitializeComponent();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            string AddProductNameOrder = cbProNameOrder.SelectedItem.ToString();
            string AddQuantityOrder = txtQuanOrder.Text;
            string AddDescOrder = txtDescOrder.Text;
            DateTime dateTime = DateTime.Now;

            if (cbCustNameOrder.Text.Length == 0)
            {
                MessageBox.Show("Please select a Customer Name");
                return;
            }
            if (cbProNameOrder.Text.Length == 0)
            {
                MessageBox.Show("Please select a Product Name");
                return;
            }
            Cursor.Current = Cursors.WaitCursor;

            string retValCust = cbCustNameOrder.Text;

            string[] tokensCust = retValCust.Split(' ');
            string OrderClientFName = tokensCust[0];
            string OrderClientLName = tokensCust[1];

            getEngID();

            DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID FROM Users WHERE U_FName = '" + OrderClientFName + "' AND U_LName = '" + OrderClientLName + "'";
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
            CommandString = "SELECT Pro_ID FROM Product WHERE Pro_Name = '" + AddProductNameOrder + "'";
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

            DBStuff.ConnectToDB();
            CommandString = "INSERT Orders (Cust_ID, Pro_ID, Order_Desc, Order_Quan, Client_FName, Client_LName, Order_Date, Eng_ID) VALUES ('" + User_ID + "','" + Pro_ID + "','" + AddDescOrder + "','" + AddQuantityOrder + "','" + OrderClientFName + "','" + OrderClientLName +  "','" + dateTime + "','" + EngID + "')";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();

            Cursor.Current = Cursors.Default;

            MessageBox.Show("Succesfully added Order: \nCustomer Name: " + retValCust + " \nProduct Name: " + AddProductNameOrder + "\nQuantity: " + AddQuantityOrder 
                             + "\nOrder Description: " + AddDescOrder + "\nOrder Date and Time: " + dateTime);
            cbProNameOrder.Items.Clear();
            cbProNameOrder.Text = "";
            cbCustNameOrder.Items.Clear();
            cbCustNameOrder.Text = "";
            txtDescOrder.Clear();
            txtQuanOrder.Clear();
            return;
        }

        private void cbCustNameOrder_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbCustNameOrder.Items.Clear();

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
                    cbCustNameOrder.Items.Add(Reader["U_FName"].ToString() + " " + Reader["U_LName"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;
        }

        private void cbProNameOrder_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbProNameOrder.Items.Clear();

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
                    cbProNameOrder.Items.Add(Reader["Pro_Name"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;

        }

        public void getEngID()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID FROM Users WHERE U_Username = '" + EngName + "'";
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
                    EngID = Convert.ToInt32(Reader["User_ID"].ToString());
                }
            }

            Command.Connection.Close();

        }
    }
}
