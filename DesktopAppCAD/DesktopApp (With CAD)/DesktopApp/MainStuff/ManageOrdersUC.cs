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
    public partial class ManageOrdersUC : UserControl
    {
        DatabaseStuff DBStuff = new DatabaseStuff();
        DesktopApp DeskApp;
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;

        public ManageOrdersUC()
        {
            InitializeComponent();
        }

        private void tabCManOrders_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == ViewOrderDetailsTbl.Name)
            {
                Cursor.Current = Cursors.WaitCursor;
                getOrderInfoIntoTableAdmin();
                Cursor.Current = Cursors.Default;
            }

        }

        public void getOrderInfoIntoTableAdmin()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT * FROM Orders";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            try
            {
                SqlDataAdapter DataAdap = new SqlDataAdapter();
                DataAdap.SelectCommand = Command;
                DataTable OrderDataSet = new DataTable();
                DataAdap.Fill(OrderDataSet);
                BindingSource bSoruce = new BindingSource();
                bSoruce.DataSource = OrderDataSet;
                ViewStuffTable.DataSource = bSoruce;
                DataAdap.Update(OrderDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Command.Connection.Close();
        }
    }
}
