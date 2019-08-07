
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Hotel
{

    public abstract class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> privateHotel;

        private const int Capacity = 10;

        public Hotel()
        {
            privateHotel = new Dictionary<string, IAnimal>();
        }
     

        public IReadOnlyDictionary<string, IAnimal> Animals => this.privateHotel;

        public void Accommodate(IAnimal animal)
        {
            if (Animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            privateHotel.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            var animalToRemove = Animals[animalName];

            animalToRemove.Owner = owner;
            animalToRemove.IsAdopt = true;
            privateHotel.Remove(animalName);

        }
    }
}
