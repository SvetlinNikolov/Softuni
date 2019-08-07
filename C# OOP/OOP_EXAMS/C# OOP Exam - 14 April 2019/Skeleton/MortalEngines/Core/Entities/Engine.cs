using MortalEngines.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core.Entities
{
    public class Engine : IEngine
    {
        private MachinesManager machinesManager;
        public Engine()
        {
            machinesManager = new MachinesManager();
        }
        public void Run()
        {
            while (true)
            {
                try
                {



                    string[] tokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (tokens[0] == "Quit")
                    {
                        break;
                    }

                    if (tokens[0] == "HirePilot")
                    {
                        Console.WriteLine(machinesManager.HirePilot(tokens[1])); 
                    }
                    else if (tokens[0] == "PilotReport")
                    {
                        Console.WriteLine(machinesManager.PilotReport(tokens[1])); 
                    }
                    else if (tokens[0] == "ManufactureTank")
                    {
                        Console.WriteLine
                            (machinesManager.ManufactureTank(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]))); 
                    }
                    else if (tokens[0] == "ManufactureFighter")
                    {
                        Console.WriteLine
                            (machinesManager.ManufactureFighter(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]))); 
                    }
                    else if (tokens[0] == "MachineReport")
                    {
                        Console.WriteLine(machinesManager.MachineReport(tokens[1]) ); 
                    }
                    else if (tokens[0] == "AggressiveMode")
                    {
                        Console.WriteLine(machinesManager.ToggleFighterAggressiveMode(tokens[1])); 
                    }
                    else if (tokens[0] == "DefenceMode")
                    {
                        Console.WriteLine(machinesManager.ToggleTankDefenseMode(tokens[1])); 
                    }
                    else if (tokens[0] == "Engage")
                    {
                        Console.WriteLine(machinesManager.EngageMachine(tokens[1], tokens[2])); 
                    }
                    else if (tokens[0] == "Attack")
                    {
                        Console.WriteLine(machinesManager.AttackMachines(tokens[1], tokens[2])); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                    continue;
                }
            }
        }
    }
}
