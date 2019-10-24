using System;
using System.Data.SqlClient;
using System.Text;

namespace _05.ChangeTownNamesCasing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Database = MinionsDB;Integrated Security=true;");

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string country = Console.ReadLine();

            SqlCommand findCountryExistsSql =
                new SqlCommand($"SELECT c.Id FROM Countries AS c WHERE c.Name = '{country}'", sqlConnection);

            int? countryId = (int?)findCountryExistsSql.ExecuteScalar();

            if (countryId == null)
            {
                Console.WriteLine("No town names were affected.");
                Environment.Exit(0);
            }

            SqlCommand townsInCountry =
                new SqlCommand(@$"SELECT t.Name
                FROM Towns as t
                JOIN Countries AS c ON c.Id = t.CountryCode
                WHERE c.Name = '{country}'", sqlConnection);

            using (sqlConnection)
            {

                StringBuilder result = new StringBuilder();

                SqlCommand updateTowns =
                    new SqlCommand($@"
                                UPDATE Towns
                                SET Name = UPPER(Name)
                                WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = '{country}')", sqlConnection);

                int townsAffected = Convert.ToInt32(updateTowns.ExecuteNonQuery());

                result.AppendLine($"{townsAffected} town names were affected.");

                if (townsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    Environment.Exit(0);
                }

                SqlDataReader reader = townsInCountry.ExecuteReader();

                result.Append("[");

                int counter = 0;
                while (reader.Read())
                {
                    counter++;

                    if (counter < townsAffected)
                    {
                     
                        result.Append(reader[0] + ", ");
                    }
                    else
                    {
                        result.Append(reader[0]);
                    }


                }
                result.Append("]");

                Console.WriteLine(result);
                Environment.Exit(0);

            }
        }
    }
}