using System;
using System.Data.SqlClient;

namespace _06.RemoveVillain
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Database = MinionsDB;Integrated Security=true;");

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            int villainId = int.Parse(Console.ReadLine());

            SqlCommand findVillainSql = new SqlCommand($"SELECT Name FROM Villains WHERE Id = '{villainId}'", sqlConnection);

            string villainName = (string)findVillainSql.ExecuteScalar();

            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
                Environment.Exit(0);
            }

            using (sqlConnection)
            {
                SqlTransaction transaction = sqlConnection.BeginTransaction();

                try
                {
                     SqlCommand villainExistsSql = new SqlCommand($@"SELECT TOP(1) Name FROM Villains
                                                              WHERE Id = '{villainId}'", sqlConnection, transaction);

                    SqlCommand deleteVillain = new SqlCommand($@"DELETE FROM Villains
                                                              WHERE Id = '{villainId}'", sqlConnection, transaction);

                    int villainExists = Convert.ToInt32(villainExistsSql.ExecuteNonQuery());

                    if (villainExists == 0)
                    {
                        throw new ArgumentException("No such villain was found.");
                    }
                   

                    SqlCommand deleteMinionsFromVillain = new SqlCommand(@$"DELETE FROM MinionsVillains 
                                                                         WHERE VillainId = '{villainId}'", sqlConnection, transaction);

                    int minionsCount = Convert.ToInt32(deleteMinionsFromVillain.ExecuteNonQuery());
                    deleteVillain.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionsCount} minions were released.");
                    
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
