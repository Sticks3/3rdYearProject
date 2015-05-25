using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DesktopApp
{
    class DatabaseStuff
    {
        public SqlConnection ConnectSQL;
        //DesktopApp desktop = new DesktopApp();
        public void ConnectToDB()
        {

            String Username = "Andrea";
            String Password = "Roflogic4";
            //Username = desktop.EnteredUsername;


            /*builder = new SqlConnectionStringBuilder(GetConnectionString());
            builder.ConnectionString = "DefaultEndpointsProtocol=https; AccountName=devstoreaccount1; AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==; UseDevelopmentStorage=true";
            builder.Password = "Andrea";
            builder.AsynchronousProcessing = true;
            builder["Server"] = ".";
            builder["Connect Timeout"] = 1000;
            builder["Trusted_Connection"] = true;
            */
            //ConnectSQL = new SqlConnection(GetConnectionString());

            ConnectSQL = new SqlConnection(@"Server=tcp:a5bjh4v9ur.database.windows.net,1433;Database=DenwaDB;User ID=" + Username + "@a5bjh4v9ur;Password=" + Password + ";Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
        }
    }
}
