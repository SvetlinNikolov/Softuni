namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Machines;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;
        public MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
        }
        public string HirePilot(string name)
        {
            IPilot pilot = new Pilot(name);

            if (this.pilots.FirstOrDefault(x=>x.Name==name)!=null)
            {
                return $"Pilot {name} is hired already";
            }
            else
            {
                this.pilots.Add(pilot);

                return $"Pilot {name} hired";
            }

        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            ITank tank = new Tank(name, attackPoints, defensePoints);

            if (this.machines.Any(x => x.Name == name))
            {
                return $"Machine { name} is manufactured already";
            }
            else
            {
                this.machines.Add(tank);
                return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:f2}; defense: {tank.DefensePoints:f2}";
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IMachine fighter = new Fighter(name, attackPoints, defensePoints);

            if (this.machines.Any(x => x.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            this.machines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints:f2}; defense: {fighter.DefensePoints:f2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            IMachine machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }
            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }
            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"Pilot {pilot.Name} engaged machine {machine.Name}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            IMachine defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            else if (defendingMachine == null)
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
            return $"Machine {defendingMachine.Name} was attacked by machine {attackingMachine.Name} - current health: {defendingMachine.HealthPoints:f2}";
        }

        public string PilotReport(string pilotReporting)
        {
            var pilotToLookFor = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return pilotToLookFor.Report();
        }

        public string MachineReport(string machineName)
        {
            var machineToLookFor = this.machines.FirstOrDefault(x => x.Name == machineName);

            return machineToLookFor.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!this.machines.Any(x => x.Name == fighterName))
            {
                return $"Machine {fighterName} could not be found";
            }

            Fighter fighterToToggle = (Fighter)this.machines.FirstOrDefault(x => x.Name == fighterName);

            fighterToToggle.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = machines.FirstOrDefault(t => t.Name == tankName);

            if (tank==null)
            {
                return $"Machine {tankName} could not be found";
            }
            else
            {
                Tank tankToTrigger = (Tank)machines.FirstOrDefault(x => x.Name == tankName);
                tankToTrigger.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }
        }
    }
}