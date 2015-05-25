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
    public partial class DesktopApp : Form
    {
        public SqlCommand Command;
        public SqlDataReader Reader;
        public SqlConnection ConnectSQL;
        public String EnteredUsername;
        public String EnteredPassword;
        public String CommandString;
        Boolean CorrectPassword;
        DatabaseStuff DBStuff = new DatabaseStuff();
        ManageEngUC manEngUC;
        ManageClientUC manClientUC;
        ManageProductsUC manProUC;
        AppointmentsUC appointUC;
        BoardsUC boardsUC;
        InvoicesUC invoicesUC;
        OrderStuffUC orderStuffUC;
        DrawBoardUC drawBoardUC;
        ManageOrdersUC manOrdersUC;
        string DBUsername;
        string DBPassword;
        int UserType;


        public DesktopApp()
        {
            manEngUC = new ManageEngUC();
            manClientUC = new ManageClientUC();
            manProUC = new ManageProductsUC();
            manOrdersUC = new ManageOrdersUC();
            appointUC = new AppointmentsUC();
            boardsUC = new BoardsUC();
            invoicesUC = new InvoicesUC();
            orderStuffUC = new OrderStuffUC();
            drawBoardUC = new DrawBoardUC();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            EnteredUsername = txtUsername.Text;
            EnteredPassword = txtPassword.Text;

            //Console.WriteLine("Entered Password: " + PasswordHash.CreateHash(EnteredPassword));

            if (EnteredUsername.Length == 0)
            {
                MessageBox.Show("Please enter a username");
                return;
            }
            else if (EnteredPassword.Length == 0)
            {
                MessageBox.Show("Please enter a password");
                return;
            }

            DBStuff.ConnectToDB();
            CommandString = "SELECT U_Username, U_Password, U_Type FROM Users WHERE U_Username = '" + EnteredUsername + "'";
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
                    DBUsername = Reader["U_Username"].ToString();
                    DBPassword = Reader["U_Password"].ToString();
                    UserType = Convert.ToInt32(Reader["U_Type"].ToString());
                }
            }

            CorrectPassword = PasswordHash.ValidatePassword(EnteredPassword, DBPassword);

            if (CorrectPassword == false)
            {
                MessageBox.Show("Password Is Incorrect");
                txtPassword.Clear();
            }

            if (UserType == 1 && CorrectPassword == true)
            {
                btnManageClients.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
                btnManageClients.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
                btnManageEngineers.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
                btnManageEngineers.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
                btnManageProducts.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
                btnManageProducts.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
                btnManageOrders.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
                btnManageOrders.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
                lblEnterDetails.Visible = false;
                txtPassword.Visible = false;
                txtUsername.Visible = false;
                lblPassword.Visible = false;
                lblUsername.Visible = false;
                btnLogin.Visible = false;
                linkLabelForgotPassword.Visible = false;
                btnLogout.Visible = true;
                SidePanel.Visible = true;
                gbWelcomeAdmin.Visible = true;
                btnManageClients.Visible = true;
                btnManageEngineers.Visible = true;
                btnManageProducts.Visible = true;
                btnManageOrders.Visible = true;
                txtPassword.Clear();
                //txtUsername.Clear();
                Console.WriteLine("Closed?: " + ConnectionState.Closed);
            }

            else if (UserType == 2 && CorrectPassword == true)
            {
                lblEnterDetails.Visible = false;
                txtPassword.Visible = false;
                txtUsername.Visible = false;
                lblPassword.Visible = false;
                lblUsername.Visible = false;
                btnLogin.Visible = false;
                linkLabelForgotPassword.Visible = false;
                btnLogout.Visible = true;
                txtPassword.Clear();
                //txtUsername.Clear();
                gbWelcomEng.Visible = true;
                SidePanel.Visible = true;
                btnDrawBoard.Visible = true;
                btnCheckAppointments.Visible = true;
                btnViewBoards.Visible = true;
                btnCreateOrder.Visible = true;
                btnViewInvoices.Visible = true;
                Console.WriteLine("Closed?: " + ConnectionState.Closed);
            }
            boardsUC.EnteredUsername = txtUsername.Text;
            orderStuffUC.EngName = txtUsername.Text;
            txtUsername.Clear();
            Cursor.Current = Cursors.Default;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            HideEngineerStuff();
            HideProductStuff();
            gbWelcomeAdmin.Visible = false;
            gbWelcomEng.Visible = false;
            btnManageClients.Visible = false;
            btnManageEngineers.Visible = false;
            btnManageProducts.Visible = false;
            btnManageOrders.Visible = false;
            SidePanel.Visible = false;
            lblEnterDetails.Visible = true;
            txtPassword.Visible = true;
            txtUsername.Visible = true;
            lblPassword.Visible = true;
            lblUsername.Visible = true;
            btnLogin.Visible = true;
            linkLabelForgotPassword.Visible = true;
            btnLogout.Visible = false;
            txtUsername.Clear();
            btnCreateOrder.Visible = false;
            btnViewInvoices.Visible = false;
            manClientUC.Hide();
            manEngUC.Hide();
            manProUC.Hide();
            appointUC.Hide();
            boardsUC.Hide();
            invoicesUC.Hide();
            orderStuffUC.Hide();
            drawBoardUC.Hide();
            manOrdersUC.Hide();
        }

        private void linkLabelForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please See Email");
            txtPassword.Clear();
        }

        //Client Stuff
        public void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X, box.ClientRectangle.Y + (int)(strSize.Height / 2), box.ClientRectangle.Width - 1, box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void gbOrderDetails_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void gbBoardValues_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38));
        }

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            btnManageClients.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageClients.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageEngineers.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageEngineers.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageProducts.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageProducts.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageOrders.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageOrders.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            manEngUC.Hide();
            manProUC.Hide();
            manOrdersUC.Hide();
            manClientUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            manClientUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            manClientUC.Show();
            this.Controls.Add(manClientUC);
        }

        public bool UserIsValid(string firstPass, string ConfirmPass)
        {
            return (firstPass == ConfirmPass);
        }

        public String GetUsername()
        {
            return EnteredUsername = txtUsername.Text;
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            btnManageOrders.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageOrders.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageEngineers.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageEngineers.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageProducts.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageProducts.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageClients.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageClients.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            manClientUC.Hide();
            manProUC.Hide();
            manEngUC.Hide();
            manOrdersUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            manOrdersUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            manOrdersUC.Show();
            this.Controls.Add(manOrdersUC);
        }

        //Clients Stuff

        //Engineer Stuff
        private void btnManageEngineers_Click(object sender, EventArgs e)
        {
            btnManageClients.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageClients.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageEngineers.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageEngineers.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageProducts.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageProducts.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageOrders.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageOrders.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            manClientUC.Hide();
            manProUC.Hide();
            manOrdersUC.Hide();
            manEngUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            manEngUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            manEngUC.Show();
            this.Controls.Add(manEngUC);
        }

        private void btnCheckAppointments_Click(object sender, EventArgs e)
        {
            btnCheckAppointments.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCheckAppointments.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewBoards.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewBoards.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnDrawBoard.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnDrawBoard.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCreateOrder.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnViewInvoices.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewInvoices.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            boardsUC.Hide();
            invoicesUC.Hide();
            orderStuffUC.Hide();
            drawBoardUC.Hide();
            appointUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            appointUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            appointUC.Show();
            this.Controls.Add(appointUC);

        }

        private void btnEnterBoardValues_Click(object sender, EventArgs e)
        {
            btnViewBoards.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnViewBoards.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCheckAppointments.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCheckAppointments.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnDrawBoard.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnDrawBoard.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCreateOrder.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnViewInvoices.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewInvoices.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            appointUC.Hide();
            invoicesUC.Hide();
            orderStuffUC.Hide();
            drawBoardUC.Hide();
            boardsUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            boardsUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            boardsUC.Show();
            this.Controls.Add(boardsUC);
        }

        private void btnDrawBoard_Click(object sender, EventArgs e)
        {
            btnDrawBoard.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnDrawBoard.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewBoards.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewBoards.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCheckAppointments.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCheckAppointments.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCreateOrder.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnViewInvoices.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewInvoices.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            boardsUC.Hide();
            appointUC.Hide();
            orderStuffUC.Hide();
            invoicesUC.Hide();
            drawBoardUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            drawBoardUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            drawBoardUC.Show();
            this.Controls.Add(drawBoardUC);
        }

        private void btnViewInvoices_Click(object sender, EventArgs e)
        {
            btnViewInvoices.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnViewInvoices.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewBoards.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewBoards.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCheckAppointments.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCheckAppointments.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCreateOrder.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnDrawBoard.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnDrawBoard.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            boardsUC.Hide();
            appointUC.Hide();
            orderStuffUC.Hide();
            drawBoardUC.Hide();
            invoicesUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            invoicesUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            invoicesUC.Show();
            this.Controls.Add(invoicesUC);
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            btnCreateOrder.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnCreateOrder.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCheckAppointments.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnCheckAppointments.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnDrawBoard.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnDrawBoard.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnViewBoards.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewBoards.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnViewInvoices.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnViewInvoices.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            boardsUC.Hide();
            invoicesUC.Hide();
            appointUC.Hide();
            drawBoardUC.Hide();
            orderStuffUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            orderStuffUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            orderStuffUC.Show();
            this.Controls.Add(orderStuffUC);

        }

        public void HideEngineerStuff()
        {

        }
        //Engineer Stuff

        //Product Stuff
        private void btnManageProducts_Click(object sender, EventArgs e)
        {
            btnManageClients.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageClients.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageEngineers.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageEngineers.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageProducts.ForeColor = System.Drawing.Color.FromArgb(38, 38, 38);
            btnManageProducts.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageOrders.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            btnManageOrders.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);

            HideEngineerStuff();
            manEngUC.Hide();
            manClientUC.Hide();
            manOrdersUC.Hide();
            manProUC.Location = new Point(SidePanel.Width + 10, TitlePanel.Height + 20);
            manProUC.Size = new Size(DesktopApp.ActiveForm.Width - SidePanel.Width - 40, DesktopApp.ActiveForm.Height - TitlePanel.Height - 80);
            manProUC.Show();
            this.Controls.Add(manProUC);
        }


        public void HideProductStuff()
        {

        }
        //Product Stuff

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
