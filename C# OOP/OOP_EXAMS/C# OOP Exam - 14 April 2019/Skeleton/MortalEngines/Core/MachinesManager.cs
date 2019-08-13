namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using MortalEngines.Entities.Pilots;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {

            if (pilots.Any(x => x.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            Pilot pilot = new Pilot(name);

            this.pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {

            if (machines.Any(x => x.Name == name && x.AttackPoints == attackPoints && x.DefensePoints == defensePoints))
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);

            machines.Add(tank);

            return $"Tank {name} manufactured - attack: {tank.AttackPoints}; defense: {tank.DefensePoints}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(x => x.Name == name && x.AttackPoints == attackPoints && x.DefensePoints == defensePoints))
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            machines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints}; defense: {fighter.DefensePoints}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilots.FirstOrDefault(x => x.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            IMachine machine = machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot == null)
            {
                pilot.AddMachine(machine);
                return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }

            return $"Machine {selectedMachineName} is already occupied";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(x => x.Name == attackingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            var defendingMachine = machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackingMachine.HealthPoints == 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            else if (defendingMachine.HealthPoints == 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackingMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints}";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilotToReport = pilots.FirstOrDefault(x => x.Name == pilotReporting);
            return pilotToReport.Report();

        }

        public string MachineReport(string machineName)
        {
            var machineToReport = machines.FirstOrDefault(x => x.Name == machineName);

            return machineToReport.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!machines.Any(x => x.GetType().Name == "Fighter" && x.Name == fighterName))
            {
                return $"Machine {fighterName} could not be found";
            }

            Fighter fighterToTrigger = (Fighter)machines.FirstOrDefault(x => x.GetType().Name == "Fighter" && x.Name == fighterName);

            fighterToTrigger.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!machines.Any(x => x.Name == tankName))
            {
                return $"Machine {tankName} could not be found";
            }

            Tank tankToTrigger = (Tank)machines.FirstOrDefault(x => x.Name == tankName);

            tankToTrigger.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}