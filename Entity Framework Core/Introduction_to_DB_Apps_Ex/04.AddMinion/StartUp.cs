using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = (@"Server = DESKTOP-MU23NJN\SQLEXPRESS;
                                              Database = MinionsDB;Integrated Security=true;");

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string[] minionInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string[] villainInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string villainName = villainInfo[1];

            string getVillainId = (@" SELECT Id FROM Villains WHERE Name = @Name");
            string getMinnionId = (@"SELECT Id FROM Minions WHERE Name = @Name");

            SqlCommand getvillainIdSql = new SqlCommand(getVillainId, sqlConnection);
            getvillainIdSql.Parameters.AddWithValue("@Name", villainName);

            SqlCommand getMinionIdSql = new SqlCommand(getMinnionId, sqlConnection);
            getMinionIdSql.Parameters.AddWithValue("@Name", minionName);

            int villaindId = 0;
            int minionId = 0;

            try
            {
                villaindId = (int)getvillainIdSql.ExecuteScalar();
                minionId = (int)getMinionIdSql.ExecuteScalar();
            }
            catch (Exception ex)
            {

                //too lazy to do tarnary operator 
            }


            if (villaindId == 0)
            {
                SqlCommand insertVillainSql = new SqlCommand(@"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)", sqlConnection);
                insertVillainSql.Parameters.AddWithValue("@villainName", villainName);
                insertVillainSql.ExecuteNonQuery();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            SqlCommand checkIfMinionTownExists = new SqlCommand(@"SELECT Id FROM Towns WHERE Name = @townName", sqlConnection);
            checkIfMinionTownExists.Parameters.AddWithValue("@townName", minionTown);

            int minionTownId = 0;
            try
            {
                minionTownId = (int)checkIfMinionTownExists.ExecuteScalar();
            }
            catch (Exception exc)
            {

                //yeah i know 
            }


            if (minionTownId == 0)
            {
                SqlCommand insertTownIntoTowns = new SqlCommand("INSERT INTO Towns (Name) VALUES (@townName)", sqlConnection);
                insertTownIntoTowns.Parameters.AddWithValue("@townName", minionTown);
                insertTownIntoTowns.ExecuteNonQuery();

                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            SqlCommand createMinion = new SqlCommand(@"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", sqlConnection);
            createMinion.Parameters.AddWithValue("@name", minionName);
            createMinion.Parameters.AddWithValue("@age", minionAge);
            createMinion.Parameters.AddWithValue("@townId", minionTownId);

            //createMinion.ExecuteNonQuery();

            SqlCommand addMinionToVillain = new SqlCommand(@"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", sqlConnection);
            addMinionToVillain.Parameters.AddWithValue("@villainId", villaindId);
            addMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillain.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

        }
    }

}
