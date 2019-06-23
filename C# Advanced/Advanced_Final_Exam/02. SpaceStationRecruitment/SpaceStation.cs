using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;
        public int Count => this.data.Count;
       
        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Astronaut>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        //I dont know about the =  down there
        public void Add(Astronaut astronaut)
        {
            if (this.Capacity > Count)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astronautToRemove = data.FirstOrDefault(x => x.Name == name);

            if (data.Contains(astronautToRemove))
            {
                data.Remove(astronautToRemove);
                return true;
            }
            return false;
        }
        public Astronaut GetOldestAstronaut()
        {
            Astronaut astronautToReturn = data.OrderByDescending(x => x.Age).ToList()[0];
            return astronautToReturn;
        }
        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronautWithThatName = data.Where(x => x.Name == name).ToList()[0];

            return astronautWithThatName;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astro in data)
            {
                sb.AppendLine(astro.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
