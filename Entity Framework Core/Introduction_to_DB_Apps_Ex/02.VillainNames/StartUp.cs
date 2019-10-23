using System;
using System.Data.SqlClient;

namespace _02.VillainNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Integrated Security=true;");

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            SqlCommand getVillainNames = new SqlCommand(@"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                        FROM Villains AS v 
                                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                        GROUP BY v.Id, v.Name 
                                                        HAVING COUNT(mv.VillainId) > 3 
                                                        ORDER BY COUNT(mv.VillainId)",dbCon);


            SqlDataReader reader = getVillainNames.ExecuteReader();

            while (reader.Read())
            {
                string name = (string)reader[0];
                int minionsCount = (int)reader[1];

                Console.WriteLine(name + " - " + minionsCount);
            }
        }
    }
}
