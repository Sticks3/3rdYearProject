using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DesktopApp
{
    class Products
    {
        SqlCommand Command;
        SqlDataReader Reader;
        String CommandString;
        public String[] DBProductName;
        DatabaseStuff DBStuff = new DatabaseStuff();
        int rowCount;
        int rowsCount;

        public void GetProductDetails()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT Pro_Name FROM Product";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            int rowscountPro = NumRowsProducts();
            int x = 0;

            DBProductName = new String[rowscountPro]; 

            if(Reader.HasRows)
            {
                while(Reader.Read())
                {
                    rowsCount++;
                    DBProductName[x] = Reader["Pro_Name"].ToString();
                    x++;
                }
            }

            Command.Connection.Close();
        }

        public int NumRowsProducts()
        {
            //count number of rows in table
            DBStuff.ConnectToDB();
            CommandString = "SELECT COUNT(*) FROM Product";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            rowCount = (int)Command.ExecuteScalar();
            Command.Connection.Close();
            return rowCount;
        }
    }
}
