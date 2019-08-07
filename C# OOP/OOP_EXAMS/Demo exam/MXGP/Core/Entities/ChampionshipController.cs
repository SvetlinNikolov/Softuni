using MXGP.Core.Contracts;
using MXGP.Models.Riders.Entities;
using MXGP.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MXGP.Models.Motorcycles.Entities;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Races.Entities;

namespace MXGP.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;
        private RiderRepository riderRepository;
        public ChampionshipController()
        {
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
            riderRepository = new RiderRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = riderRepository.Riders.FirstOrDefault(x => x.Name == riderName);
            IMotorcycle motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            else if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel } could not be found.");
            }

            rider.AddMotorcycle(motorcycle);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRider rider = riderRepository.Riders.FirstOrDefault(x => x.Name == riderName);
            IRace race = raceRepository.GetByName(raceName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (race == null)
            {
                throw new InvalidOperationException($"Race { raceName } could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {

            //Could have an issue with the getbyname method
            IMotorcycle motorcycle = null;

            if (type.ToLower() == "speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);

            }
            else if (type.ToLower() == "power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            if (motorcycleRepository.GetByName(motorcycle.Model) != null)
            {
                throw new ArgumentException($"Motorcycle {motorcycle.Model} is already created.");
            }
            else
            {
                motorcycleRepository.Add(motorcycle);

                return $"{motorcycle.GetType().Name} {motorcycle.Model} is created.";
            }


        }

        public string CreateRace(string name, int laps)
        {
            Race race = new Race(name, laps);

            if (raceRepository.GetByName(race.Name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            raceRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            Rider rider = new Rider(riderName);

            if (riderRepository.Riders.Any(x => x.Name == riderName))
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            else
            {
                riderRepository.Add(rider);
                return $"Rider {riderName} is created.";
            }


        }

        public string StartRace(string raceName)
        {
            if (raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            Race currentrace = (Race)raceRepository.Races.First(x => x.Name == raceName);

            if (currentrace.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var result = currentrace.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(currentrace.Laps))
                .Take(3).ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {result[0].Name} wins {currentrace.Name} race.");
            sb.AppendLine($"Rider {result[1].Name} is second in {currentrace.Name} race.");
            sb.AppendLine($"Rider {result[2].Name} is third in {currentrace.Name} race.");

            raceRepository.Remove(currentrace);

            return sb.ToString().TrimEnd();
        }

        //Dunno bout dis one sir
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
