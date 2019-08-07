using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.IO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Engine
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ManagerController managerController;
        public Engine()
        {
            reader = new Reader();
            writer = new Writer();
            managerController = new ManagerController();
        }
        public void Run()
        {


            while (true)
            {
                string[] commandArgs = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {

                    if (commandArgs[0] == "Exit")
                    {
                        break;
                    }

                    if (commandArgs[0] == "AddPlayer")
                    {

                        writer.WriteLine(managerController.AddPlayer(commandArgs[1], commandArgs[2]));
                    }
                    else if (commandArgs[0] == "AddCard")
                    {

                        writer.WriteLine(managerController.AddCard(commandArgs[1], commandArgs[2]));
                    }
                    else if (commandArgs[0] == "AddPlayerCard")
                    {
                        writer.WriteLine(managerController.AddPlayerCard(commandArgs[1], commandArgs[2]));
                    }
                    else if (commandArgs[0] == "Fight")
                    {
                        writer.WriteLine(managerController.Fight(commandArgs[1], commandArgs[2]));
                    }
                    else if (commandArgs[0] == "Report")
                    {
                        writer.WriteLine(managerController.Report());
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

