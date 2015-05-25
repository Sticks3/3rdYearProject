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
    public partial class ManageProductsUC : UserControl
    {
        DatabaseStuff DBStuff = new DatabaseStuff();
        DesktopApp DeskApp;
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;

        public ManageProductsUC()
        {
            InitializeComponent();
        }

        public void getProductInfoIntoTableAdmin()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT * FROM Product";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            try
            {
                SqlDataAdapter DataAdap = new SqlDataAdapter();
                DataAdap.SelectCommand = Command;
                DataTable ProDataSet = new DataTable();
                DataAdap.Fill(ProDataSet);
                BindingSource bSoruce = new BindingSource();
                bSoruce.DataSource = ProDataSet;
                ViewStuffTable.DataSource = bSoruce;
                DataAdap.Update(ProDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Command.Connection.Close();
        }

        private void btnAddProductAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnHideProAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnUnhideProAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnEditProductAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnResetProduct_Click(object sender, EventArgs e)
        {
            lblProDescEdit.Visible = false;
            txtProDescEdit.Visible = false;
            lblProManEdit.Visible = false;
            txtProManEdit.Visible = false;
            lblProQuanEdit.Visible = false;
            txtProQuanEdit.Visible = false;
            cbEditProName.Text = "";
            cbEditProName.Items.Clear();
            btnEditProductAdmin.Visible = false;
        }

        private void HideProNameCB_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbHideProName.Items.Clear();

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
                    cbHideProName.Items.Add(Reader["Pro_Name"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;

        }

        private void EditProNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {

            string EditProductName = cbEditProName.Text;

            Cursor.Current = Cursors.WaitCursor;

            DBStuff.ConnectToDB();
            CommandString = "SELECT Pro_Quantity, Pro_Desc, Pro_Manufac FROM Product WHERE Pro_Name = '" + EditProductName + "'";
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
                    txtProQuanEdit.Text = Reader["Pro_Quantity"].ToString();
                    txtProDescEdit.Text = Reader["Pro_Desc"].ToString();
                    txtProManEdit.Text = Reader["Pro_Manufac"].ToString();
                }
            }

            Command.Connection.Close();

            lblProDescEdit.Visible = true;
            txtProDescEdit.Visible = true;
            lblProManEdit.Visible = true;
            txtProManEdit.Visible = true;
            lblProQuanEdit.Visible = true;
            txtProQuanEdit.Visible = true;
            btnEditProductAdmin.Visible = true;
            btnEditProductAdmin.Visible = true;

            Cursor.Current = Cursors.Default;
        }

        private void EditProNameCB_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbEditProName.Items.Clear();

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
                    cbEditProName.Items.Add(Reader["Pro_Name"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;

        }

        private void tabCManProducts_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == ViewProductInTbl.Name)
            {
                Cursor.Current = Cursors.WaitCursor;
                getProductInfoIntoTableAdmin();
                Cursor.Current = Cursors.Default;
            }

        }


        private void gbAddProduct_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void gbEditProduct_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void gbHideProduct_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void ManageProductsUC_Load(object sender, EventArgs e)
        {
        }
    }
}
