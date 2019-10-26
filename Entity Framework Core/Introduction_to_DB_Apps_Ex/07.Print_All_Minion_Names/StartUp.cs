using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _07.Print_All_Minion_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Database = MinionsDB;Integrated Security=true;");

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            SqlCommand allMinionNamesSql = new SqlCommand("SELECT Name FROM Minions", sqlConnection);

            SqlDataReader reader = allMinionNamesSql.ExecuteReader();

            List<string> minionNames = new List<string>();

            while (reader.Read())
            {
                minionNames.Add((string)reader[0]);
            }

            while (minionNames.Count > 0)
            {
                Console.WriteLine(minionNames.First());

                minionNames.RemoveAt(minionNames.IndexOf(minionNames.First()));

                if (minionNames.Count == 0)
                {
                    break;
                }

                Console.WriteLine(minionNames.Last());
               
                minionNames.RemoveAt(minionNames.IndexOf(minionNames.Last()));

            }
        }
    }
}
