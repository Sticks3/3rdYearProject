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
    public partial class ManageEngUC : UserControl
    {
        DatabaseStuff DBStuff = new DatabaseStuff();
        DesktopApp DeskApp;
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;
        public ManageEngUC()
        {
            InitializeComponent();
        }

        private void btnAddEng_Click(object sender, EventArgs e)
        {
            string AddUsernameEng;
            string AddPasswordEng;
            string AddFirstNameEng;
            string AddLastNameEng;
            string AddEmailEng;
            string AddConfirmPassEng;
            int AddUserTypeEng;
            string AddProIDStr;
            int AddProID;

            AddUserTypeEng = 2;
            AddUsernameEng = txtAddUsernameEng.Text;
            AddPasswordEng = txtAddPasswordEng.Text;
            AddFirstNameEng = txtAddFirstNameEng.Text;
            AddLastNameEng = txtAddLastNameEng.Text;
            AddEmailEng = txtAddEmailEng.Text;
            AddConfirmPassEng = txtAddConfirmPassEng.Text;
            AddProIDStr = txtAddAssocProEng.Text;

            if (txtAddUsernameEng.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Username");
                return;
            }
            if (txtAddPasswordEng.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Password");
                return;
            }

            if (txtAddAssocProEng.Text.Length == 0)
            {
                AddProIDStr = "1";
            }
            AddProID = Convert.ToInt32(AddProIDStr);


            string newAddHashedPassword;
            string userHidden = "no";

            if (DeskApp.UserIsValid(AddPasswordEng, AddConfirmPassEng))
            {
                newAddHashedPassword = PasswordHash.CreateHash(AddPasswordEng);
                Console.WriteLine(newAddHashedPassword);
            }
            else
            {
                MessageBox.Show("Passwords Do Not Match");
                txtAddConfirmPassEng.Clear();
                return;
            }


            DBStuff.ConnectToDB();
            CommandString = "INSERT Users (U_Username, U_Password, U_FName, U_LName, U_Email, U_Type, U_Hidden, Pro_ID) VALUES ('" + AddUsernameEng + "','" + newAddHashedPassword + "','" 
                                                                                                                                    + AddFirstNameEng + "','" + AddLastNameEng + "','" + AddEmailEng + 
                                                                                                                                    "','" + AddUserTypeEng + "','" + userHidden + "','" + AddProID + "')";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();

            MessageBox.Show("Succesfully added: \nUsername: " + AddUsernameEng + "\nReal Name: " + AddFirstNameEng + "\nUser Type: " + AddUserTypeEng);
            txtAddPasswordEng.Clear();
            txtAddFirstNameEng.Clear();
            txtAddUsernameEng.Clear();
            txtAddEmailEng.Clear();
            txtAddLastNameEng.Clear();
            txtAddAssocProEng.Clear();
            txtAddConfirmPassEng.Clear();
            return;
        }

        private void btnEditEng_Click(object sender, EventArgs e)
        {
            string EditFirstNameEng = txtEditFirstNameEng.Text;
            string EditLastNameEng = txtEditLastNameEng.Text;
            string EditProIDStr = txtEditAssocProEng.Text;
            string EditEmailEng = txtEditEmailEng.Text;
            string EditEngUsername = cbEditEngUsername.Text;

            if (txtEditAssocProEng.Text.Length == 0)
            {
                EditProIDStr = "1";
            }
            int EditProID = Convert.ToInt32(EditProIDStr);

            Cursor.Current = Cursors.WaitCursor;

            DBStuff.ConnectToDB();
            CommandString = "UPDATE Users SET U_FName ='" + EditFirstNameEng + "', U_LName ='" + EditLastNameEng + "', U_Email = '" + EditEmailEng + "' WHERE U_Username = '" + EditEngUsername + "'";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();

            Cursor.Current = Cursors.Default;
            MessageBox.Show("Edit Complete");
            txtEditAssocProEng.Clear();
            txtEditEmailEng.Clear();
            txtEditFirstNameEng.Clear();
            txtEditLastNameEng.Clear();
            lblEditAssocProEng.Visible = false;
            txtEditAssocProEng.Visible = false;
            lblAddAssocProEng.Visible = false;
            txtAddAssocProEng.Visible = false;
            lblEditEmailEng.Visible = false;
            txtEditEmailEng.Visible = false;
            lblEditFirstNameEng.Visible = false;
            txtEditFirstNameEng.Visible = false;
            btnEditEng.Visible = false;
            txtEditLastNameEng.Visible = false;
            lblEditLastNameEng.Visible = false;
            cbEditEngUsername.Text = "";
            cbEditEngUsername.Items.Clear();
        }

        private void btnResetEngineer_Click(object sender, EventArgs e)
        {
            lblEditAssocProEng.Visible = false;
            txtEditAssocProEng.Visible = false;
            lblEditEmailEng.Visible = false;
            txtEditEmailEng.Visible = false;
            lblEditFirstNameEng.Visible = false;
            txtEditFirstNameEng.Visible = false;
            btnEditEng.Visible = false;
            txtEditLastNameEng.Visible = false;
            lblEditLastNameEng.Visible = false;
            cbEditEngUsername.Items.Clear();
            cbEditEngUsername.Text = "";
        }

        private void btnHideEngineer_Click(object sender, EventArgs e)
        {
            if (cbEngHideName.Text.Length == 0)
            {
                MessageBox.Show("Please enter a User you want to hide");
                return;
            }

            string retVal = cbEngHideName.Text;

            string[] tokens = retVal.Split(' ');
            string HideFNameEng = tokens[0];
            string HideLNameEng = tokens[1];


            DialogResult result = MessageBox.Show("Are you sure you want to hide " + HideFNameEng + " " + HideLNameEng + "?", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DBStuff.ConnectToDB();
                CommandString = "UPDATE Users SET U_Hidden='yes' WHERE U_FName = '" + HideFNameEng + "' AND U_LName = '" + HideLNameEng + "'";
                Command = new SqlCommand(CommandString);
                Command.CommandType = CommandType.Text;
                Command.Connection = DBStuff.ConnectSQL;
                Command.Connection.Open();
                Command.ExecuteNonQuery();
                Command.Connection.Close();
                MessageBox.Show("Succesfully Hidden: " + HideFNameEng + " " + HideLNameEng);

            }
            else if (result == DialogResult.No)
            {
                return;
            }
            cbEngHideName.Text = "";
            cbEngHideName.Items.Clear();
        }

        private void btnUnhideEngineer_Click(object sender, EventArgs e)
        {
            if (cbEngHideName.Text.Length == 0)
            {
                MessageBox.Show("Please enter a User you want to unhide");
                return;
            }

            string retVal = cbEngHideName.Text;

            string[] tokens = retVal.Split(' ');
            string HideFNameEng = tokens[0];
            string HideLNameEng = tokens[1];


            DialogResult result = MessageBox.Show("Are you sure you want to unhide " + HideFNameEng + " " + HideLNameEng + "?", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DBStuff.ConnectToDB();
                CommandString = "UPDATE Users SET U_Hidden='no' WHERE U_FName = '" + HideFNameEng + "' AND U_LName = '" + HideLNameEng + "'";
                Command = new SqlCommand(CommandString);
                Command.CommandType = CommandType.Text;
                Command.Connection = DBStuff.ConnectSQL;
                Command.Connection.Open();
                Command.ExecuteNonQuery();
                Command.Connection.Close();
                MessageBox.Show("Succesfully Reshown: " + HideFNameEng + " " + HideLNameEng);

            }
            else if (result == DialogResult.No)
            {
                return;
            }
            cbEngHideName.Text = "";
            cbEngHideName.Items.Clear();
        }

        private void EngHideNameComboBox_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbEngHideName.Items.Clear();

            DBStuff.ConnectToDB();
            CommandString = "SELECT U_FName, U_LName, U_Hidden FROM Users WHERE U_Type=2";
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
                    cbEngHideName.Items.Add(Reader["U_FName"].ToString() + " " + Reader["U_LName"].ToString() + " Hidden: " + Reader["U_Hidden"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;
        }

        private void EditEngUsernameCB_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbEditEngUsername.Items.Clear();
            DBStuff.ConnectToDB();
            CommandString = "SELECT U_Username FROM Users WHERE U_Type = 2";
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
                    cbEditEngUsername.Items.Add(Reader["U_Username"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;

        }

        private void EditEngUsernameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string EditEngUsername = cbEditEngUsername.Text;

            Cursor.Current = Cursors.WaitCursor;

            DBStuff.ConnectToDB();
            CommandString = "SELECT U_FName, U_LName, U_Email, Pro_ID FROM Users WHERE U_Type=2 AND U_Username = '" + EditEngUsername + "'";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            lblEditAssocProEng.Visible = true;
            txtEditAssocProEng.Visible = true;
            lblEditEmailEng.Visible = true;
            txtEditEmailEng.Visible = true;
            lblEditFirstNameEng.Visible = true;
            txtEditFirstNameEng.Visible = true;
            btnEditEng.Visible = true;
            txtEditLastNameEng.Visible = true;
            lblEditLastNameEng.Visible = true;

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    txtEditFirstNameEng.Text = Reader["U_FName"].ToString();
                    txtEditLastNameEng.Text = Reader["U_LName"].ToString();
                    txtEditEmailEng.Text = Reader["U_Email"].ToString();
                    try
                    {
                        int RetrProID = Convert.ToInt32(Reader["Pro_ID"]);
                        txtEditAssocProEng.Text = RetrProID.ToString();
                    }
                    catch (InvalidCastException)
                    {
                        txtEditAssocProEng.Text = "None";
                    }

                }
            }

            Command.Connection.Close();

        }

        private void tabCManEng_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == ViewEngInTbl.Name)
            {
                Cursor.Current = Cursors.WaitCursor;
                getEngInfoIntoTableAdmin();
                Cursor.Current = Cursors.Default;
            }

        }

        public void getEngInfoIntoTableAdmin()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID, U_Username, U_FName, U_LName, U_Email, U_Type, U_Hidden, Pro_ID FROM Users WHERE U_Type=2";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            try
            {
                SqlDataAdapter DataAdap = new SqlDataAdapter();
                DataAdap.SelectCommand = Command;
                DataTable EngDataSet = new DataTable();
                DataAdap.Fill(EngDataSet);
                BindingSource bSoruce = new BindingSource();
                bSoruce.DataSource = EngDataSet;
                ViewStuffTable.DataSource = bSoruce;
                DataAdap.Update(EngDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Command.Connection.Close();
        }

        private void gbAddEngineer_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void gbEditEng_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void gbHideEngineer_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void ManageEngUC_Load(object sender, EventArgs e)
        {

        }
    }
}
