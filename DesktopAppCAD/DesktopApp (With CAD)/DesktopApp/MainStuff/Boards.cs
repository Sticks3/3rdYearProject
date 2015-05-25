using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DesktopApp
{
    class Boards
    {
        SqlCommand Command;
        String CommandString;
        SqlDataReader Reader;
        int rowCount;
        DatabaseStuff DBStuff = new DatabaseStuff();
        public String[] Voltage;
        public String[] Amps;
        public String[] Resistance;
        public String[] Impedance;
        public String[] Current;
        public String[] boardNum;

        public int getNumRowsBoardTable()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT COUNT(*) FROM BoardMeasurements";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();

            rowCount = (int)Command.ExecuteScalar();
            Command.Connection.Close();
            return rowCount;
        }

        public void GetBoardInfo()
        {
            DBStuff.ConnectToDB();
            CommandString = "SELECT * FROM BoardMeasurements";
            Command = new SqlCommand(CommandString);
            Command.CommandType = CommandType.Text;
            Command.Connection = DBStuff.ConnectSQL;
            Command.Connection.Open();
            Command.ExecuteNonQuery();
            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            int NumRows = getNumRowsBoardTable();

            Voltage = new String[NumRows];
            Amps = new String[NumRows];
            Resistance = new String[NumRows];
            Impedance = new String[NumRows];
            Current = new String[NumRows];
            boardNum = new String[NumRows];

            int x = 0;

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Voltage[x] = Reader["Voltage"].ToString();
                    Amps[x] = Reader["Amps"].ToString();
                    Resistance[x] = Reader["Resistance"].ToString();
                    Impedance[x] = Reader["Impedance"].ToString();
                    Current[x] = Reader["CurrentV"].ToString();
                    boardNum[x] = Reader["Board_ID"].ToString();
                    x++;
                }
            }
            Console.WriteLine("Num Rows in board: " + NumRows);
            //Console.WriteLine(boardNum[1] = Reader["Board_ID"].ToString());
        }
    }
}
