﻿using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Integrated Security=true;");

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();

            int id = int.Parse(Console.ReadLine());

            SqlCommand getMinionNames = new SqlCommand(@"
                                            SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                            m.Name,
                                            m.Age
                                            FROM MinionsVillains AS mv
                                            JOIN Minions As m ON mv.MinionId = m.Id
                                            WHERE mv.VillainId = @Id
                                            ORDER BY m.Name", dbCon);

            SqlCommand getVillainName = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @Id", dbCon);

            getMinionNames.Parameters.AddWithValue("Id", id);

            getVillainName.Parameters.AddWithValue("Id", id);

            string villainName = (string)getVillainName.ExecuteScalar();

            if (string.IsNullOrEmpty(villainName))
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"Villain {villainName}");
            }
            
            SqlDataReader reader = getMinionNames.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    if (string.IsNullOrEmpty(reader[0].ToString()))
                    {
                        Console.WriteLine("(no minions)");
                        Environment.Exit(0);
                    }
                    Console.WriteLine(reader[0] + ". " + reader[1] + " " + reader[2]);
                }
            }

        }
    }
}
