using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    class StartUp
    {
        static void Main(string[] args)
        {

            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Database = MinionsDB;Integrated Security=true;");

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            int[] minionIds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SqlCommand getMinionsWithIds =
                new SqlCommand($@"UPDATE Minions
                               SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                               WHERE Id = @Id", sqlConnection);


            for (int i = 0; i < minionIds.Length; i++)
            {
                getMinionsWithIds.Parameters.AddWithValue("@Id", minionIds[i]);
                getMinionsWithIds.ExecuteNonQuery();
                getMinionsWithIds.Parameters.Clear();
            }

            SqlCommand allMinionNamesSql = new SqlCommand("SELECT Name, Age FROM Minions", sqlConnection);

            SqlDataReader reader = allMinionNamesSql.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0] + " " + reader[1]);
            }
          
        }
    }
}
