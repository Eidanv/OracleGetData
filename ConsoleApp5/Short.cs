using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace OracleGetData
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = "User Id = SYSTEM; password = Guitar1990; Data Source=localhost:1521/Elastic";

            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT CITY FROM countries WHERE ID = 800";

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("gsdgssdg: " + reader.GetString(0));
            }
            Console.ReadLine();
        }
    }
}
