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
    public partial class ManageClientUC : UserControl
    {
        DatabaseStuff DBStuff = new DatabaseStuff();
        DesktopApp DeskApp;
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String CommandString;

        public ManageClientUC()
        {

            InitializeComponent();
        }

        private void ManageClientUC_Load(object sender, EventArgs e)
        {

        }

        private void tabCManClients_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == ViewClientInTbl.Name)
            {
                Cursor.Current = Cursors.WaitCursor;
                getClientInfoIntoTableAdmin();
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            
            string AddUsernameClient;
            string AddPasswordClient;
            string AddFirstNameClient;
            string AddLastNameClient;
            string AddAddressClient;
            string AddEmailClient;
            string addConfirmPassClient;
            int addUserTypeClient;
            string AddProIDStr;
            int AddProID;

            if (txtAddUsernameClient.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Username");
                return;
            }
            if (txtAddPasswordClient.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Password");
                return;
            }

            addUserTypeClient = 3;
            AddUsernameClient = txtAddUsernameClient.Text;
            AddPasswordClient = txtAddPasswordClient.Text;
            AddFirstNameClient = txtaddRealNameClient.Text;
            AddLastNameClient = txtAddLastNameClient.Text;
            AddAddressClient = txtAddAddressClient.Text;
            AddEmailClient = txtAddEmailClient.Text;
            addConfirmPassClient = txtAddConfirmPassClient.Text;
            AddProIDStr = txtAddAssocProClient.Text;
            if (txtAddAssocProClient.Text.Length == 0)
            {
                AddProIDStr = "1";
            }
            AddProID = Convert.ToInt32(AddProIDStr);
            string newAddHashedPassword;

            string userHidden = "no";

            if (DeskApp.UserIsValid(AddPasswordClient, addConfirmPassClient))
            {
                newAddHashedPassword = PasswordHash.CreateHash(AddPasswordClient);
                Console.WriteLine(newAddHashedPassword);
            }
            else
            {
                MessageBox.Show("Passwords Do Not Match");
                txtAddConfirmPassClient.Clear();
                return;
            }


            DBStuff.ConnectToDB();
            CommandString = "INSERT Users (U_Username, U_FName, U_LName, U_Email, U_Password, U_Type, U_Hidden, U_Address, Pro_ID) VALUES ('" + AddUsernameClient + "','" + AddFirstNameClient + "','" 
                                                                                                                                            + AddLastNameClient + "','" + AddEmailClient + "','" 
                                                                                                                                            + newAddHashedPassword + "','" + addUserTypeClient + "','" 
                                                                                                                                            + userHidden + "','" + AddAddressClient + "','" 
                                                                                                                                            + AddProID + "')";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();

            MessageBox.Show("Succesfully added: \nUsername: " + AddUsernameClient + "\nFirst Name: " + AddFirstNameClient + "\nUser Type: " + addUserTypeClient);
            txtAddPasswordClient.Clear();
            txtaddRealNameClient.Clear();
            txtAddUsernameClient.Clear();
            txtAddAddressClient.Clear();
            txtAddEmailClient.Clear();
            txtAddLastNameClient.Clear();
            txtAddAssocProClient.Clear();
            txtAddConfirmPassClient.Clear();
            return;
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            string EditUsernameClient = cbEditClientUsername.Text;
            string EditFirstNameClient = txtEditFirstNameClient.Text;
            string EditLastNameClient = txtEditLastNameClient.Text;
            string EditProIDStr = txtEditAssocProClient.Text;
            string EditEmailClient = txtEditEmailClient.Text;
            string EditAddressClient = txtEditAddressClient.Text;

            if (txtEditAssocProClient.Text.Length == 0)
            {
                EditProIDStr = "1";
            }
            int EditProID = Convert.ToInt32(EditProIDStr);

            Cursor.Current = Cursors.WaitCursor;

            DBStuff.ConnectToDB();
            CommandString = "UPDATE Users SET U_FName ='" + EditFirstNameClient + "', U_LName ='" + EditLastNameClient + "', U_Email = '" + EditEmailClient + "', U_Address = '" + EditAddressClient + "' WHERE U_Username = '" + EditUsernameClient + "'";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Command.Connection.Close();

            Cursor.Current = Cursors.Default;
            MessageBox.Show("Edit Complete");
            cbEditClientUsername.Items.Clear();
            cbEditClientUsername.Text = "";
            txtEditAddressClient.Clear();
            txtEditAssocProClient.Clear();
            txtEditEmailClient.Clear();
            txtEditFirstNameClient.Clear();
            txtEditLastNameClient.Clear();
            lblEditAssocProClient.Visible = false;
            txtEditAssocProClient.Visible = false;
            lblAddAssocProClient.Visible = false;
            txtAddAssocProClient.Visible = false;
            lblEditEmailClient.Visible = false;
            txtEditEmailClient.Visible = false;
            lblEditFirstNameClient.Visible = false;
            txtEditFirstNameClient.Visible = false;
            btnEditClient.Visible = false;
            txtEditAddressClient.Visible = false;
            lblEditAddressClient.Visible = false;
            txtEditLastNameClient.Visible = false;
            lblEditLastNameClient.Visible = false;
        }

        private void btnResetEditClient_Click(object sender, EventArgs e)
        {
            lblEditAssocProClient.Visible = false;
            txtEditAssocProClient.Visible = false;
            lblEditEmailClient.Visible = false;
            txtEditEmailClient.Visible = false;
            lblEditFirstNameClient.Visible = false;
            txtEditFirstNameClient.Visible = false;
            btnEditClient.Visible = false;
            txtEditAddressClient.Visible = false;
            lblEditAddressClient.Visible = false;
            txtEditLastNameClient.Visible = false;
            lblEditLastNameClient.Visible = false;
            cbEditClientUsername.Items.Clear();
            cbEditClientUsername.Text = "";
        }

        private void btnHideClient_Click(object sender, EventArgs e)
        {
            if (cbHideUsernameClient.Text.Length == 0)
            {
                MessageBox.Show("Please enter a User you want to Hide");
                return;
            }

            string retVal = cbHideUsernameClient.Text;

            string[] tokens = retVal.Split(' ');
            string HideFNameClient = tokens[0];
            string HideLNameClient = tokens[1];

            string HideUsernameClient = cbHideUsernameClient.Text;

            DialogResult result = MessageBox.Show("Are you sure you want to hide " + HideFNameClient + " " + HideLNameClient + "?", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DBStuff.ConnectToDB();
                CommandString = "UPDATE Users SET U_Hidden='yes' WHERE U_FName = '" + HideFNameClient + "'AND U_LName = '" + HideLNameClient + "'";
                Command = new SqlCommand(CommandString);
                Command.CommandType = CommandType.Text;
                Command.Connection = DBStuff.ConnectSQL;
                Command.Connection.Open();
                Command.ExecuteNonQuery();
                Command.Connection.Close();
                MessageBox.Show("Succesfully Hidden: " + HideFNameClient + " " + HideLNameClient);
                cbHideUsernameClient.Items.Clear();
                cbHideUsernameClient.Text = "";
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void btnUnhideClient_Click(object sender, EventArgs e)
        {
            if (cbHideUsernameClient.Text.Length == 0)
            {
                MessageBox.Show("Please enter a User you want to Hide");
                return;
            }

            string retVal = cbHideUsernameClient.Text;

            string[] tokens = retVal.Split(' ');
            string HideFNameClient = tokens[0];
            string HideLNameClient = tokens[1];

            string HideUsernameClient = cbHideUsernameClient.Text;
            DialogResult result = MessageBox.Show("Are you sure you want to reshow " + HideFNameClient + " " + HideLNameClient + "?", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DBStuff.ConnectToDB();
                CommandString = "UPDATE Users SET U_Hidden='no' WHERE U_FName = '" + HideFNameClient + "'AND U_LName = '" + HideLNameClient + "'";
                Command = new SqlCommand(CommandString);
                Command.CommandType = CommandType.Text;
                Command.Connection = DBStuff.ConnectSQL;
                Command.Connection.Open();
                Command.ExecuteNonQuery();
                Command.Connection.Close();
                MessageBox.Show("Succesfully Reshown: " + HideFNameClient + " " + HideLNameClient);
                cbHideUsernameClient.Items.Clear();
                cbHideUsernameClient.Text = "";
            }
            else if (result == DialogResult.No)
            {
                return;
            }
        }

        private void HideUsernameClientCB_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbHideUsernameClient.Items.Clear();

            DBStuff.ConnectToDB();
            CommandString = "SELECT U_FName, U_LName, U_Hidden FROM Users WHERE U_Type=3";
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
                    cbHideUsernameClient.Items.Add(Reader["U_FName"].ToString() + " " + Reader["U_LName"].ToString() + " Hidden: " + Reader["U_Hidden"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;

        }

        private void EditClientUsernameCB_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            cbEditClientUsername.Items.Clear();
            DBStuff.ConnectToDB();
            CommandString = "SELECT U_Username FROM Users WHERE U_Type = 3";
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
                    cbEditClientUsername.Items.Add(Reader["U_Username"].ToString());
                }
            }

            Command.Connection.Close();
            Cursor.Current = Cursors.Default;

        }

        private void EditClientUsernameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string EditUsernameClient = cbEditClientUsername.Text;

            Cursor.Current = Cursors.WaitCursor;

            DBStuff.ConnectToDB();
            CommandString = "SELECT U_FName, U_LName, U_Email, U_Address, Pro_ID FROM Users WHERE U_Type=3 AND U_Username = '" + EditUsernameClient + "'";
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
                    txtEditFirstNameClient.Text = Reader["U_FName"].ToString();
                    txtEditLastNameClient.Text = Reader["U_LName"].ToString();
                    txtEditAddressClient.Text = Reader["U_Address"].ToString();
                    txtEditEmailClient.Text = Reader["U_Email"].ToString();
                    try
                    {
                        int RetrProID = Convert.ToInt32(Reader["Pro_ID"]);
                        txtEditAssocProClient.Text = RetrProID.ToString();
                    }
                    catch (InvalidCastException)
                    {
                        txtEditAssocProClient.Text = "None";
                    }

                }
            }

            Command.Connection.Close();

            lblEditAssocProClient.Visible = true;
            txtEditAssocProClient.Visible = true;
            lblAddAssocProClient.Visible = true;
            txtAddAssocProClient.Visible = true;
            lblEditEmailClient.Visible = true;
            txtEditEmailClient.Visible = true;
            lblEditFirstNameClient.Visible = true;
            txtEditFirstNameClient.Visible = true;
            btnEditClient.Visible = true;
            txtEditAddressClient.Visible = true;
            lblEditAddressClient.Visible = true;
            txtEditLastNameClient.Visible = true;
            lblEditLastNameClient.Visible = true;

            Cursor.Current = Cursors.Default;

        }

        public void getClientInfoIntoTableAdmin()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT User_ID, U_Username, U_FName, U_LName, U_Email, U_Type, U_Hidden, U_Address FROM Users WHERE U_Type=3";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            try
            {
                SqlDataAdapter DataAdap = new SqlDataAdapter();
                DataAdap.SelectCommand = Command;
                DataTable ClientDataSet = new DataTable();
                DataAdap.Fill(ClientDataSet);
                BindingSource bSoruce = new BindingSource();
                bSoruce.DataSource = ClientDataSet;
                ViewStuffTable.DataSource = bSoruce;
                DataAdap.Update(ClientDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Command.Connection.Close();
        }

        private void gbAddClient_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void gbEditClient_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void gbHideClient_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DeskApp.DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }
    }
}
