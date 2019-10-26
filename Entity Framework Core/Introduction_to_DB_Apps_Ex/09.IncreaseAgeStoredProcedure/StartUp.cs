using System;
using System.Data;
using System.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Database = MinionsDB;Integrated Security=true;");

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            int increaseMinionAgeId = int.Parse(Console.ReadLine());

            sqlConnection.Open();

            SqlCommand proc = new SqlCommand("usp_GetOlder @Id", sqlConnection);
            proc.CommandType = CommandType.StoredProcedure;

            proc.Parameters.AddWithValue("@id", increaseMinionAgeId);

            proc.ExecuteNonQuery();

            proc = new SqlCommand("SELECT Name, Age FROM Minions WHERE Id = @id", sqlConnection);
            proc.Parameters.AddWithValue("@id", increaseMinionAgeId);

            SqlDataReader reader = proc.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]} years old");
            }

        }
    }
}
