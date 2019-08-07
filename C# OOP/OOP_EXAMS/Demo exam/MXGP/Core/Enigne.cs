using MXGP.Core.Contracts;
using MXGP.Core.Entities;
using MXGP.IO;
using MXGP.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Enigne : IEngine
    {
        private ChampionshipController championshipController;
        private ConsoleReader reader;
        private ConsoleWriter writer;
        public Enigne()
        {
            championshipController = new ChampionshipController();
            reader = new ConsoleReader();
            writer = new ConsoleWriter();
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] tokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (tokens[0].ToLower() == "end")
                    {
                        Environment.Exit(0);
                    }

                    if (tokens[0] == "CreateRider")
                    {
                        writer.WriteLine(championshipController.CreateRider(tokens[1]));
                    }
                    else if (tokens[0] == "CreateMotorcycle")
                    {
                        writer.WriteLine( championshipController
                            .CreateMotorcycle(tokens[1], tokens[2], int.Parse(tokens[3])));
                    }
                    else if (tokens[0] == "AddMotorcycleToRider")
                    {
                        writer.WriteLine( championshipController
                           .AddMotorcycleToRider(tokens[1], tokens[2]));
                    }
                    else if (tokens[0] == "AddRiderToRace")
                    {
                        writer.WriteLine(championshipController
                          .AddRiderToRace(tokens[1], tokens[2]));
                    }
                    else if (tokens[0] == "CreateRace")
                    {
                        writer.WriteLine( championshipController
                           .CreateRace(tokens[1], int.Parse(tokens[2])));
                    }
                    else if (tokens[0] == "StartRace")
                    {
                        writer.WriteLine(championshipController.StartRace(tokens[1]));
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    continue;
                }
            }
        }
    }
}
