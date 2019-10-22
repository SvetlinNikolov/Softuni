using System;
using System.Data.SqlClient;

namespace Introduction_to_DB_Apps_Ex
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-8TA8JKL\SQLEXPRESS;
                                              Integrated Security=true;");

            SqlConnection dbCon = new SqlConnection(connectionString);

            dbCon.Open();
            using (dbCon)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("CREATE DATABASE MinionsDb", dbCon);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            connectionString += "Database = MinionsDB;";
            dbCon = new SqlConnection(connectionString);

            SqlCommand createCountries = new SqlCommand("CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), CountryCode CHAR(2))", dbCon);
            SqlCommand createTown = new SqlCommand("CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), CountryCode CHAR(2), FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode))", dbCon);
            SqlCommand createMinion = new SqlCommand("CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), Age INT, TownId INT, FOREIGN KEY (TownId) REFERENCES Towns(Id))", dbCon);
            SqlCommand createEvilnessFactors = new SqlCommand("CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(10) UNIQUE NOT NULL)", dbCon);
            SqlCommand createVillains = new SqlCommand("CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT, FOREIGN KEY (EvilnessFactorId) REFERENCES EvilnessFactors(Id))", dbCon);
            SqlCommand createMinionsVillains = new SqlCommand("CREATE TABLE MinionsVillains(MinionId INT, VillainId INT, FOREIGN KEY (MinionId) REFERENCES Minions(Id), FOREIGN KEY (VillainId) REFERENCES Villains(Id), CONSTRAINT CK_MinionIdVillainId PRIMARY KEY (MinionId, VillainId))", dbCon);

            dbCon.Open();

            using (dbCon)
            {
                try
                {
                    createCountries.ExecuteNonQuery();
                    createTown.ExecuteNonQuery();
                    createMinion.ExecuteNonQuery();
                    createEvilnessFactors.ExecuteNonQuery();
                    createVillains.ExecuteNonQuery();
                    createMinionsVillains.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }
 
}
    }

