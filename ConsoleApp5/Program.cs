using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo: Basic ODP.NET application to connect, query, and return
            // results from an OracleDataReader to a console

            //Create a connection to Oracle			
            string conString = "User Id = SYSTEM; password = Guitar1990; Data Source=localhost:1521/Elastic";

            //How to connect to an Oracle DB with a DB alias.
            //Uncomment below and comment above.
            //"Data Source=<service name alias>;";

            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;

                        //Use the command to display employee names from 
                        // the EMPLOYEES table
                        cmd.CommandText = "select * from HELP";

                        // Assign id to the department number 50 
                        OracleParameter id = new OracleParameter("id", 800);
                        cmd.Parameters.Add(id);

                        //Execute the command and use DataReader to display the data
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("Employee First Name: " + reader.GetString(0));
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press 'Enter' to continue");

                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
