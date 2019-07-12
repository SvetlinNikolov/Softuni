using _05._Border_Control.Interfaces;
using _05._Border_Control.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _05._Border_Control.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            List<IBirthDateable> allEntities = new List<IBirthDateable>();

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "End")
                {
                    break;
                }

                if (command == "Citizen")
                {
                    string citizenName = tokens[1];
                    int citizenAge = int.Parse(tokens[2]);
                    string citizenId = tokens[3];

                    DateTime citizenBirthdate = DateTime
                        .ParseExact(tokens[4],
                        "dd/MM/yyyy",
                        CultureInfo.CurrentCulture);

                    Citizen citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
                    allEntities.Add(citizen);
                }
                else if (command == "Robot")
                {
                    string robotmodel = tokens[1];
                    string robotId = tokens[2];

                    Robot robot = new Robot(robotmodel, robotId);

                }
                else if (command == "Pet")
                {
                    string petName = tokens[1];

                    DateTime petBirthdate = DateTime
                        .ParseExact(tokens[2],
                        "dd/MM/yyyy",
                        CultureInfo.CurrentCulture);

                    Pet pet = new Pet(petName, petBirthdate);
                    allEntities.Add(pet);

                }
            }

            int yearOfEntitiesToPrint = int.Parse(Console.ReadLine());

            var entitiesBornInGivenYear = allEntities.Where(c => c.BirthDate.Year == yearOfEntitiesToPrint)
                .ToList();

            foreach (var entity in entitiesBornInGivenYear)
            {
                Console.WriteLine(entity.BirthDate);
            }


        }
    }
}
